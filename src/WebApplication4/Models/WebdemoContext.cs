using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication4.Models
{
    public partial class WebdemoContext : DbContext
    {
        public virtual DbSet<Profile> Profile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=(local)\SQLEXPRESS;Database=Webdemo;User ID=sa;Password=tnS12345;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>(entity =>
            {
                entity.Property(e => e.ProfileId).HasColumnName("Profile_Id");

                entity.Property(e => e.ProAge).HasColumnName("Pro_Age");

                entity.Property(e => e.ProLname).HasColumnName("Pro_LName");

                entity.Property(e => e.ProName).HasColumnName("Pro_Name");
            });
        }
    }
}