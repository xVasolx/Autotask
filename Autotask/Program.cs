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
            Cellulosity_Check_SHA256 _SHA256 = new Cellulosity_Check_SHA256();

            try
            {

                //В данном блоке планируется получать данные о пути с Web API 


            }
            catch (Cellulosity_Check_SHA256_Null_Exception ex)
            {
                Console.WriteLine("Cellulosity_Check_SHA256_Null_Exception: " + ex.Message);
            }






            Console.ReadLine();

        }
    }
}
