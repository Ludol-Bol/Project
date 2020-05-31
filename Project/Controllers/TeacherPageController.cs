using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class TeacherPageController : Controller  //работа с контроллером учителя. 
    {
       // страница учителя
        public IActionResult Page1()
        {
            return View();
        }
    }
}
