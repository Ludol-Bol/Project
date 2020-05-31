using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Data.Repository;
using Project.ViewModel;

namespace Project.Controllers
{
    public class PupilRegPageController : Controller
    {

        List<School> listschools;   
        WorkDB work = new WorkDB();      

        public PupilRegPageController()
        {
                   
        }


        [HttpGet]
        public IActionResult PupileReg()// отправляем на страницу список школ
        {
            listschools = work.GetSchools();
            SchoolModels sm = new SchoolModels();
            sm.schools = listschools;
            return View(sm);
        }

        [HttpPost]
        public IActionResult PupileReg(string name, string surname, string patr, int namberclass, string email, string password, string phone, int school)// данные типо получаем и отправляем email
        {
            if (work.ExistenceUser(email)) { ViewBag.Head = "Пользователь с таким email уже существует"; return View(); }
            else
            {
                Program.name = name;
                Program.surname = surname;
                Program.patr = patr;
                Program.email = email;
                Program.password = password;
                Program.phone = phone;
                Program.idschool = school;
                Program.numberclass=namberclass;
                Verification verification = new Verification(email);
                Program.code = verification.Sendletter();
                return RedirectPermanent("~/PupilRegPage/PupilRegCode");
            }

        }

        [HttpGet]
        public IActionResult PupilRegCode()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PupilRegCode(long code)// смотрим правильно ли ввели код по е-mail и добавлем 
        {

            if (Program.code == code)
            {
                work.AddNewUserPupil(Program.name, Program.surname, Program.patr, Program.phone, Program.idschool, Program.email, Program.password, Program.numberclass);
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
