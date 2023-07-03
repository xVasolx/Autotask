using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.DataBaseModels
{
	public class LauncherProject
	{
		public LauncherProject()
		{
			ProjectVersion = new List<ProjectVersion>();
		}
		public int Id { get; set; }
		public string Project_Name { get; set; }
		public string Project_Description { get; set; }
		public string Project_Owner { get; set; }
		public DateTime Project_DateAdd { get; set; }
		public List<ProjectVersion> ProjectVersion { get; set; }
	}
}
