using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CH12_ResponsiveASPNET.Controllers
{
	public class AjaxController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Demo()
		{
			return new JsonResult("Ajax Demo Result");
		}
	}
}
