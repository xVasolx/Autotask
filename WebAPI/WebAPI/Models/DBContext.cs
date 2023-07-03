using WebAPI.Models.DataBaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;

namespace WebAPI.Models
{
	public class DBContext : DbContext
	{
		public DbSet<LauncherProject> LauncherProject { get; set; }
		public DbSet<ProjectVersion> ProjectVersion { get; set; }
		public DbSet<VersionToFile> VersionToFile { get; set; }
		public DbSet<ProjectFile> ProjectFile { get; set; }

		public DBContext(DbContextOptions<DBContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// добавляем роли и администратора
			LauncherProject launcherProject1 = new LauncherProject { Id = 1, Project_Name = "LauncherProject1", Project_DateAdd = DateTime.Now, Project_Description = "Проект еще в стадии разработки!", Project_Owner = "Бикита Нуянов" };
			LauncherProject launcherProject2 = new LauncherProject { Id = 2, Project_Name = "LauncherProject2", Project_DateAdd = DateTime.Now, Project_Description = "Проект еще в стадии разработки!", Project_Owner = "Бикита Нуянов" };
			LauncherProject launcherProject3 = new LauncherProject { Id = 3, Project_Name = "Project3", Project_DateAdd = DateTime.Now, Project_Description = "Проект еще в стадии разработки!", Project_Owner = "Бикита Нуянов" };

			ProjectVersion version1 = new ProjectVersion { Id = 1, LauncherProjectId = 1, Version_DateAdd = DateTime.Now, Version_Description = "Версия еще в стадии разработки!", Version_Name = "1.0.0" };
			ProjectVersion version2 = new ProjectVersion { Id = 2, LauncherProjectId = 1, Version_DateAdd = DateTime.Now, Version_Description = "Версия еще в стадии разработки!", Version_Name = "1.1.1" };
			ProjectVersion version3 = new ProjectVersion { Id = 3, LauncherProjectId = 2, Version_DateAdd = DateTime.Now, Version_Description = "Версия еще в стадии разработки!", Version_Name = "2.1.3" };
			ProjectVersion version4 = new ProjectVersion { Id = 4, LauncherProjectId = 2, Version_DateAdd = DateTime.Now, Version_Description = "Версия еще в стадии разработки!", Version_Name = "1.3.2" };
			ProjectVersion version5 = new ProjectVersion { Id = 5, LauncherProjectId = 3, Version_DateAdd = DateTime.Now, Version_Description = "Версия еще в стадии разработки!", Version_Name = "2.4.3" };
			ProjectVersion version6 = new ProjectVersion { Id = 6, LauncherProjectId = 3, Version_DateAdd = DateTime.Now, Version_Description = "Версия еще в стадии разработки!", Version_Name = "3.2.2" };

			ProjectFile projectFile1 = new ProjectFile { Id = 1, File_CheckSum = "123", File_DateAdd = DateTime.Now, File_Description = "Файл еще в стадии разработки!", File_Extension = ".exe", File_Name = "file1", File_PatchToClient = "patchToClient", File_PhysicalPatch = "physicalPatch", File_Version = "1.1" };
			ProjectFile projectFile2 = new ProjectFile { Id = 2, File_CheckSum = "123", File_DateAdd = DateTime.Now, File_Description = "Файл еще в стадии разработки!", File_Extension = ".bat", File_Name = "file2", File_PatchToClient = "patchToClient", File_PhysicalPatch = "physicalPatch", File_Version = "1.2" };
			ProjectFile projectFile3 = new ProjectFile { Id = 3, File_CheckSum = "123", File_DateAdd = DateTime.Now, File_Description = "Файл еще в стадии разработки!", File_Extension = ".exe", File_Name = "file3", File_PatchToClient = "patchToClient", File_PhysicalPatch = "physicalPatch", File_Version = "1.5" };
			ProjectFile projectFile4 = new ProjectFile { Id = 4, File_CheckSum = "123", File_DateAdd = DateTime.Now, File_Description = "Файл еще в стадии разработки!", File_Extension = ".sus", File_Name = "file4", File_PatchToClient = "patchToClient", File_PhysicalPatch = "physicalPatch", File_Version = "3.1" };
			ProjectFile projectFile5 = new ProjectFile { Id = 5, File_CheckSum = "123", File_DateAdd = DateTime.Now, File_Description = "Файл еще в стадии разработки!", File_Extension = ".dll", File_Name = "file5", File_PatchToClient = "patchToClient", File_PhysicalPatch = "physicalPatch", File_Version = "1.2" };
			ProjectFile projectFile6 = new ProjectFile { Id = 6, File_CheckSum = "123", File_DateAdd = DateTime.Now, File_Description = "Файл еще в стадии разработки!", File_Extension = ".exe", File_Name = "file6", File_PatchToClient = "patchToClient", File_PhysicalPatch = "physicalPatch", File_Version = "1.4" };
			ProjectFile projectFile7 = new ProjectFile { Id = 7, File_CheckSum = "123", File_DateAdd = DateTime.Now, File_Description = "Файл еще в стадии разработки!", File_Extension = ".exe", File_Name = "file7", File_PatchToClient = "patchToClient", File_PhysicalPatch = "physicalPatch", File_Version = "1.1" };
			ProjectFile projectFile8 = new ProjectFile { Id = 8, File_CheckSum = "123", File_DateAdd = DateTime.Now, File_Description = "Файл еще в стадии разработки!", File_Extension = ".bat", File_Name = "file8", File_PatchToClient = "patchToClient", File_PhysicalPatch = "physicalPatch", File_Version = "1.2" };
			ProjectFile projectFile9 = new ProjectFile { Id = 9, File_CheckSum = "123", File_DateAdd = DateTime.Now, File_Description = "Файл еще в стадии разработки!", File_Extension = ".exe", File_Name = "file9", File_PatchToClient = "patchToClient", File_PhysicalPatch = "physicalPatch", File_Version = "1.5" };
			ProjectFile projectFile10 = new ProjectFile { Id = 10, File_CheckSum = "123", File_DateAdd = DateTime.Now, File_Description = "Файл еще в стадии разработки!", File_Extension = ".sus", File_Name = "file10", File_PatchToClient = "patchToClient", File_PhysicalPatch = "physicalPatch", File_Version = "3.1" };
			ProjectFile projectFile11 = new ProjectFile { Id = 11, File_CheckSum = "123", File_DateAdd = DateTime.Now, File_Description = "Файл еще в стадии разработки!", File_Extension = ".dll", File_Name = "file11", File_PatchToClient = "patchToClient", File_PhysicalPatch = "physicalPatch", File_Version = "1.2" };
			ProjectFile projectFile12 = new ProjectFile { Id = 12, File_CheckSum = "123", File_DateAdd = DateTime.Now, File_Description = "Файл еще в стадии разработки!", File_Extension = ".exe", File_Name = "file12", File_PatchToClient = "patchToClient", File_PhysicalPatch = "physicalPatch", File_Version = "1.4" };

			VersionToFile versionToFile1 = new VersionToFile { Id = 1, ProjectVersionId = 1, ProjectFileId = 1 };
			VersionToFile versionToFile2 = new VersionToFile { Id = 2, ProjectVersionId = 1, ProjectFileId = 2 };
			VersionToFile versionToFile3 = new VersionToFile { Id = 3, ProjectVersionId = 2, ProjectFileId = 3 };
			VersionToFile versionToFile4 = new VersionToFile { Id = 4, ProjectVersionId = 2, ProjectFileId = 4 };
			VersionToFile versionToFile5 = new VersionToFile { Id = 5, ProjectVersionId = 3, ProjectFileId = 5 };
			VersionToFile versionToFile6 = new VersionToFile { Id = 6, ProjectVersionId = 3, ProjectFileId = 6 };
			VersionToFile versionToFile7 = new VersionToFile { Id = 7, ProjectVersionId = 4, ProjectFileId = 7 };
			VersionToFile versionToFile8 = new VersionToFile { Id = 8, ProjectVersionId = 5, ProjectFileId = 8 };
			VersionToFile versionToFile9 = new VersionToFile { Id = 9, ProjectVersionId = 5, ProjectFileId = 9 };
			VersionToFile versionToFile10 = new VersionToFile { Id = 10, ProjectVersionId = 6, ProjectFileId = 10 };
			VersionToFile versionToFile11 = new VersionToFile { Id = 11, ProjectVersionId = 6, ProjectFileId = 11 };
			VersionToFile versionToFile12 = new VersionToFile { Id = 12, ProjectVersionId = 2, ProjectFileId = 12 };
			VersionToFile versionToFile13 = new VersionToFile { Id = 13, ProjectVersionId = 3, ProjectFileId = 9 };
			VersionToFile versionToFile14 = new VersionToFile { Id = 14, ProjectVersionId = 4, ProjectFileId = 10 };
			VersionToFile versionToFile15 = new VersionToFile { Id = 15, ProjectVersionId = 4, ProjectFileId = 11 };
			VersionToFile versionToFile16 = new VersionToFile { Id = 16, ProjectVersionId = 4, ProjectFileId = 12 };

			modelBuilder.Entity<LauncherProject>().HasData(new LauncherProject[] { launcherProject1, launcherProject2, launcherProject3 });
			modelBuilder.Entity<ProjectVersion>().HasData(new ProjectVersion[] { version1, version2, version3, version4, version5, version6 });
			modelBuilder.Entity<ProjectFile>().HasData(new ProjectFile[] { projectFile1, projectFile2, projectFile3, projectFile4, projectFile5, projectFile6, projectFile7, projectFile8, projectFile9, projectFile10, projectFile11, projectFile12 });
			modelBuilder.Entity<VersionToFile>().HasData(new VersionToFile[] { versionToFile1, versionToFile2, versionToFile3, versionToFile4, versionToFile5, versionToFile6, versionToFile7, versionToFile8, versionToFile9, versionToFile10, versionToFile11, versionToFile12, versionToFile13, versionToFile14, versionToFile15, versionToFile16 });

			base.OnModelCreating(modelBuilder);
		}
	}
}
