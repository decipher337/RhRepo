using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace Redhawk.WebApp.Models
{
    public class RedhawkContext : DbContext
    {
		public RedhawkContext()
		{
			Database.EnsureCreated();
		}

		public DbSet<Trip> Trips { get; set; }
		public DbSet<Stop> Stops { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connectionString = Startup.Configuration["Data:RedhawkContextConnection"];

			optionsBuilder.UseSqlServer(connectionString);

			base.OnConfiguring(optionsBuilder);
		}
	}
}
