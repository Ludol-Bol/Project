using System;
using System.Collections.Generic;

namespace Project
{
    public partial class Teachers
    {
        public Teachers()
        {
            Courses = new HashSet<Courses>();
        }

        public int Idteacher { get; set; }// номер учителя 
        public string Name { get; set; }// имя
        public string Surname { get; set; }// фамилия
        public string Patronymic { get; set; }// отчество
        public string Phone { get; set; }// телефон
        public int? Idschool { get; set; }// номер школы
        public int? Idsubject { get; set; }// номер предмета
        public string Email { get; set; }// почта
        public string Password { get; set; }// пароль 

        public virtual ICollection<Courses> Courses { get; set; }
    }
}
