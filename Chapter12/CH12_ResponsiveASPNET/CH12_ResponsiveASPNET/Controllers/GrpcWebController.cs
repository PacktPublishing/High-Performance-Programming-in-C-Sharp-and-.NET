using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CH12_ResponsiveASPNET.Controllers
{
	public class GrpcWebController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
