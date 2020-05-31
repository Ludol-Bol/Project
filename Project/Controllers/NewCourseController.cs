using Microsoft.AspNetCore.Mvc;
using Project.Data.Repository;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class NewCourseController : Controller
    {

        List<Subject> listsubjects;// список предметов 
        List<School> schools;
        WorkDB work = new WorkDB();
        public NewCourseController()
        {

            listsubjects = work.GetSubjects();
            schools = work.GetSchools();
        }

        [HttpGet]
        public IActionResult NewCours()// передаем на страницу какие предметы существуют
        {
            SchoolModels sm = new SchoolModels();
            sm.subjects = listsubjects;
            sm.schools = schools;
            return View(sm);
        }

        [HttpPost]
        public IActionResult NewCours(string namec, int sudject, int _class)// создается новый курс 
        {

            work.AddCourse(Program.datateacher.Idteacher, namec, _class, Program.datateacher.Idschool, sudject);
            WorkHosting workh = new WorkHosting();
            workh.CreatCourse(String.Concat(namec , "_" , Program.datateacher.Idteacher));
            return View();
        }
    }
}
