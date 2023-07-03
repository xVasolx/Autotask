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
        private DirectoryInfo main_path;
        public List<string> directorys = new List<string>();
        public List<string> hash_file = new List<string>();
        public DirectoryInfo Main_path
        {
            get => main_path;
            set
            {
                if (value == null)
                {
                    throw new Cellulosity_Check_SHA256_Null_Exception("Папка не укаана, повторите попытку!");
                }
                else
                {
                    main_path = value;
                }

            }
        }



        public static void Hash(List<string> directorys, List<string> hash_file)
        {
            SHA256 sha256_hash = SHA256.Create();


            foreach (string file in directorys)
            {
                byte[] bytes = File.ReadAllBytes(file);
                byte[] hash_byte = sha256_hash.ComputeHash(bytes);
                string hash = BitConverter.ToString(hash_byte).Replace("-", string.Empty);
                hash_file.Add(hash);
            }


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
