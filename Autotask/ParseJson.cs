using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotask
{
    internal class ParseJson
    {
        private readonly string jsonFile;
        public ParseJson(string jsonFile)
        {
            this.jsonFile = jsonFile;
        }
        public List<ProjectInfoDB> UseUserDefinedObjectWithNewtonsoftJson()
        {
            List<ProjectInfoDB> fileInfo = JsonConvert.DeserializeObject<List<ProjectInfoDB>>(jsonFile);
            return fileInfo;
        }
    }
}
