using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared;

namespace API.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase {
		public struct LoginInfo {
			public string Email { get; set; }
			public string Password { get; set; }
		}

		private IConfiguration config;

		public LoginController(IConfiguration config) {
			this.config = config;
		}

		[AllowAnonymous]
		[HttpPost]
		public IActionResult Login([FromBody] LoginInfo login_info) {
			return LoginUser(login_info);
		}

		private string GenerateJWT(User user_info) {
			var security_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]));
			var credentials = new SigningCredentials(security_key, SecurityAlgorithms.HmacSha256);

			var claims = new[] {
				new Claim(JwtRegisteredClaimNames.Email, user_info.Email),
			};

			var token = new JwtSecurityToken(
				issuer: config["JWT:Issuer"],
				audience: config["JWT:Audience"],
				claims: claims,
				expires: DateTime.Now.AddDays(7),
				signingCredentials: credentials
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		private IActionResult LoginUser(LoginInfo login_info) {
			if (UserBusiness.UserExists(login_info.Email)) {
				var user = UserBusiness.Get(login_info.Email);

				var hasher = new PasswordHasher<string>();

				var correct_password = hasher.VerifyHashedPassword(login_info.Email, user.Password, login_info.Password);

				if (correct_password == PasswordVerificationResult.Success)
					return Ok(new { message = "Login successful.", token = GenerateJWT(user) });
				else
					return BadRequest(new { message = "Invalid credentials." });
			} else {
				return BadRequest(new { message = "User does not exist." });
			}
		}
	}
}
