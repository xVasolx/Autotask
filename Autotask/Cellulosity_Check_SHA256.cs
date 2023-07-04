using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Autotask
{


    class Cellulosity_Check_SHA256_Null_Exception : ArgumentException
    {
        public Cellulosity_Check_SHA256_Null_Exception(string massage)
            : base(massage) { }
    }

  

    internal class Cellulosity_Check_SHA256
    {
        private DirectoryInfo path_to_file { get; set; }
        public string Directory { get; set; }
        public string Hash_file { get; set; }
       



        public static bool Hash(FileInfoDB fileInfoDB)
        {
            SHA256 sha256_hash = SHA256.Create();
            bool CheckSum = true;

            byte[] bytes = File.ReadAllBytes(fileInfoDB.file_PatchToClient);
            byte[] hash_byte = sha256_hash.ComputeHash(bytes);
            string hash = BitConverter.ToString(hash_byte).Replace("-", string.Empty);

            if(hash != fileInfoDB.file_CheckSum)
            {
                CheckSum = false;
            }

            return CheckSum;
            


        }


        public static void Recursive_search(DirectoryInfo main_path, List<string> directorys)
        {
            DirectoryInfo[] subDirectoryInfo = null;
            FileInfo[] filesInfo = null;

            try
            {
                filesInfo = main_path.GetFiles();
            }
            catch
            {

            }

            if (filesInfo != null)
            {

                foreach (FileInfo path in filesInfo)
                {
                    directorys.Add(Convert.ToString(path.FullName));
                }

                subDirectoryInfo = main_path.GetDirectories();

                foreach (DirectoryInfo dir in subDirectoryInfo)
                {
                    Recursive_search(dir, directorys);
                }

            }

        }


    }
}
