using System;
using System.Collections.Generic;

namespace Project
{
    public partial class Subject
    {
        public Subject()
        {
            Courses = new HashSet<Courses>();
        }

        public int Idsubject { get; set; }// номер предмета
        public string NamrSubject { get; set; }// название предмета

        public virtual ICollection<Courses> Courses { get; set; }
    }
}
