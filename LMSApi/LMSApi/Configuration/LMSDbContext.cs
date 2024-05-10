using LMSBase.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LMSApi.Configuration
{
	public class LMSDbContext : DbContext
	{
		public LMSDbContext(DbContextOptions<LMSDbContext> options) : base(options) { }

		public DbSet<SchoolClass> SchoolClasses { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<LearningModule> LearningModules { get; set; }
		public DbSet<Codelab> Codelabs { get; set; }
		public DbSet<Status> Statuses { get; set; }
		public DbSet<Coach> Coaches { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<SchoolClassCourse> SchoolClassCourses { get; set; }
		public DbSet<CoachSchoolClass> CoachSchoolClasses { get; set; }
		public DbSet<StudentCodelab> StudentCodeLabs { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Student>().Ignore(s => s.Claims);
			modelBuilder.Entity<Coach>().Ignore(c => c.Claims);
			modelBuilder.Entity<Student>(e =>
			{
				e.HasKey(s => s.UserId);
			});
			modelBuilder.Entity<Coach>(e =>
			{
				e.HasKey(c => c.UserId);
			});
			modelBuilder.Entity<LearningModule>()
				.HasOne(m => m.Parent)
				.WithMany(m => m.SubModules)
				.HasForeignKey(m => m.ParentId);
			modelBuilder.Entity<SchoolClassCourse>(e => e.HasOne(c => c.Status).WithMany().OnDelete(DeleteBehavior.SetNull));
			modelBuilder.Entity<StudentCodelab>(e => e.HasOne(sc => sc.Status).WithMany().OnDelete(DeleteBehavior.SetNull));
			modelBuilder.Entity<SchoolClass>(e => e.HasOne(c => c.Status).WithMany().OnDelete(DeleteBehavior.SetNull));
			modelBuilder.Entity<LearningModule>(e => e.HasOne(m => m.Status).WithMany().OnDelete(DeleteBehavior.SetNull));
			modelBuilder.Entity<StudentCodelab>()
				.HasOne<Student>(sc=>sc.Student)
				.WithMany(s=>s.StudentCodelabs)
				.HasForeignKey(s=>s.UserId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
