using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

// панель управления хостингом https://cp.sprinthost.ru можно зайти и посмотреть
// имя пользователя хостинг f0442011
// пароль uztuasismi
namespace Project.Data.Repository
{// класс работв с хостингом 
    public class WorkHosting
    {
        public void CreatCourse(string name)// cоздает папку на хостинге где будут храниться материалы урока
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://141.8.193.236/" + name);
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            request.Credentials = new NetworkCredential("f0442011", "uztuasismi");
            using (var resp = (FtpWebResponse)request.GetResponse())
            {
                 //string s = resp.StatusCode.ToString();
            }
        }

        public void CreateFilesLesson(string namefile, string namelesson, IFormFile pathfile, string links, string text, int countlesson)// создаем файлы урока
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://141.8.193.236/" + namefile + "/"+namelesson+"_"+countlesson);
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            request.Credentials = new NetworkCredential("f0442011", "uztuasismi");
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            //загружаем файл
            string path = @"C:\Users\Люда\Desktop\Крсовая 3 курс\Project\Project\wwwroot\file\" + countlesson+"_"+pathfile.FileName;
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                pathfile.CopyToAsync(fileStream);
            }
            FtpWebRequest request_1 = (FtpWebRequest)WebRequest.Create("ftp://141.8.193.236/" + namefile + "/" +   countlesson + "_" + pathfile.FileName );
            request_1.Credentials = new NetworkCredential("f0442011", "uztuasismi");
            request_1.Method = WebRequestMethods.Ftp.UploadFile;
            FileStream fs_1 = new FileStream(path, FileMode.Open);
            byte[] fileContents_1 = new byte[fs_1.Length];
            fs_1.Read(fileContents_1, 0, fileContents_1.Length);
            fs_1.Close();
            request_1.ContentLength = fileContents_1.Length;
            Stream requestStream_1 = request_1.GetRequestStream();
            requestStream_1.Write(fileContents_1, 0, fileContents_1.Length);
            requestStream_1.Close();
            FtpWebResponse response_0 = (FtpWebResponse)request_1.GetResponse();
            File.Delete(path);
            //загружаем текстовый файл с информацией
            string writePath = "Info" + countlesson + ".txt";
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(text);
            }
            FtpWebRequest request_2 = (FtpWebRequest)WebRequest.Create("ftp://141.8.193.236/" + namefile + "/" + namelesson + "_" + countlesson +"_"+ writePath);
            request_2.Credentials = new NetworkCredential("f0442011", "uztuasismi");
            request_2.Method = WebRequestMethods.Ftp.UploadFile;
            FileStream fs = new FileStream(writePath, FileMode.Open);
            byte[] fileContents = new byte[fs.Length];
            fs.Read(fileContents, 0, fileContents.Length);
            fs.Close();
            request_2.ContentLength = fileContents.Length;
            Stream requestStream = request_2.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();
            FtpWebResponse response_1 = (FtpWebResponse)request_2.GetResponse();
            File.Delete(writePath);
            // загружаем файл с ссылкой на видео
            string linkpath = "Link" + countlesson + ".txt";
            using (StreamWriter sw_3 = new StreamWriter(linkpath, false, System.Text.Encoding.Default))
            {
                sw_3.WriteLine(links);
            }
            FtpWebRequest request_3 = (FtpWebRequest)WebRequest.Create("ftp://141.8.193.236/" + namefile + "/" + namelesson + "_" + countlesson + "_" + linkpath);
            request_3.Credentials = new NetworkCredential("f0442011", "uztuasismi");
            request_3.Method = WebRequestMethods.Ftp.UploadFile;
            FileStream fs_3 = new FileStream(linkpath, FileMode.Open);
            byte[] fileContents_3 = new byte[fs_3.Length];
            fs_3.Read(fileContents_3, 0, fileContents_3.Length);
            fs_3.Close();
            request_3.ContentLength = fileContents_3.Length;
            Stream requestStream_3 = request_3.GetRequestStream();
            requestStream_3.Write(fileContents_3, 0, fileContents_3.Length);
            requestStream_3.Close();
            FtpWebResponse response_3 = (FtpWebResponse)request_3.GetResponse();
            File.Delete(linkpath);


        }

        public void DeleteDirectoryCourses(string name)// удаляем файлы и папку с курсом 
        {
            FtpWebRequest request_3 = (FtpWebRequest)WebRequest.Create("ftp://141.8.193.236/" + name );
            request_3.Credentials = new NetworkCredential("f0442011", "uztuasismi");
            request_3.Method = WebRequestMethods.Ftp.ListDirectory;
            FtpWebResponse response_3 = (FtpWebResponse)request_3.GetResponse();
            Stream responseStream = response_3.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string res = reader.ReadToEnd();
            // res = res.Replace("\r\n",)
            string[] masfilenam = res.Split("\r\n");
            for(int i=0;i<masfilenam.Length;i++)
            {
                if(masfilenam[i].Length>3)
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://141.8.193.236/" + name+"/"+masfilenam[i]);
                    request.Credentials = new NetworkCredential("f0442011", "uztuasismi");
                    request.Method = WebRequestMethods.Ftp.DeleteFile;
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    Stream responseStream_f = response.GetResponseStream();
                }
            }
            FtpWebRequest request_2 = (FtpWebRequest)WebRequest.Create("ftp://141.8.193.236/" + name);
            request_2.Credentials = new NetworkCredential("f0442011", "uztuasismi");
            request_2.Method = WebRequestMethods.Ftp.RemoveDirectory;
            FtpWebResponse response_2 = (FtpWebResponse)request_2.GetResponse();
            Stream responseStream_fd = response_2.GetResponseStream();
        }
    }
}
