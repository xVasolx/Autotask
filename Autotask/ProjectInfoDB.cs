﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Autotask
{
    internal class ProjectInfoDB
    {

        public int id { get; set; }
        public string project_Name { get; set; }
        public string project_Description { get; set; }
        public string project_Owner { get; set; }
        public string project_DateAdd { get; set; }
        //public string projectVersion { get; set; } //  public object[] projectVersion { get; set; }  public string projectVersion { get; set; }
        

    }
}
