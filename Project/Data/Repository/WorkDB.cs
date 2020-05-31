using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project.Data.Repository
{// класс работы с бд
    public class WorkDB
    {
        public List<Teachers> GetTeachers()// список учителей
        {
            List<Teachers> teachersuser = new List<Teachers>();
            using (EducationSystemContext esc = new EducationSystemContext())
            {
                foreach (var tmp in esc.Teachers)
                    teachersuser.Add(tmp);
            }
            return teachersuser;
        }

        public List<Pupils> GetPupils() // список учеников
        {
            List<Pupils> pupilsusers = new List<Pupils>();
            using (EducationSystemContext esc = new EducationSystemContext())
            {
                foreach (var tmp in esc.Pupils)
                    pupilsusers.Add(tmp);
            }
            return pupilsusers;
        }

        public List<Parents> GetParents()// список родителей
        {
            List<Parents> parentsusers = new List<Parents>();
            using (EducationSystemContext esc = new EducationSystemContext())
            {
                foreach (var tmp in esc.Parents)
                    parentsusers.Add(tmp);
            }
            return parentsusers;
        }

        public List<School> GetSchools()// список школ 
        {
            List<School> schools = new List<School>();
            using (EducationSystemContext esc = new EducationSystemContext())
            {
                foreach (var tmp in esc.School)
                    schools.Add(tmp);
            }
            return schools;
        }
        
        public List<Subject> GetSubjects()// получение списка предметов
        {
            List<Subject> sud = new List<Subject>();
            using (EducationSystemContext esc = new EducationSystemContext())
            {
                foreach (var tmp in esc.Subject)
                    sud.Add(tmp);
            }
            return sud;
        }

        public bool ExistenceUser(string emailusers)// проверка существует ли пользователь с таким email
        {
            bool flagexists = false;
            List<Teachers> teachersusers = GetTeachers();
            List<Pupils> pupilusers = GetPupils();
            List<Parents> parentsusers = GetParents();
            for (int i = 0; i < teachersusers.Count; i++)
            {
                if (teachersusers[i].Email == emailusers) { flagexists = true; break; }
            }
            if(flagexists==false)
            {
                for (int i = 0; i < pupilusers.Count; i++)
                {
                    if (pupilusers[i].Email == emailusers) { flagexists = true; break; }
                }
            }
            if(flagexists==false)
            {
                for (int i = 0; i < parentsusers.Count; i++)
                {
                    if (parentsusers[i].Email == emailusers) { flagexists = true; break; }
                }
            }
            return flagexists;
        }

        public void AddNewUserTeacher(string name, string surnam, string patr, string phone, int? idschool, int? idsubject, string email, string password)// добавление нового пользователя учитель
        {
            Teachers tmp = new Teachers();
            using(EducationSystemContext esc = new EducationSystemContext())
            {
                tmp.Name = name;
                tmp.Surname = surnam;
                tmp.Patronymic = patr;
                tmp.Phone = phone;
                tmp.Idschool = idschool;
                tmp.Idsubject = idsubject;
                tmp.Email = email;
                tmp.Password = password;
                esc.Teachers.Add(tmp);
                esc.SaveChanges();
            }
        }

        public void AddNewUserPupil(string name, string surnam, string patr, string phone, int? idschool, string email, string password, int number)// добавление нового пользователя ученик
        {
            Pupils tmp = new Pupils();
            using (EducationSystemContext esc = new EducationSystemContext())
            {
                tmp.Name = name;
                tmp.Surname = surnam;
                tmp.Patronymic = patr;
                tmp.Phone = phone;
                tmp.Idschool = idschool;
                tmp.NamberClass = number;
                tmp.Email = email;
                tmp.Password = password;
                tmp.Code = 1000;
                esc.Pupils.Add(tmp);
                esc.SaveChanges();
            }
        }

        public void AddNewUserParent(string nameMather, string surnameMather, string PatrMathe, string nameFather, string surnameFather, string PatrFather, string phoneMathe, string phoneFather, string email, string password, int code)// добавление нового пользователя родитель
        {
            Parents tmp = new Parents();
            using (EducationSystemContext esc = new EducationSystemContext())
            {
                tmp.NameMather = nameMather;
                tmp.SurnameFather = surnameMather;
                tmp.PatronymicMather = PatrMathe;
                tmp.NameFather = nameFather;
                tmp.SurnameFather = surnameFather;
                tmp.PatronymicFather = PatrFather;
                tmp.PhoneFather = phoneFather;
                tmp.PhoneMathe = phoneMathe;
                tmp.Email = email;
                tmp.Password = password;
                esc.Parents.Add(tmp);
                esc.SaveChanges();
                esc.Database.ExecuteSqlRaw("UPDATE [Pupils] Set [IDParent]={0} where [IDPupil]={0}",tmp.Idparent,code);
                esc.SaveChanges();
            }

        }

        public Teachers UserDataT(int [] mas)// получение данныхпользователя учитель
        {
            Teachers tmp;
            using (EducationSystemContext esc = new EducationSystemContext())
            {
                tmp = esc.Teachers.FromSqlRaw("Select * from [Teachers] where [IDTeacher]={0}", mas[0]).First();
            }
            return tmp;

        }

        public Pupils UserDataP(int [] mas)// получение данных пользователя ученик
        {
            Pupils tmp;
            using (EducationSystemContext esc = new EducationSystemContext())
            {
                tmp = esc.Pupils.FromSqlRaw("Select * from [Pupils] where [IDPupil]={0}", mas[0]).First();
            }
            return tmp;
        }

        public Parents UserDataPa(int [] mas)// получение данных пользователя родитель 
        {
            Parents tmp;
            using (EducationSystemContext esc = new EducationSystemContext())
            {
                tmp = esc.Parents.FromSqlRaw("Select * from [Parents] where [IDParent]={0}", mas[0]).First();
            }
            return tmp;
        }

        public void AddCourse(int idteacher, string namecours, int numberclass, int? idschooll, int idsubject)// добавляем курс
        {
                   
            using(EducationSystemContext esc = new EducationSystemContext())
            {             
                esc.Database.ExecuteSqlRaw("insert into Courses (IDTeachers, Name, IDSubgect, IDSchool, NamberClass,CountLessons) VALUES ({0},{1},{2},{3},{4},0)", idteacher,namecours,idsubject,idschooll,numberclass);
                
            }           
        }

        public List<Courses> GetCourses()// получение списка курсов 
        {
            List<Courses> sud = new List<Courses>();
            using (EducationSystemContext esc = new EducationSystemContext())
            {
                foreach (var tmp in esc.Courses)
                    sud.Add(tmp);
            }
            return sud;
        }

        public void UpdateCountLesson(int idcourses)// добавляем урок в базу данных
        {
            using (EducationSystemContext esc = new EducationSystemContext())
            {
                esc.Database.ExecuteSqlRaw("update Courses set CountLessons=CountLessons+1 where IDCourse={0}", idcourses);
            }
        }

        public int GetCountLesson(int idcourses)// пролучение количества уроков
        {
            int result = 0;
            using (EducationSystemContext esc = new EducationSystemContext())
            {
                foreach(var tmp in esc.Courses)
                {
                    if (tmp.Idcourse == idcourses) { result = tmp.CountLessons; break; }
                }
            }
            return result;  
        }

        public string NameCourses(int id)// получение имени курса
        {
            string resulte = "";
            using (EducationSystemContext esc = new EducationSystemContext())
            {
                foreach (var tmp in esc.Courses)
                {
                    if (tmp.Idcourse == id) { resulte = tmp.Name; break; }
                }
            }
            return resulte;
        }

        public void DeleteCourse(int id)// удаление курса
        {
            using (EducationSystemContext esc = new EducationSystemContext())
            {
                esc.Database.ExecuteSqlRaw("delete Courses where IDCourse={0}", id);
            }
        }

        public int GetNumberClass(int id)// получение номер класса
        {
            int result = 0;
            using (EducationSystemContext esc = new EducationSystemContext())
            {
                foreach (var tmp in esc.Courses)
                {
                    if (tmp.Idcourse == id) { result = tmp.NamberClass; break; }
                }
            }
            return result;
        }
        public List<string> GetArrayEmailPupils(int? idschool, int number)// получения email учеников для отправки уведомлений на почту
        {
            List<string> email = new List<string>();
            using(EducationSystemContext esc = new EducationSystemContext())
            {
                foreach (var tmp in esc.Pupils)
                {
                    if (tmp.Idschool == idschool && tmp.NamberClass==number) { email.Add(tmp.Email); }
                }

            }
            return email;
        }

        public void UpdateTeacherData(string newname, string newsurname, string newpatr, string newpassword, string newphone, int newschool, int id)// обновление данных в учителя
        {
            using (EducationSystemContext esc = new EducationSystemContext())
            {
                esc.Database.ExecuteSqlRaw("update Teachers set Name={0}, Surname={1}, Patronymic={2}, Phone={3}, IDSchool={4}, Password={5} where IDTeacher={6}", newname,newsurname,newpatr,newphone,newschool,newpassword,id);
            }
        }
    }
}
