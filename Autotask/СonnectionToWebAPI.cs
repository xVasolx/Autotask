using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Autotask
{
    public class ConnectionToWebAPI
    {
        private const string Domain_app = "https://localhost";
        private const string Port_app = ":5001";
        static HttpClientHandler handler = new HttpClientHandler();

        internal static bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) // Метод обратного вызова для проверки сертификата SSL/TLS
        {
            return true;// Всегда доверять сертификатам
        }

        public static async void Run(string login, string password)
        {
            handler.ServerCertificateCustomValidationCallback = ValidateCertificate;
            using (var client = new HttpClient(handler))
            {
                var response = client.PostAsync(Domain_app + Port_app + $"/api/Authorization/Login/login={login}/password={password}", null).Result;
                
                HttpResponseMessage response2 = await client.GetAsync(Domain_app + Port_app + "/api/Query/GetAllProjectСollection"); // конкретный путь API
                if (response.IsSuccessStatusCode)
                {
                    
                    var responseBody = await response2.Content.ReadAsStringAsync();// Получение содержимого ответа в виде строки      
                    List<ProjectInfoDB> projectInfoDBs = JsonConvert.DeserializeObject<List<ProjectInfoDB>>(responseBody);
                    
                    foreach (var item in projectInfoDBs)
                    {

                        Console.WriteLine("Project Name: " + item.project_Name);
                        Console.WriteLine("Project Id: " + item.id);

                        response2 = await client.GetAsync(Domain_app + Port_app + $"/api/Query/GetProjectVersions/pId={item.id}");
                        responseBody = await response2.Content.ReadAsStringAsync();// Получение содержимого ответа в виде строки
                        List<VersionProjectInfoDB> versionProjectInfoDBs = JsonConvert.DeserializeObject<List<VersionProjectInfoDB>>(responseBody);
                        foreach (var item2 in versionProjectInfoDBs)
                        {
                            Console.WriteLine($"     -{item2.version_Name}");
                        }

                    }

                    response2 = await client.GetAsync(Domain_app + Port_app + $"/api/Query/GetFileСollectionForProject/project_name=LauncherProject1,project_version_name=1.0.0");
                    responseBody = await response2.Content.ReadAsStringAsync();// Получение содержимого ответа в виде строки
                    List<FileInfoDB> fileInfoDBs = JsonConvert.DeserializeObject<List<FileInfoDB>>(responseBody);

                    bool checkSum = true;

                    foreach (var item in fileInfoDBs)
                    {
                        item.file_PatchToClient = item.file_PatchToClient.Replace("**", "C:\\Сбер\\") + item.file_Name + item.file_Extension;
                        checkSum = Cellulosity_Check_SHA256.Hash(item);

                        if (checkSum != true)
                        {
                            Console.WriteLine($"Файл был изменён или отсутвует! - {item.file_PatchToClient}");
                        }
                        else
                        {
                            Console.WriteLine($"Файл прошёл проверку! - {item.file_PatchToClient}");
                        }

                       

                    }

                }
                else
                {
                    Console.WriteLine($"Ошибка при выполнении запроса. Код статуса: {response.StatusCode}");
                    Console.ReadLine();
                }


            }


        }



    }
}
