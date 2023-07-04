using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotask
{
    public class Program
    {
        

        static void Main(string[] args)

        {


            ReadAndParseJsonFileWithNewtonsoftJson jsonFile = new ReadAndParseJsonFileWithNewtonsoftJson("D:\\Путь проекта.json");

            List<FileInfoDB> files = jsonFile.UseUserDefinedObjectWithNewtonsoftJson();
            bool checkSum = true;

            foreach (var item in files)
            {
                item.file_PatchToClient = item.file_PatchToClient.Replace("**", "C:\\Сбер\\") + item.file_Name + item.file_Extension;
                checkSum = Cellulosity_Check_SHA256.Hash(item);

                if (checkSum != true)
                {
                    Console.WriteLine($"Файл был изменён! - {item.file_PatchToClient}");
                }
                else
                {
                    Console.WriteLine($"Файл прошёл проверку! - {item.file_PatchToClient}");
                }
            }




            //----------------------------------------------------------------------------------

            //foreach (var item in files)
            //{
            //    //Console.WriteLine("|" + "Имя: " + item.file_Name + "|" + " Расширение: " + item.file_Extension + "|" + " Путь на клиентской машине:" + item.file_PatchToClient + "|" + " Контррольная сумма:" + item.file_CheckSum);
            //    Console.WriteLine(item.file_PatchToClient);

            //}


            //------------------------------------------------------------------------------------

            //Cellulosity_Check_SHA256 _SHA256 = new Cellulosity_Check_SHA256();

            //_SHA256.Main_path = new DirectoryInfo("C:\\Сбер\\Тестовые файлы");


            //Cellulosity_Check_SHA256.Recursive_search(_SHA256.Main_path, _SHA256.directorys);

            //foreach (var a in _SHA256.directorys)
            //{
            //    Console.WriteLine(a);
            //}

            //Cellulosity_Check_SHA256.Hash(_SHA256.directorys, _SHA256.hash_file);

            //foreach (var a in _SHA256.hash_file)
            //{
            //    Console.WriteLine(a);
            //}


            //-----------------------------------------------------------------------------------

            //try
            //{

            //    //В данном блоке планируется получать данные о пути с Web API 


            //}
            //catch(Cellulosity_Check_SHA256_Null_Exception ex)
            //{
            //    Console.WriteLine("Cellulosity_Check_SHA256_Null_Exception: " + ex.Message);
            //}






            Console.ReadLine();

        }
    }
}
