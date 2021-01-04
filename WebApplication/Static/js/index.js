const $ = document.querySelector.bind(document)
const _ = document.querySelectorAll.bind(document)

const get_cookie = (name) => {
	var value = "; " + document.cookie
	var parts = value.split("; " + name + "=")
	if (parts.length == 2) return parts.pop().split(";").shift()
}

const set_cookie = (name, value) => {
	document.cookie = "".concat(name, "=").concat(value)
}

const api_call = async (endpoint, method, data, callback) => {
	await fetch(`https://localhost:4001/api/${endpoint}`, {
		method: method,
		headers: {
			"Content-Type": "application/json"
		},
		body: JSON.stringify(data),
	}).then(r => r.json().then(data => ({ status: r.status, body: data }))).then(obj => callback(obj))
}

const register = async () => {
	var form_data = new FormData($('#register-form'))
	var data = { email: form_data.get('email'), password: form_data.get('password'), confirmpassword: form_data.get('confirm_password') }

	await api_call('Register', 'POST', data, (res) => {
		//console.log(res)
		$('#result-message').innerText = res.body.message
		if (res.status == 200) {
			setTimeout(() => {
				document.location.href = '/Login'
			}, 1000)
		}
	})
}

const login = async () => {
	var form_data = new FormData($('#login-form'))
	var data = { email: form_data.get('email'), password: form_data.get('password') }

	await api_call('Login', 'POST', data, (res) => {
		//console.log(res)
		$('#result-message').innerText = res.body.message
		if (res.status == 200) {
			setTimeout(() => {
				set_cookie('jwt', res.body.token)
				document.location.href = '../'
			}, 1000)
		}
	})
}

const get_nodes = str => new DOMParser().parseFromString(str, 'text/html').body.childNodes;

const refresh_vehicles = async () => {
	var form_data = new FormData($('#filter-form'))
	var data = {
		manufacturer: form_data.get('manufacturer'),
		model: form_data.get('model'),
		yearStart: Number(form_data.get('year_start')),
		yearEnd: Number(form_data.get('year_end')),
		priceStart: Number(form_data.get('price_start')),
		priceEnd: Number(form_data.get('price_end')),
	}

	await api_call('Browse', 'POST', data, (res) => {
		if (res.status == 200) {
			$("#browse").innerHTML = ''

			res.body.vehicles.forEach((vehicle) => {
				var card = get_nodes(`
				<a href="/Vehicle/${vehicle.id}">
					<div class="card">
						<div class="image-box">
							<img src="https://automobiles.honda.com/-/media/Honda-Automobiles/Vehicles/2021/Civic-Type-R/Feature-Blades/Exterior-Interior/Overview/MY21CivicTypeRExtInt00Overview14002x.jpg" alt="">
						</div>
						<div class="description-box">
							<h1>${vehicle.manufacturer} - ${vehicle.model}</h1>
							<hr>
							<p><strong>Godište: </strong>${vehicle.year}</p>
							<p><strong>Kilometraža: </strong>${vehicle.milage} km</p>
							<p><strong>Motor: </strong>${vehicle.cubicCapacity} cc</p>
							<p><strong>Tip vozila: </strong>${vehicle.vehicleType}</p>
							<p><strong>Gorivo: </strong>${vehicle.fuel} </p>
						</div>
						<div class="div-price">${vehicle.price} &euro;</div>
					</div>
				</a>`)

				$("#browse").appendChild(card[0])
			})
		}
	})
}