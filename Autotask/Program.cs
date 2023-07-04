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
    internal class Program
    {//api/Authorization/Login/login=123/password=123
        private const string APP_PATH = "https://26.78.251.190:5001";
        static HttpClientHandler handler = new HttpClientHandler();
        static void Main(string[] args)
        {// Создание HttpClientHandler с отключенной проверкой сертификата
            handler.ServerCertificateCustomValidationCallback = ValidateCertificate;
            GetTokenDictionaryAsync("123", "123");
            Console.Read();
        }
        static async void GetTokenDictionaryAsync(string login, string password)// получение токена
        {
            using (var client = new HttpClient(handler))
            {
                var response = client.PostAsync(APP_PATH + $"/api/Authorization/Login/login={login}/password={password}", null).Result;
                var result = response.Content.ReadAsStringAsync().Result;// Выполнение GET-запроса к API и получение ответа
                HttpResponseMessage response2 = await client.GetAsync("https://26.78.251.190:5001/api/Query/GetAllProjectСollection"); // конкретный путь API
                if (response.IsSuccessStatusCode)// Проверка статуса ответа
                {
                    var responseBody = await response2.Content.ReadAsStringAsync();// Получение содержимого ответа в виде строки      
                    Console.WriteLine("Ответ от сервера:");
                    Console.WriteLine(responseBody);
                    ParseJson read = new ParseJson(responseBody);
                    List<FieldsJson> root = read.UseUserDefinedObjectWithNewtonsoftJson();
                    foreach (var item in root)
                    {
                        Console.WriteLine("Id: " + item.id);
                        Console.WriteLine("Project Name: " + item.project_Name);
                        Console.WriteLine("Project Description: " + item.project_Description);
                        Console.WriteLine("Project Owner: " + item.project_Owner);
                        Console.WriteLine("Project Date Add: " + item.project_DateAdd);
                        // Console.WriteLine("Project version: " + item.projectVersion);
                    }
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"Ошибка при выполнении запроса. Код статуса: {response.StatusCode}");
                    Console.ReadLine();
                }
            }
        }
        private static bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) // Метод обратного вызова для проверки сертификата SSL/TLS
        {
            return true;// Всегда доверять сертификатам
        }
    }
}
