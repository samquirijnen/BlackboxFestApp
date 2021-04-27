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
       
    }
}
