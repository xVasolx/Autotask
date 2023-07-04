using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotask
{
    public class ReadAndParseJsonFileWithNewtonsoftJson
    {

        private readonly string jsonFile;
        public ReadAndParseJsonFileWithNewtonsoftJson(string jsonFile)
        {
            this.jsonFile = jsonFile;
        }

        public List<FileInfoDB> UseUserDefinedObjectWithNewtonsoftJson()
        {

            List<FileInfoDB> fileInfo = JsonConvert.DeserializeObject<List<FileInfoDB>>(jsonFile);
            return fileInfo;


            //using (StreamReader reader = new StreamReader(jsonFile))
            //{
            //    var json = reader.ReadToEnd();
            //    List<FileInfoDB> fileInfo = JsonConvert.DeserializeObject<List<FileInfoDB>>(jsonFile);
            //    return fileInfo;
            //}
        }

    }
}
