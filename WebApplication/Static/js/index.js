const login_form = document.getElementById('login-form')
const register_form = document.getElementById('register-form')
const result_message = document.getElementById('result-message')

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
	})
		.then(r => r.json().then(data => ({ status: r.status, body: data })))
		.then(obj => callback(obj))
}

const register = async () => {
	var form_data = new FormData(register_form)
	var data = { email: form_data.get('email'), password: form_data.get('password'), confirmpassword: form_data.get('confirm_password') }

	await api_call('Register', 'POST', data, (res) => {
		console.log(res)
		result_message.innerText = res.body.message
	})
}

const login = async () => {
	var form_data = new FormData(login_form)
	var data = { email: form_data.get('email'), password: form_data.get('password') }

	await api_call('Login', 'POST', data, (res) => {
		console.log(res)
		result_message.innerText = res.body.message
		if (res.status == 200) {
			set_cookie('jwt', res.body.token)
			document.location.href = '../'
		}
	})
}