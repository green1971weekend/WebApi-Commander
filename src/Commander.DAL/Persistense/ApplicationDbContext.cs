using Commander.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commander.DAL.Persistence
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Command> Commands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // The string below gives the access to MS SQL Server DB. For connection to another server use appropriate connection string.
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CommanderApp;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

    }
}
