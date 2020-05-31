using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Data.Repository;
using Project.ViewModel;

namespace Project.Controllers
{
    public class ParentRegPageController : Controller
    {
        List<School> listschools;
        WorkDB work = new WorkDB();


        [HttpGet]
        public IActionResult ParentReg()// передаем школу на форму 
        {
            listschools = work.GetSchools();
            SchoolModels sm = new SchoolModels();
            sm.schools = listschools;
            return View(sm);
        }

        [HttpPost]
        public IActionResult ParentReg(string name1, string surname1, string patr1, string name2, string surname2, string patr2, int codp,string email, string password, string phone1, string phone2 )// добавляем новую учетку родителей
        {
            if (work.ExistenceUser(email)) { ViewBag.Head = "Пользователь с таким email уже существует"; return View(); }
            else
            {
                Program.name = name1;
                Program.surname = surname1;
                Program.patr = patr1;
                Program.nameF = name2;
                Program.sunameF = surname2;
                Program.patrF = patr2;
                Program.phonF = phone2;
                Program.email = email;
                Program.password = password;
                Program.phone = phone1;
                Program.codep = codp;
                Verification verification = new Verification(email);
                Program.code = verification.Sendletter();
                return RedirectPermanent("~/ParentRegPage/ParentRegCode");
            }
        }

        [HttpGet]
        public IActionResult ParentRegCode()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ParentRegCode(long code)// проверка кода который пришел по почте 
        {

            if (Program.code == code)
            {
                work.AddNewUserParent(Program.name, Program.surname, Program.patr, Program.nameF, Program.sunameF, Program.patrF, Program.phone,Program.phonF, Program.email, Program.password, Program.codep);
                return RedirectPermanent("~/Teacher/Thanks");
            }
            else
            {
                ViewBag.Head = "Код неправильный";
                return View();
            }
        }
    }
}
