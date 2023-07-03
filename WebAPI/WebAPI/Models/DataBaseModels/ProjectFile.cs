using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.DataBaseModels
{
	public class ProjectFile
	{
		public ProjectFile()
		{
			VersionToFile = new List<VersionToFile>();
		}

		public int Id { get; set; }
		public string File_Name { get; set; }
		public string File_Description { get; set; }
		public string File_Extension { get; set; }
		public string File_PatchToClient { get; set; }
		public string File_PhysicalPatch { get; set; }
		public string File_CheckSum { get; set; }
		public DateTime File_DateAdd { get; set; }
		public string File_Version { get; set; }
		public List<VersionToFile> VersionToFile { get; set; }
	}
}
