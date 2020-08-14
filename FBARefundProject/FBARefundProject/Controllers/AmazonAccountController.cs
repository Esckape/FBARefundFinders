using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FBARefundProject.Controllers
{
    public class AmazonAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
