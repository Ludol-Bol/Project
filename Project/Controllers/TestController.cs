using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.Controllers
{
    // была попытка контроллера тестов
    public class TestController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult CreateTest()
        {

            return View();
        }

        public IActionResult Test_1()
        {
            //int t = 2 + 2;
            return View();
        }
    }
}
