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
        public List<FieldsJson> UseUserDefinedObjectWithNewtonsoftJson()
        {
            List<FieldsJson> fileInfo = JsonConvert.DeserializeObject<List<FieldsJson>>(jsonFile);
            return fileInfo;
        }
    }
}
