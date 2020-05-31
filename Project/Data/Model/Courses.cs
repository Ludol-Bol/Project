using System;
using System.Collections.Generic;

namespace Project
{
    // таблица курсов 
    public partial class Courses
    {
        public int Idcourse { get; set; }// номер курса
        public int Idteachers { get; set; } // номер учитетеля, который открыл курс
        public string Name { get; set; } // название курса
        public int Idsubgect { get; set; } // номер предмета к которому отосится этот курс
        public int Idschool { get; set; }// номер школы
        public int NamberClass { get; set; }// номер класс для которого открыт этот курс
        public int CountLessons { get; set; }// количество уроков

        public virtual School IdschoolNavigation { get; set; }
        public virtual Subject IdsubgectNavigation { get; set; }
        public virtual Teachers IdteachersNavigation { get; set; }
    }
}
