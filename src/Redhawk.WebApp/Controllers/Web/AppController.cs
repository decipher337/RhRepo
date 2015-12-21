using Microsoft.AspNet.Mvc;
using Redhawk.WebApp.Models;
using Redhawk.WebApp.Services;
using Redhawk.WebApp.ViewModels;
using System;
using System.Linq;

namespace Redhawk.WebApp.Controllers.Web
{
	public class AppController : Controller
	{
		private IMailService _mailService;
		private RedhawkContext _context;

		public AppController(IMailService service, RedhawkContext context)
		{
			_mailService = service;
			_context = context;
		}

		public IActionResult Index()
		{
			var trips = _context.Trips.OrderBy(t => t.Name).ToList();

			return View(trips);
		}

		public IActionResult About()
		{
			return View();
		}

		public IActionResult Contact()
		{
			return View();
		}

		public IActionResult People()
		{
			return View();
		}

		public IActionResult Inventory()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Contact(ContactViewModel model)
		{
			if(ModelState.IsValid)
			{
				var email = Startup.Configuration["AppSettings:SiteEmailAddress"];

				if(string.IsNullOrWhiteSpace(email))
				{
					ModelState.AddModelError("", "Could not send email, configuration problem.");
				}

				if(_mailService.SendMail(email,
					email,
					$"Contact Page from {model.Name} ({model.Email})",
					model.Message))
				{
					ModelState.Clear();

					ViewBag.Message = "Mail sent, thanks.";
				}
			}

			return View();
		}
	}
}
