using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Models.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class QueryController : Controller
	{
		private DBContext _context;

		public QueryController(DBContext context)
		{
			_context = context;
		}

		[HttpGet("GetProject/id={id}")]
		public ActionResult GetProject(int id)
		{
			IQueryable<LauncherProject> launcherProjects = _context.LauncherProject;
			List<LauncherProject> searchProjects = launcherProjects.Where(p =>
					(p.Id.Equals(id))).ToList();

			if (searchProjects.Count() != 0)
			{
				LauncherProject resultProject = searchProjects[0];
				return Ok(resultProject);
			}
			else
				return NoContent();
				
		}
		[HttpGet("GetProjectByName/name={name}")]
		public ActionResult GetProjectByName(string name)
		{
			IQueryable<LauncherProject> launcherProjects = _context.LauncherProject;
			List<LauncherProject> searchProjects = launcherProjects.Where(p =>
					(p.Project_Name.Contains(name))).ToList();

			if (searchProjects.Count() != 0)
			{
				LauncherProject resultProject = searchProjects[0];
				return Ok(resultProject);
			}
			else
				return NoContent();

		}

		[HttpGet("GetProjectСollection/firstIndex={firstIndex},lastIndex={lastIndex}")]
		public ActionResult GetProjectСollection(double firstIndex, double lastIndex)
		{
			IQueryable<LauncherProject> launcherProjects = _context.LauncherProject;
			List<LauncherProject> resultProjects = launcherProjects.Where(p =>
					(p.Id >= firstIndex)&&(p.Id <= lastIndex)).ToList();
			if (resultProjects.Count() != 0)
				return Ok(resultProjects.ToArray());
			else
				return NoContent();
		}

		[HttpGet("GetAllProjectСollection/")]
		public ActionResult GetAllProjectСollection()
		{
			IQueryable<LauncherProject> launcherProjects = _context.LauncherProject;
			List<LauncherProject> resultProjects = launcherProjects.ToList();
			return Ok(resultProjects.ToArray());
		}

		[HttpGet("GetFileСollectionForProject/project_name={pname},project_version_name={vname}")]
		public ActionResult GetFileСollectionForProject(string pname, string vname)
		{
			IQueryable<LauncherProject> searchProject = _context.LauncherProject
				.Where(p => p.Project_Name.Equals(pname));

			IQueryable<ProjectVersion> searchProjectVersion = _context.ProjectVersion
				.Where(v => v.LauncherProjectId.Equals(searchProject.ToList()[0].Id) && v.Version_Name.Equals(vname));

			IQueryable<VersionToFile> searchVersionToFiles = _context.VersionToFile
				.Where(vf => vf.ProjectVersionId.Equals(searchProjectVersion.ToList()[0].Id))
				.Select(t => new VersionToFile
				{
					ProjectFileId = t.ProjectFileId,
					ProjectVersionId = t.ProjectVersionId
				});

			List<ProjectFile> searchProjectFiles = new List<ProjectFile>();
			foreach (var vt in searchVersionToFiles.ToList())
			{
				IQueryable<ProjectFile> projectFiles = _context.ProjectFile
				.Where(f => f.Id.Equals(vt.ProjectFileId))
				.Select(t => new ProjectFile
				{
					Id = t.Id,
					File_Name = t.File_Name,
					File_Description = t.File_Description,
					File_Extension = t.File_Extension,
					File_PatchToClient = t.File_PatchToClient,
					File_PhysicalPatch = t.File_PhysicalPatch,
					File_CheckSum = t.File_CheckSum,
					File_DateAdd = t.File_DateAdd,
					File_Version = t.File_Version
				});

				
				searchProjectFiles.AddRange(projectFiles.ToList());
			}
			return Ok(searchProjectFiles.ToArray());
		}


		[HttpPost("LoadProject/")]//TODO
		public ActionResult LoadProject()
		{
			return null;
		}
		
	}
}
