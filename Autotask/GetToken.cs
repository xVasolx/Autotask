using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Autotask
{
    internal class GetToken
    {
        private const string Domain_app = "https://localhost";
        private const string Port_app = ":5001";
        static HttpClientHandler handler = new HttpClientHandler();
        
        internal static bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) // Метод обратного вызова для проверки сертификата SSL/TLS
        {
            return true;// Всегда доверять сертификатам
        }


        public static async void TransferIdProjectAndIdVersion(string login, string password, FileInfoDB fileInfoDB, ProjectInfoDB projectInfoDB)
        {

        }

        public static async void SetTokenProjectNameAndFileVersion(string login, string password, ProjectInfoDB projectInfoDB, FileInfoDB fileInfoDB) 
        {
            handler.ServerCertificateCustomValidationCallback = ValidateCertificate;
            using (var client = new HttpClient(handler))
            {
                var response = client.PostAsync(Domain_app + Port_app + $"/api/Authorization/Login/login={login}/password={password}", null).Result;
                var result = response.Content.ReadAsStringAsync().Result;// Выполнение GET-запроса к API и получение ответа
                HttpResponseMessage response2 = await client.GetAsync(Domain_app + Port_app + $"/api/Query/GetFileForProject/fName={fileInfoDB.file_Name},fVersion={fileInfoDB.file_Version},pName={projectInfoDB.project_Name},pvName=/") ; //projectInfoDB.projectVersion
                
                if (response.IsSuccessStatusCode) //Проверка ответа
                {
                    var responseBody = await response2.Content.ReadAsStringAsync();// Получение содержимого ответа в виде строки      
                    Console.WriteLine("Ответ от сервера:"); // необязателдьные поля 

                    Console.WriteLine(responseBody); // необязателдьные поля 

                }
            }
        }

        public static async void GetTokenFilesAsync(string login, string password) //, ProjectInfoDB projectInfoDB, FileInfoDB fileInfoDB
        {
            handler.ServerCertificateCustomValidationCallback = ValidateCertificate;

            using (var client = new HttpClient(handler))
            {
                var response = client.PostAsync(Domain_app + Port_app + $"/api/Authorization/Login/login={login}/password={password}", null).Result;
                var result = response.Content.ReadAsStringAsync().Result;// Выполнение GET-запроса к API и получение ответа
                HttpResponseMessage response2 = await client.GetAsync(Domain_app + Port_app + "/api/Query/GetFile%D0%A1ollectionForProject/project_name=LauncherProject1,project_version_name=1.0.0"); // конкретный путь API
                if (response.IsSuccessStatusCode)// Проверка статуса ответа
                {
                    var responseBody = await response2.Content.ReadAsStringAsync();// Получение содержимого ответа в виде строки      
                    Console.WriteLine("Ответ от сервера:"); // необязателдьные поля 
                    Console.WriteLine(responseBody); // необязателдьные поля 

                    ReadAndParseJsonFileWithNewtonsoftJson files = new ReadAndParseJsonFileWithNewtonsoftJson(responseBody);
                    List<FileInfoDB> fileInfoDBs = files.UseUserDefinedObjectWithNewtonsoftJson();
                    bool checkSum = true;

                    foreach (var item in fileInfoDBs)
                    {
                        item.file_PatchToClient = item.file_PatchToClient.Replace("**", "C:\\Сбер\\") + item.file_Name + item.file_Extension;

                        Console.WriteLine("Id: " + item.id);
                        Console.WriteLine("File Name: " + item.file_Name);
                        Console.WriteLine("File Path: " + item.file_PatchToClient);



                        //    //ВАЖНО ДЛЯ ПОСЛЕДУЮЩЕГО ИСПОЛЬЗОВАНИЯ----------------------------------------------------------------

                        //    //checkSum = Cellulosity_Check_SHA256.Hash(item);
                        //    //if (checkSum != true)
                        //    //{
                        //    //    Console.WriteLine($"Файл был изменён! - {item.file_PatchToClient}");
                        //    //}
                        //    //else
                        //    //{
                        //    //    Console.WriteLine($"Файл прошёл проверку! - {item.file_PatchToClient}");
                        //    //}
                    }


                }

            }
        }

        public static async void GetProjectVersions(string login, string password, List<ProjectInfoDB> projectInfoDB )
        {
            
            using (var client = new HttpClient(handler))
            {
                var response = client.PostAsync(Domain_app + Port_app + $"/api/Authorization/Login/login={login}/password={password}", null).Result;
                var result = response.Content.ReadAsStringAsync().Result;// Выполнение GET-запроса к API и получение ответа
                foreach (var item in projectInfoDB)
                {
                    HttpResponseMessage response2 = await client.GetAsync(Domain_app + Port_app + $"/api/Query/GetProjectVersions/pId={item.id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response2.Content.ReadAsStringAsync();// Получение содержимого ответа в виде строки      
                        Console.WriteLine("Ответ от сервера:");
                        Console.WriteLine(responseBody);
                        List<VersionProjectInfoDB> root = JsonConvert.DeserializeObject<List<VersionProjectInfoDB>>(responseBody);

                        foreach (var item2 in root)
                        {

                            Console.WriteLine("Project Name: "  );


                        }

                    }
                }

                client.Dispose();
               

            }

        }

        public  static async void GetTokenProjectAsync(string login, string password)// получение токена
        {
            handler.ServerCertificateCustomValidationCallback = ValidateCertificate;
            using (var client = new HttpClient(handler))
            {
                var response = client.PostAsync(Domain_app + Port_app + $"/api/Authorization/Login/login={login}/password={password}", null).Result;
                var result = response.Content.ReadAsStringAsync().Result;// Выполнение GET-запроса к API и получение ответа
                HttpResponseMessage response2 = await client.GetAsync(Domain_app + Port_app + "/api/Query/GetAllProjectСollection"); // конкретный путь API
                if (response.IsSuccessStatusCode)// Проверка статуса ответа
                {
                    var responseBody = await response2.Content.ReadAsStringAsync();// Получение содержимого ответа в виде строки      
                    Console.WriteLine("Ответ от сервера:");
                    Console.WriteLine(responseBody);
                    ParseJson read = new ParseJson(responseBody);
                    List <ProjectInfoDB> root = read.UseUserDefinedObjectWithNewtonsoftJson();
                    foreach (var item in root)
                    {

                        Console.WriteLine("Project Name: " + item.project_Name);

                    
                    }

                    //foreach (var item in root)
                    //{

                    //}

                    //Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"Ошибка при выполнении запроса. Код статуса: {response.StatusCode}");
                    Console.ReadLine();
                }


                response2 = await client.GetAsync(Domain_app + Port_app + $"/api/Query/GetProjectVersions/pId=2");
                var responseBody2 =  await response2.Content.ReadAsStringAsync();





            }
        }
    }
}
