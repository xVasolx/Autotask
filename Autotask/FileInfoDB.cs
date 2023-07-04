using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotask
{
    public class FileInfoDB
    {

        public string id { get; set; }
        public string file_Name { get; set; }
        public string file_Description { get; set; }
        public string file_Extension { get; set; } 
        public string file_PatchToClient { get; set; }
        public string file_PhysicalPatch { get; set; }
        public string file_CheckSum { get; set; }
        public string file_DateAdd { get; set; }
        public string file_Version { get; set; }

        

    }
}
