using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Database
{
    public class AspirantDBContext : DbContext
    {
        const string ConnectionString = "Server=ORANGEVM-PC;Database=Aspirant;User Id=sa;Password=123456;";
        public AspirantDBContext() { }

        public AspirantDBContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Aspirant> Aspirants { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<EntryExam> EntryExams { get; set; }

        public DbSet<Diplom> Diploms { get; set; }

        public DbSet<Enducation> Enducations { get; set; }
    }
}
