using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.DataBaseModels
{
	public class VersionToFile
	{
		public int Id { get; set; }
		public int ProjectVersionId { get; set; }
		public ProjectVersion ProjectVersion { get; set; }
		public int ProjectFileId { get; set; }
		public ProjectFile ProjectFile { get; set; }
	}
}
