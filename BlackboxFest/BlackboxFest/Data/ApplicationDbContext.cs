using System;
using System.Collections.Generic;
using System.Text;
using BlackboxFest.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlackboxFest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Artist> Artists { get; set; }
      

        public DbSet<City> Cities { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<News> News { get; set; }
        
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<TypeTicket> TypeTickets { get; set; }
        public DbSet<CustomUser> GetUsers { get; set; }
        public DbSet<UserConcert> UserConcerts { get; set; }
        public DbSet<UserNews> UserNews { get; set; }
        public DbSet<Gallery> Galleries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            
            builder.Entity<Stage>().HasData(new Stage
            {
                Id = 1,
                Name ="Mainstage"
               
            });
            builder.Entity<Stage>().HasData(new Stage
            {
                Id = 2,
                Name = "The Crave"

            });
            builder.Entity<Stage>().HasData(new Stage
            {
                Id = 3,
                Name = "Technoville"

            });
            builder.Entity<Stage>().HasData(new Stage
            {
                Id = 4,
                Name = "The Dome"

            });
            builder.Entity<TypeTicket>().HasData(new TypeTicket
            {
                Id = 1,
                Name = "Weekend",
                Price = 180
            });
            builder.Entity<TypeTicket>().HasData(new TypeTicket
            {
                Id = 2,
                Name = "Day",
                Price = 80
            });
            builder.Entity<TypeTicket>().HasData(new TypeTicket
            {
                Id = 3,
                Name = "Camping",
                Price= 15
            });
            builder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = 1,
                Hour="12.00-13.30"
               
            });
            builder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = 2,
                Hour = "12.30-14.00"

            });
            builder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = 3,
                Hour = "14.00-15.30"

            }); builder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = 4,
                Hour = "14.30-16.00"

            }); builder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = 5,
                Hour = "16.00-17.30"

            }); builder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = 6,
                Hour = "16.30-18.00"

            }); builder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = 7,
                Hour = "18.00-19.30"

            }); builder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = 8,
                Hour = "18.30-20.00"

            });
            builder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = 9,
                Hour = "20.00-21.30"

            });
            builder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = 10,
                Hour = "20.30-22.00"

            });
            builder.Entity<TimeSlot>().HasData(new TimeSlot
            {
                Id = 11,
                Hour = "22.00-23.30"

            });

        }

    }
}
