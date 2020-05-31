using System;
using System.Collections.Generic;

namespace Project
{
    public partial class Parents
    {
        // таблица данных родителей
        public Parents()
        {
            Pupils = new HashSet<Pupils>();
        }

        public int Idparent { get; set; }// номер родителей
        public string NameMather { get; set; }// имя мамы
        public string NameFather { get; set; }// имя папы
        public string SurnameMather { get; set; }// фамилия мамы
        public string SurnameFather { get; set; }// фамилия папы
        public string PatronymicMather { get; set; }// отчество мамы
        public string PatronymicFather { get; set; }// отчество папы
        public string PhoneMathe { get; set; }// номер мамы
        public string Email { get; set; }// майл
        public string Password { get; set; }// пароль
        public string PhoneFather { get; set; }// номер папы

        public virtual ICollection<Pupils> Pupils { get; set; }
    }
}
