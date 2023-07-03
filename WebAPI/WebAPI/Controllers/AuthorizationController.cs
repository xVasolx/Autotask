using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebAPI.Controllers
{

	[ApiController]
	[Route("api/[controller]")]
	public class AuthorizationController : Controller
	{
		private DBContext _context;

		public AuthorizationController(DBContext dBContext)
		{
			_context = dBContext;
		}

		[HttpPost("Login/login={login}/password={password}")]
		public async void Login(string login, string password)
		{
			if (password == login)//TODO
			{
				await Authenticate(login); // аутентификация
			}
		}

		private async Task Authenticate(string userName)
		{
			// создаем один claim
			var claims = new List<Claim>
{
new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
};
			// создаем объект ClaimsIdentity
			ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
			// установка аутентификационных куки
			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
		}

		[HttpPost("Logout")]
		public async void Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			
		}
	}
}
