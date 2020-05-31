using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
// Это программ тут у меня есть глобальные переменные так плохо делать, но я чет другого не придумала кроме как их использования
// Начальная страница находится по адрессу https://localhost:44371/Login/LoginPage
//wwwroot - это данные css, img, file, js
// к сайту можно подключить по желанию bootstrap и фреймворки, которые мы изучали на вебе
// Controllers - тут контроллеры 
//Data тут различные классы всмомогательные и модель-т.е. бд
//View - это предтавляения для контроллеров то есть наши страницы там лишь часть кода страницы, в Shared - находятся сами страницы, куда можно подключать стили, файлы js и т.п.  

namespace Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        static public long code;// код для регестрации
        static public string name;// имя 
        static public string surname;//фамилия
        static public string patr;// отчество
        static public string phone;// телефон
        static public int? idschool;// номер школы
        static public int? idsubject;// номер предмета
        static public string email;// почта
        static public string password;// пароль 
        static public int numberclass;// класс
        static public string nameF;// имя отца
        static public string sunameF;// фамилия отца
        static public string patrF;//отчетсво отца
        static public string phonF;// номер отца
        static public int codep;//код для регистрации родителей



        static public string enterlog;// логин для входа
        static public string enterpassword;// пароль для входа
        static public Teachers datateacher;// данные учителя
        static public Pupils datapupils;// данные ученика на странице
        static public Parents dataperants;// данные родителя 

        static public int idcours;// id курса
        static public string namecours;// название курса

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
