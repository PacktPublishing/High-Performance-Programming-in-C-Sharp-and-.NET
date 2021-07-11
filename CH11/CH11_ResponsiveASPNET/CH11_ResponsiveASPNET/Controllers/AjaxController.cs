using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CH11_ResponsiveASPNET.Controllers
{
	public class AjaxController : Controller
	{
		[Route("Ajax/Index")]
		[Route("")]
		[Route("~/")]
		public IActionResult Index()
		{
			return View();
		}

		[Route("Ajax/Demo")]
		public IActionResult AjaxDemo()
		{
			return new JsonResult("Ajax Demo Result");
		}
	}
}
