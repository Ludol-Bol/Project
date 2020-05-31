using System;
using System.Collections.Generic;

namespace Project
{
    public partial class School
    {
        public School()
        {
            Courses = new HashSet<Courses>();
            Pupils = new HashSet<Pupils>();
        }

        public int Idschool { get; set; }// номер школы
        public string NameSchool { get; set; }// название

        public virtual ICollection<Courses> Courses { get; set; }
        public virtual ICollection<Pupils> Pupils { get; set; }
    }
}
