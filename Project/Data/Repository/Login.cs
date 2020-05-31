using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Data.Repository
{// класс для входа в аккаунт 
    public class Login
    {
        string _login;// логин он же email
        string _password;// пароль

        string login
        {
            get { return _login; }
            set { _login = value; }
        }

        string password
        {
            get { return _password; }
            set { if (value.Length > 0 && value.Length < 50) _password = value; }
        }

        public Login(string login, string password)// конструктор
        {
            this.login = login;
            this.password = password;
        }

        public int[] EnterUser()// вход на страницу возвращаем массив где первое значение это id пользователя, а второе значение это тип аккаунта 1-учитель 2-ученик 3-родитель 
        {
            bool flagexists = false;
            int[] masind = new int[2];
            WorkDB db = new WorkDB();
            masind[0] = 0; masind[1] = 0;
            List<Teachers> teachers = db.GetTeachers();
            for (int i = 0; i < teachers.Count; i++)
            {
                if (teachers[i].Email == login && teachers[i].Password == password)
                {

                    masind[0] = teachers[i].Idteacher;
                    masind[1] = 1;
                    flagexists = true;
                    break;
                }
            }
            if (flagexists == false)
            {
                List<Pupils> pupil = new List<Pupils>();
                for (int i = 0; i < pupil.Count; i++)
                {
                    if (pupil[i].Email == login && pupil[i].Password == password)
                    {
                        flagexists = true;
                        masind[0] = pupil[i].Idpupil;
                        masind[1] = 2;
                        break;
                    }
                }
            }
            if (flagexists == false)
            {
                List<Parents> parents = new List<Parents>();
                for (int i = 0; i < parents.Count; i++)
                {
                    if (parents[i].Email == login && parents[i].Password == password)
                    {
                        flagexists = true;
                        masind[0] = parents[i].Idparent;
                        masind[1] = 3;
                        break;
                    }
                }
            }
            if (flagexists == false) { masind[0] = 0; masind[1] = 0; }
            return masind;
        }

    }
}
