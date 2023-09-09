using Microsoft.EntityFrameworkCore;
using Student_Management.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Student_Management.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<TbCourse> TbCourses { get; set; }

        public DbSet<TbDetail> TbDetails { get; set; }

        public DbSet<TbStudent> TbStudents { get; set; }

        public DbSet<TbUser> TbUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbCourse>()
                 .HasKey(curse => new { curse.Id });
            modelBuilder.Entity<TbCourse>()
                .HasOne(user => user.Teacher)
                .WithMany(curse => curse.TbCourses)
                .HasForeignKey(key => key.TeacherId);

            modelBuilder.Entity<TbUser>()
                .HasKey(user => new { user.Id });
            modelBuilder.Entity<TbUser>()
                .HasOne(detail => detail.Detail)
                .WithMany(user => user.TbUsers)
                .HasForeignKey(key => key.DetailId);

            modelBuilder.Entity<TbStudent>()
                .HasKey(stundert => new { stundert.Id });
            modelBuilder.Entity<TbStudent>()
                .HasOne(user => user.Student)
                .WithMany(stundert => stundert.TbStudents)
                .HasForeignKey(key => key.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TbStudent>()
                .HasOne(user => user.Teacher)
                .WithMany(stundert => stundert.TbTeachers)
                .HasForeignKey(key => key.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TbStudent>()
                .HasOne(course => course.Course)
                .WithMany(stundert => stundert.TbStudents)
                .HasForeignKey(key => key.CourseId);
        }
    }
}
