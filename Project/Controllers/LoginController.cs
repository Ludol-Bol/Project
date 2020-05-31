using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Data.Repository;

namespace Project.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult LoginPage()
        {

            return View();
        }

        [HttpPost]
        public IActionResult LoginPage(string log, string pas)// вводим лоин и пароль и в соответсвии с этим переходим на нужную страницу
        {
            WorkDB w = new WorkDB();
            Login login = new Login(log, pas);
            int[] vs = login.EnterUser();
            bool flag = false;
            if (vs[0] == 0 & vs[1] == 0) { flag = true; }
            else flag = false;
            //string s = "Таких записей нет";
            //ViewBag.Head = s;
            if (flag == false)
            {
                switch (vs[1])
                {
                    case 1: Program.datateacher = w.UserDataT(vs); return RedirectPermanent("~/TeacherPage/Page1");
                    case 2: Program.datapupils = w.UserDataP(vs); return View(); 
                    case 3: Program.dataperants = w.UserDataPa(vs); return View(); 
                    default: return View(); 
                }

            }
            else
            {
                return View();
            }
            
            
        }

        [HttpGet]
        public IActionResult RegPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegPage(string nameStatus)// выбираем кто мы 
        {
            if (nameStatus == "Учитель") return RedirectPermanent("~/Teacher/TeacherRegPage");
            if (nameStatus == "Ученик") return RedirectPermanent("~/PupilRegPage/PupileReg");
            if( nameStatus == "Родитель") return RedirectPermanent("~/ParentRegPage/ParentReg");
            else
                return View();
        }
    }
}
