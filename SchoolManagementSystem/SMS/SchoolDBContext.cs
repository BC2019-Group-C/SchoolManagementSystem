using Microsoft.EntityFrameworkCore;
using SMS.DataSource.Entities;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.DataSource
{
    public class SchoolDBContext : DbContext
    {
        //public SchoolDBContext(DbContextOptions<SchoolDBContext> options) : base(options)
        //{

        //    Database.Migrate();
        //}

        // add classes in here to include to database
        public DbSet<Admin> Admins { get; set; }

        public DbSet<AdminLogin> AdminLogins { get; set; }

        public DbSet<SclPrincipal> Principals { get; set; }

        public DbSet<SclPrincipalLogin> PrincipalLogins { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<TeacherLogin> TeacherLogin { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentLogin> StudentLogins { get; set; }

        public DbSet<ClassRoom> ClassRooms { get; set; }

        

        //Making the connection

        protected override void OnConfiguring(DbContextOptionsBuilder builder) //to create databse
        {
            string sqlConnection = "Server=SANTHOSH;Database=SchoolManagementSystemDB;Trusted_Connection=true"; //Don't leave any space in the string
            builder.UseSqlServer(sqlConnection);

            base.OnConfiguring(builder);
        }
    }
}
