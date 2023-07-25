using System;
using System.Reflection;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using TheProjectToSend.Models;

namespace TheProjectToSend.Context
{
	public class PersonContext:DbContext
	{
        /*public PersonContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
  => options.UseSqlServer("Server=.;Database=Freshdatabase;User=sa;Password=Giorgi1999;TrustServerCertificate=True");

        public PersonContext(DbContextOptions<PersonContext> option)
              : base(option)
        {

        }
        */
        public PersonContext(DbContextOptions<PersonContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        internal Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        internal void DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Gender> Gender { get; set; }
    }
}

