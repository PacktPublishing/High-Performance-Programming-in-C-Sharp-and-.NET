using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CH12_ResponsiveASPNET.Controllers
{
	public class SignalRController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
	}
}
