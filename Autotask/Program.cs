using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Autotask
{
    internal class Program
    {
        static void Main(string[] args)
        {// Создание HttpClientHandler с отключенной проверкой сертификата           
         //GetToken.GetTokenProjectAsync("123", "123");
         //GetToken.GetTokenFilesAsync("123", "123");

            //ProjectInfoDB projectInfoDB = new ProjectInfoDB() { project_Name = "LauncherProject1", projectVersion = "1.0.0" };
            //FileInfoDB fileInfoDB = new FileInfoDB() { file_Name = "file1", file_Version = "1.1" };

            //GetToken.SetTokenProjectNameAndFileVersion("123", "123", projectInfoDB, fileInfoDB);

            // List<ProjectInfoDB> projectInfoDBs = new List<ProjectInfoDB>();
            //GetToken.GetTokenProjectAsync("123", "123");
            //Thread.Sleep(2000);


            ConnectionToWebAPI.Run("123", "123");


            Console.Read();
        }      
    }
}
