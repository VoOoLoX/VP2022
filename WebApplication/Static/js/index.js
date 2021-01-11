const $ = document.querySelector.bind(document)
const _ = document.querySelectorAll.bind(document)
const api = 'https://localhost:4001/api'

const get_cookie = (name) => {
	var value = '; ' + document.cookie
	var parts = value.split('; ' + name + '=')
	if (parts.length == 2) return parts.pop().split(';').shift()
}

const set_cookie = (name, value) => {
	document.cookie = ''.concat(name, '=').concat(value)
}

const get_nodes = str => new DOMParser().parseFromString(str, 'text/html').body.childNodes;

const api_call = async (endpoint, method, data, callback) => {
	await fetch(`${api}/${endpoint}`, {
		method: method,
		headers: {
			'Content-Type': 'application/json'
		},
		body: JSON.stringify(data),
	}).then(r => r.json().then(data => ({ status: r.status, body: data }))).then(obj => callback(obj))
}

const api_call_get = async (endpoint, callback) => {
	await fetch(`${api}/${endpoint}`, {
		method: 'GET'
	}).then(r => r.json().then(data => ({ status: r.status, body: data }))).then(obj => callback(obj))
}

const register = async () => {
	var form_data = new FormData($('#register-form'))
	var data = { email: form_data.get('email'), password: form_data.get('password'), confirmpassword: form_data.get('confirm_password') }

	await api_call('Register', 'POST', data, (res) => {
		$('#result-message').innerText = res.body.message
		if (res.status == 200) {
			setTimeout(() => {
				location.href = '/Login'
			}, 1000)
		}
	})
}

const login = async () => {
	var form_data = new FormData($('#login-form'))
	var data = { email: form_data.get('email'), password: form_data.get('password') }

	await api_call('Login', 'POST', data, (res) => {
		$('#result-message').innerText = res.body.message
		if (res.status == 200) {
			setTimeout(() => {
				set_cookie('jwt', res.body.token)
				history.back()
			}, 1000)
		}
	})
}

const logout = async () => {
	set_cookie('jwt', '')
	location.reload()
}

const logged_in = async (callback) => {
	await fetch(`${api}/ValidateToken`, {
		method: 'GET',
		headers: {
			'Authorization': `Bearer ${get_cookie('jwt')}`
		},
	}).then(r => { if (r.status == 200) callback() })
}

const logged_out = async (callback) => {
	await fetch(`${api}/ValidateToken`, {
		method: 'GET',
		headers: {
			'Authorization': `Bearer ${get_cookie('jwt')}`
		},
	}).then(r => { if (r.status != 200) callback(r.status) })
}

const open_vehicle = (id) => {
	location.href = `/Vehicle/${id}`
}

const create_vehicle_card = (vehicle) => {
	var card = get_nodes(`
	<div class='card' onclick='open_vehicle(${vehicle.id})'>
		<div class='image-box'>
			<img src='${vehicle.image}' alt=''/>
		</div>
		<div class='description-box'>
			<h1>${vehicle.manufacturer} - ${vehicle.model}</h1>
			<hr>
			<p><strong>Godište: </strong>${vehicle.year}</p>
			<p><strong>Kilometraža: </strong>${vehicle.milage} km</p>
			<p><strong>Motor: </strong>${vehicle.cubicCapacity} cc</p>
			<p><strong>Tip vozila: </strong>${vehicle.vehicleType}</p>
			<p><strong>Gorivo: </strong>${vehicle.fuel} </p>
		</div>
		<div class='card-price'>${vehicle.price} &euro;</div>
	</div>`)[0]

	return card
}

const render_vehicles = async (root, vehicles) => {
	root.innerHTML = ''

	vehicles.forEach((vehicle) => {
		root.appendChild(create_vehicle_card(vehicle))
	})
}

const index_vehicles = async () => {
	var data = {
		count: 4
	}

	await api_call('TopVehicles', 'POST', data, (res) => {
		if (res.status == 200)
			render_vehicles($('#vehicles'), res.body.vehicles)
	})
}

const browse_vehicles = async () => {
	var form_data = new FormData($('#filter-form'))

	var data = {
		manufacturer: form_data.get('manufacturer'),
		model: form_data.get('model'),
		yearStart: Number(form_data.get('year_start')),
		yearEnd: Number(form_data.get('year_end')),
		priceStart: Number(form_data.get('price_start')),
		priceEnd: Number(form_data.get('price_end')),
		sort: $('#sort').value
	}

	await api_call('Browse', 'POST', data, (res) => {
		if (res.status == 200) {
			render_vehicles($('#vehicles'), res.body.vehicles)
			$('#results').innerText = `${res.body.results} rezultata`
		}
	})
}

const get_vehicle = async (id) => {
	var data = {
		id: id
	}

	await api_call('Vehicle', 'POST', data, (res) => {
		if (res.status == 200) {
			var vehicle = res.body.vehicle

			$('#vehicle-name').innerText = `${vehicle.manufacturer} - ${vehicle.model}`
			$('#vehicle-price').innerHTML = `${vehicle.price} &euro;`

			api_call_get(`Images/${vehicle.id}`, (img_res) => {
				var result = img_res.body
				//result.images.forEach((img) => {
				//	var img_element = get_nodes(`<img src="${img.link}">`)[0]
				//	$('#vehicle-images').appendChild(img_element)
				//})
				$('#vehicle-images').appendChild(get_nodes(`<img src="${result.images[0].link}">`)[0])


			})

			$("#vehicle-cubic-capacity").innerText = `Zapremina motora: ${vehicle.cubicCapacity}`
			$("#vehicle-horse-power").innerText = `Snaga motora: ${vehicle.horsePower}`
			$("#vehicle-type").innerText = `Tip vozila: ${vehicle.vehicleType}`
			$("#vehicle-fuel").innerText = `Gorivo: ${vehicle.fuel}`
			$("#vehicle-milage").innerText = `Kilometraza: ${vehicle.milage}`

			$('#vehicle-cruise-control').style.display = vehicle.features.cruiseControl ? 'block' : 'none'
			$('#vehicle-parking-sensors').style.display = vehicle.features.parkingSensors ? 'block' : 'none'
			$('#vehicle-electric-windows').style.display = vehicle.features.electricWindows ? 'block' : 'none'
			$('#vehicle-sunroof').style.display = vehicle.features.sunroof ? 'block' : 'none'
			$('#vehicle-xenon-headlights').style.display = vehicle.features.xenonHeadlights ? 'block' : 'none'
			$('#vehicle-multimedia').style.display = vehicle.features.multimedia ? 'block' : 'none'
			$('#vehicle-navigation').style.display = vehicle.features.navigation ? 'block' : 'none'
			$('#vehicle-air-conditioning').style.display = vehicle.features.airConditioning ? 'block' : 'none'

			$('#vehicle-airbag').style.display = vehicle.security.airbag ? 'block' : 'none'
			$('#vehicle-esp').style.display = vehicle.security.esp ? 'block' : 'none'
			$('#vehicle-asr').style.display = vehicle.security.asr ? 'block' : 'none'
			$('#vehicle-childlock').style.display = vehicle.security.childlock ? 'block' : 'none'
			$('#vehicle-immobiliser').style.display = vehicle.security.immobiliser ? 'block' : 'none'
			$('#vehicle-central-locking').style.display = vehicle.security.centralLocking ? 'block' : 'none'

			$('#vehicle-description').innerText = vehicle.description
		}
	})
}

document.addEventListener('DOMContentLoaded', () => {
	_('[page]').forEach((button) => {
		button.addEventListener('click', () => {
			location.href = button.getAttribute('page')
		})
	})

	if (get_cookie('jwt')) {
		window.setInterval(logged_out, 5000, (status) => {
			logout()
		})
	}
})