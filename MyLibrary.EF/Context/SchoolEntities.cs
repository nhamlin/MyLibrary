using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MyLibrary.EF.Context
{
	public class SchoolEntities : DbContext
	{
		// Add a DbSet for each entity type that you want to include in your model. For more information
		// on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

		public virtual DbSet<Department> Departments { get; set; }

		// Your context has been configured to use a 'SchoolEntities' connection string from your application's
		// configuration file (App.config or Web.config). By default, this connection string targets the
		// 'MyLibrary.EF.Context.SchoolEntities' database on your LocalDb instance.
		//
		// If you wish to target a different database and/or database provider, modify the 'SchoolEntities'
		// connection string in the application configuration file.
		public SchoolEntities()
			: base("name=MyLibrary.Database")
		{
		}
	}

	public class Department
	{
		public Department()
		{
			Courses= new List<Course>();
		}

		public int DepartmentID { get; set; }
		public DepartmentNames Name { get; set; }
		public ICollection<Course> Courses { get; set; }
	}

	public class Course
	{
		// Primary key
		public int CourseID { get; set; }

		public string Title { get; set; }
		public int Credits { get; set; }

		// Foreign key
		public int DepartmentID { get; set; }

		// Navigation properties
		public virtual Department Department { get; set; }
	}

	public class OnlineCourse : Course
	{
		public string URL { get; set; }
	}

	public class OnsiteCourse : Course
	{
		public string Location { get; set; }
		public string Days { get; set; }
		public DateTime Time { get; set; }
	}

	public enum DepartmentNames
	{
		English,
		Math,
		Economics
	}
}