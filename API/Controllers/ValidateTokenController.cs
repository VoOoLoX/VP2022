using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class ValidateTokenController : ControllerBase {
		[HttpGet]
		[Authorize]
		public async Task<IActionResult> ValidateAsync() {
			var access_token = await HttpContext.GetTokenAsync("Bearer", "access_token");

			if (string.IsNullOrEmpty(access_token))
				return Unauthorized(new { message = "Token sesije nije pronađen." });

			return Ok(new { message = "Token je validan." });
		}
	}
}
