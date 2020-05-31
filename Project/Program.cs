using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
// ��� �������� ��� � ���� ���� ���������� ���������� ��� ����� ������, �� � ��� ������� �� ��������� ����� ��� �� �������������
// ��������� �������� ��������� �� ������� https://localhost:44371/Login/LoginPage
//wwwroot - ��� ������ css, img, file, js
// � ����� ����� ���������� �� ������� bootstrap � ����������, ������� �� ������� �� ����
// Controllers - ��� ����������� 
//Data ��� ��������� ������ ��������������� � ������-�.�. ��
//View - ��� ������������� ��� ������������ �� ���� ���� �������� ��� ���� ����� ���� ��������, � Shared - ��������� ���� ��������, ���� ����� ���������� �����, ����� js � �.�.  

namespace Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        static public long code;// ��� ��� �����������
        static public string name;// ��� 
        static public string surname;//�������
        static public string patr;// ��������
        static public string phone;// �������
        static public int? idschool;// ����� �����
        static public int? idsubject;// ����� ��������
        static public string email;// �����
        static public string password;// ������ 
        static public int numberclass;// �����
        static public string nameF;// ��� ����
        static public string sunameF;// ������� ����
        static public string patrF;//�������� ����
        static public string phonF;// ����� ����
        static public int codep;//��� ��� ����������� ���������



        static public string enterlog;// ����� ��� �����
        static public string enterpassword;// ������ ��� �����
        static public Teachers datateacher;// ������ �������
        static public Pupils datapupils;// ������ ������� �� ��������
        static public Parents dataperants;// ������ �������� 

        static public int idcours;// id �����
        static public string namecours;// �������� �����

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
