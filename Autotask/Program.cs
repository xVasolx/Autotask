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
    {
        static void Main(string[] args)
        {// Создание HttpClientHandler с отключенной проверкой сертификата           
            GetToken.GetTokenDictionaryAsync("123", "123");
            Console.Read();
        }      
    }
}
