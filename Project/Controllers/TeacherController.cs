using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Data.Repository;
using Project.ViewModel;

namespace Project.Controllers
{
    public class TeacherController : Controller
    {
       
        List<School> listschools;
        List<Subject> listsubjects;
        WorkDB work = new WorkDB();
      
        

        public TeacherController()
        {
            
            listschools = work.GetSchools();
            listsubjects = work.GetSubjects();
        }

        [HttpGet]
        public IActionResult TeacherRegPage()
        {
            SchoolModels sm = new SchoolModels();
            sm.schools = listschools;
            sm.subjects = listsubjects;
            return View(sm);
        }

        [HttpPost]
        public IActionResult TeacherRegPage(string name, string surname, string patr, string email, string password, string phone, int school, int sudject)// данные типо получаем и отправляем email
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
                Program.idsubject = sudject;
                Verification verification = new Verification(email);
                Program.code = verification.Sendletter();
                return RedirectPermanent("~/Teacher/TeacherRegPageCode");
            }
                      
        }

        [HttpGet]
        public IActionResult TeacherRegPageCode()
        {     
            return View();
        }

        [HttpPost]
        public IActionResult TeacherRegPageCode(long code)// смотрим правильно ли ввели код по е-mail и добавлем 
        {

            if (Program.code == code) 
            {
                work.AddNewUserTeacher(Program.name, Program.surname, Program.patr, Program.phone, Program.idschool, Program.idsubject, Program.email, Program.password);
                return RedirectPermanent("~/Teacher/Thanks"); 
            }
            else
            {
                ViewBag.Head = "Код неправильный";
                return View();
            }
        }

        public IActionResult Thanks()
        {

            return View();
        }

    }
}
