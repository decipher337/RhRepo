using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Redhawk.WebApp.Models;

namespace Redhawk.WebApp.Migrations
{
    [DbContext(typeof(RedhawkContext))]
    [Migration("20151221032851_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Redhawk.WebApp.Models.Stop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Arrival");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<int?>("TripId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Redhawk.WebApp.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Name");

                    b.Property<string>("Username");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Redhawk.WebApp.Models.Stop", b =>
                {
                    b.HasOne("Redhawk.WebApp.Models.Trip")
                        .WithMany()
                        .HasForeignKey("TripId");
                });
        }
    }
}
