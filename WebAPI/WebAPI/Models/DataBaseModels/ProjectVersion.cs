using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.DataBaseModels
{
	public class ProjectVersion
	{
		public ProjectVersion()
		{
			VersionToFile = new List<VersionToFile>();
		}

		public int Id { get; set; }
		public string Version_Name { get; set; }
		public string Version_Description { get; set; }
		public int LauncherProjectId { get; set; }
		public LauncherProject LauncherProject { get; set; }
		public List<VersionToFile> VersionToFile { get; set; }

		public DateTime Version_DateAdd { get; set; }
	}
}
