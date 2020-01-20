using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.Data
{
	public class ApplicationDbContext: DbContext
	{
		public DbSet<Course> Courses { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Enrollment> Enrollments { get; set; }
		public DbSet<Instructor> Instructors { get; set; }
		public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
		public DbSet<Student> Students { get; set; }
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// ONE-TO-ONE RELATIONSHIP between <INSTRUCTOR> entity and <OFFICEASSIGNMENT> entity
			modelBuilder.Entity<OfficeAssignment>()
				.HasKey(k=> new { k.InstructorId});
			/*
			
			modelBuilder.Entity<Instructor>()
				.HasOne<OfficeAssignment>(of=>of.OfficeAssignment)
				.WithOne(a=>a.Instructor)
				.HasForeignKey<OfficeAssignment>(fk=>fk.InstructorId)
				.OnDelete(DeleteBehavior.Cascade);
			 */
			// or we can start with
			modelBuilder.Entity<OfficeAssignment>()
				.HasOne(of=>of.Instructor)
				.WithOne(a=>a.OfficeAssignment)
				.HasForeignKey<OfficeAssignment>(fk=>fk.InstructorId)
				.OnDelete(DeleteBehavior.Cascade).IsRequired();
			// MANY-TO-MANY RELATIONSHIP between <COURSE> entity and <INSTRUCTOR> entity
			modelBuilder.Entity<CourseInstructor>().HasKey(key => new {key.CourseID,key.InstructorId });
			modelBuilder.Entity<CourseInstructor>()
				.HasOne(c=>c.Course)
				.WithMany(d=>d.CourseInstructors)
				.HasForeignKey(key=>key.CourseID).
				OnDelete(DeleteBehavior.Restrict);
			modelBuilder.Entity<Instructor>()
				.HasMany(i => i.CourseInstructors)
				.WithOne(ci => ci.Instructor)
				.HasForeignKey(key => key.InstructorId)
				.OnDelete(DeleteBehavior.Restrict);
		}

	}
}
