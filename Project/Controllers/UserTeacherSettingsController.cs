using Microsoft.AspNetCore.Mvc;
using Project.Data.Repository;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    // контроллер для обновление данных проподавателя
    public class UserTeacherSettingsController : Controller
    {
        List<School> listschools;
        List<Subject> listsubjects;
        WorkDB work = new WorkDB();

        public UserTeacherSettingsController()
        {
            listschools = work.GetSchools();
            listsubjects = work.GetSubjects();
        }

        [HttpGet]
        public IActionResult UpdateTeacher()// передаем на страницу данные предмета и школы
        {
            SchoolModels sm = new SchoolModels();
            sm.schools = listschools;
            sm.subjects = listsubjects;
            return View(sm);
        }

        [HttpPost]
        public IActionResult UpdateTeacher(string newname, string newsurname, string newpatr, string newpassword, string newphone, int newschool)// получаем данные и обновляем их
        {
            work.UpdateTeacherData(newname, newsurname, newpatr, newpassword, newphone, newschool, Program.datateacher.Idteacher);
            Program.datateacher.Name = newname;
            Program.datateacher.Surname = newsurname;
            Program.datateacher.Patronymic = newpatr;
            Program.datateacher.Password = newpassword;
            Program.datateacher.Phone = newphone;
            Program.datateacher.Idschool = newschool;
            return View();

        }
    }
}
