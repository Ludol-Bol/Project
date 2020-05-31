using System;
using System.Collections.Generic;

namespace Project
{
    public partial class Pupils
    {
        public int Idpupil { get; set; }// номер учинека
        public string Name { get; set; }// его имя
        public string Surname { get; set; }// фамилия
        public string Patronymic { get; set; }// отчество
        public int? Idschool { get; set; }// номер школы
        public int NamberClass { get; set; }// класс
        public string Phone { get; set; }// телефон
        public string Email { get; set; }// майл
        public string Password { get; set; }// пароль
        public int Code { get; set; }// код, пока не знаю остнется это поле, но пусть будет
        public int? Idparent { get; set; }// номер родителей

        public virtual Parents IdparentNavigation { get; set; }
        public virtual School IdschoolNavigation { get; set; }
    }
}
