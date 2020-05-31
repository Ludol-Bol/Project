using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Data.Repository;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
// контроллер существующих курсов
namespace Project.Controllers
{
    public class ExistingCoursesController : Controller
    {
        List<Courses> listcourses;// список курсов
        WorkDB work = new WorkDB();
        WorkHosting workh = new WorkHosting();

    
        IWebHostEnvironment _appEnvironment;
        

        public ExistingCoursesController(IWebHostEnvironment appEnvironment )
        {
            
            _appEnvironment = appEnvironment;
            listcourses = work.GetCourses();
        }
        
        [HttpGet]
        public IActionResult ShowCourses()// показать курсы 
        {
            CoursesModel cm = new CoursesModel();
            cm.courses = listcourses;
            return View(cm);
        }

        [HttpGet]
        public IActionResult AddLesson()
        {          
            return View();
        }

        [HttpPost]
        public IActionResult AddLesson(string name, string infostring, string links, IFormFile pathfile)// добавление курсов 
        {
            string nam = name;
                  
            work.UpdateCountLesson(3);
            workh.CreateFilesLesson(Program.namecours+"_"+Program.datateacher.Idteacher, name, pathfile, links, infostring, work.GetCountLesson(3));
            Verification ver = new Verification();
            ver.Notification(work.GetArrayEmailPupils(Program.datateacher.Idschool, work.GetNumberClass(Program.idcours)));
            return View();
        }


        [HttpPost]
        public IActionResult ShowCourses(int id, int typeoption)// выбираем действие, которое надл сделать
        {
            Program.idcours = id;
            Program.namecours = work.NameCourses(id);
            if(typeoption==1) return RedirectPermanent("~/ExistingCourses/AddLesson");
            if (typeoption == 3) { work.DeleteCourse(Program.idcours); workh.DeleteDirectoryCourses(Program.namecours + "_" + Program.idcours); return View(); }
            else
                return View();
        }
    }
}
