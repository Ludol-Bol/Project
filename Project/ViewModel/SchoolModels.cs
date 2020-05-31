using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Project.ViewModel
{
    public class SchoolModels// модель школа и предемты
    {
        public IEnumerable<School> schools { get; set; }
        public IEnumerable<Subject> subjects { get; set; }

       

    }
}
