using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CH11_ResponsiveASPNET.Controllers
{
	public class SignalRController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
