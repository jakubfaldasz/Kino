using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KinoDotNetCore.Controllers
{
    public class EmployeePanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}