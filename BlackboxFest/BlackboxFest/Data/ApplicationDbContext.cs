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
      
        public DbSet<Artist> Artists { get; set; }
      

      
        public DbSet<Concert> Concerts { get; set; }
      
        public DbSet<News> News { get; set; }
        
        public DbSet<Stage> Stages { get; set; }
        public DbSet<TicketOrder> TicketOrders { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<TypeTicket> TypeTickets { get; set; }
        public DbSet<CustomUser> GetUsers { get; set; }
        public DbSet<UserConcert> UserConcerts { get; set; }
        public DbSet<UserNews> UserNews { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<TicketOrderDetail> TicketOrderDetails { get; set; }
        public DbSet<TicketShopCart> TicketShopCarts { get; set; }

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
            builder.Entity<DateDayFestival>().HasData(new DateDayFestival
            {
                Id = 1,
                Date="24/09/2021"

            });
            builder.Entity<DateDayFestival>().HasData(new DateDayFestival
            {
                Id = 2,
                Date = "25/09/2021"

            });
            builder.Entity<DateDayFestival>().HasData(new DateDayFestival
            {
                Id = 3,
                Date = "26/09/2021"

            });
            builder.Entity<Concert>().HasData(new Concert
            {
                Id = 45,
                StageID = 1,
                TimeSlotID = 1,
                DateID = 1

            });
            builder.Entity<Concert>().HasData(new Concert
            {
                Id = 46,
                StageID = 2,
                TimeSlotID = 2,
                DateID = 1

            });
            builder.Entity<Concert>().HasData(new Concert
            {
                Id = 47,
                StageID = 1,
                TimeSlotID = 3,
                DateID = 1

            });
            builder.Entity<Concert>().HasData(new Concert
            {
                Id = 48,
                StageID = 1,
                TimeSlotID = 5,
                DateID = 1

            });
            builder.Entity<Concert>().HasData(new Concert
            {
                Id = 49,
                StageID = 1,
                TimeSlotID = 7,
                DateID = 1

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 50,
                StageID = 1,
                TimeSlotID = 9,
                DateID = 1

            });
            builder.Entity<Concert>().HasData(new Concert
            {
                Id = 51,
                StageID = 2,
                TimeSlotID = 4,
                DateID = 1

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 52,
                StageID = 2,
                TimeSlotID = 6,
                DateID = 1

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 53,
                StageID = 2,
                TimeSlotID = 8,
                DateID = 1

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 54,
                StageID = 2,
                TimeSlotID = 10,
                DateID = 1

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 55,
                StageID = 3,
                TimeSlotID = 1,
                DateID = 1

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 56,
                StageID = 3,
                TimeSlotID = 3,
                DateID = 1

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 57,
                StageID = 3,
                TimeSlotID = 5,
                DateID = 1

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 58,
                StageID = 3,
                TimeSlotID = 7,
                DateID = 1

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 59,
                StageID = 3,
                TimeSlotID = 9,
                DateID = 1

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 60,
                StageID = 3,
                TimeSlotID = 11,
                DateID = 1

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 61,
                StageID = 4,
                TimeSlotID = 2,
                DateID = 1

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 62,
                StageID = 4,
                TimeSlotID = 4,
                DateID = 1

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 63,
                StageID = 4,
                TimeSlotID = 6,
                DateID = 1

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 64,
                StageID = 4,
                TimeSlotID = 8,
                DateID = 1

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 65,
                StageID = 4,
                TimeSlotID = 10,
                DateID = 1

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 66,
                StageID = 1,
                TimeSlotID = 1,
                DateID = 2

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 67,
                StageID = 1,
                TimeSlotID = 3,
                DateID = 2

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 68,
                StageID = 1,
                TimeSlotID = 5,
                DateID = 2

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 69,
                StageID = 1,
                TimeSlotID = 7,
                DateID = 2

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 70,
                StageID = 1,
                TimeSlotID = 9,
                DateID = 2

            });
            builder.Entity<Concert>().HasData(new Concert
            {
                Id = 71,
                StageID = 1,
                TimeSlotID = 11,
                DateID = 2

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 72,
                StageID = 2,
                TimeSlotID = 2,
                DateID = 2

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 73,
                StageID = 2,
                TimeSlotID = 4,
                DateID = 2

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 74,
                StageID = 2,
                TimeSlotID = 6,
                DateID = 2

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 75,
                StageID = 2,
                TimeSlotID = 10,
                DateID = 2

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 76,
                StageID = 3,
                TimeSlotID = 1,
                DateID = 2

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 77,
                StageID = 3,
                TimeSlotID = 3,
                DateID = 2

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 78,
                StageID = 3,
                TimeSlotID = 5,
                DateID = 2

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 79,
                StageID = 3,
                TimeSlotID = 7,
                DateID = 2

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 80,
                StageID = 3,
                TimeSlotID = 9,
                DateID = 2

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 81,
                StageID = 3,
                TimeSlotID = 11,
                DateID = 2

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 82,
                StageID = 4,
                TimeSlotID = 2,
                DateID = 2

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 83,
                StageID = 4,
                TimeSlotID = 4,
                DateID = 2

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 84,
                StageID =4,
                TimeSlotID = 6,
                DateID = 2

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 85,
                StageID = 4,
                TimeSlotID = 8,
                DateID = 2

            }); builder.Entity<Concert>().HasData(new Concert
            {
                Id = 86,
                StageID = 4,
                TimeSlotID = 10,
                DateID = 2

            });
            ; builder.Entity<Concert>().HasData(new Concert
            {
                Id = 87,
                StageID = 1,
                TimeSlotID = 1,
                DateID = 3

            }); ; builder.Entity<Concert>().HasData(new Concert
            {
                Id = 88,
                StageID = 1,
                TimeSlotID = 3,
                DateID = 3

            }); ; builder.Entity<Concert>().HasData(new Concert
            {
                Id = 89,
                StageID = 1,
                TimeSlotID = 5,
                DateID = 3

            }); ; builder.Entity<Concert>().HasData(new Concert
            {
                Id = 90,
                StageID = 1,
                TimeSlotID = 7,
                DateID = 3

            }); ; builder.Entity<Concert>().HasData(new Concert
            {
                Id = 91,
                StageID = 1,
                TimeSlotID = 9,
                DateID = 3

            }); ; builder.Entity<Concert>().HasData(new Concert
            {
                Id = 92,
                StageID = 1,
                TimeSlotID = 11,
                DateID = 3

            }); ; builder.Entity<Concert>().HasData(new Concert
            {
                Id = 93,
                StageID = 2,
                TimeSlotID = 2,
                DateID = 3

            }); ; builder.Entity<Concert>().HasData(new Concert
            {
                Id = 94,
                StageID = 2,
                TimeSlotID = 4,
                DateID = 3

            }); ; builder.Entity<Concert>().HasData(new Concert
            {
                Id = 95,
                StageID = 2,
                TimeSlotID = 6,
                DateID = 3

            }); ; builder.Entity<Concert>().HasData(new Concert
            {
                Id = 96,
                StageID = 2,
                TimeSlotID = 8,
                DateID = 3

            }); ; builder.Entity<Concert>().HasData(new Concert
            {
                Id = 97,
                StageID = 2,
                TimeSlotID = 10,
                DateID = 3

            }); ; builder.Entity<Concert>().HasData(new Concert
            {
                Id = 98,
                StageID = 3,
                TimeSlotID = 1,
                DateID = 3

            }); ; builder.Entity<Concert>().HasData(new Concert
            {
                Id = 99,
                StageID = 3,
                TimeSlotID = 3,
                DateID = 3

            }); ; builder.Entity<Concert>().HasData(new Concert
            {
                Id = 100,
                StageID = 3,
                TimeSlotID = 5,
                DateID = 3

            }); ; builder.Entity<Concert>().HasData(new Concert
            {
                Id = 101,
                StageID = 3,
                TimeSlotID = 7,
                DateID = 3

            }); ; builder.Entity<Concert>().HasData(new Concert
            {
                Id = 102,
                StageID = 3,
                TimeSlotID = 9,
                DateID = 3

            }); ; builder.Entity<Concert>().HasData(new Concert
            {
                Id = 103,
                StageID = 3,
                TimeSlotID = 11,
                DateID = 3

            }); ; builder.Entity<Concert>().HasData(new Concert
            {
                Id = 104,
                StageID = 4,
                TimeSlotID = 2,
                DateID = 3

            }); ; builder.Entity<Concert>().HasData(new Concert
            {
                Id = 105,
                StageID = 4,
                TimeSlotID = 4,
                DateID = 3

            }); ; builder.Entity<Concert>().HasData(new Concert
            {
                Id = 106,
                StageID = 4,
                TimeSlotID = 6,
                DateID = 3

            }); ; builder.Entity<Concert>().HasData(new Concert
            {
                Id = 107,
                StageID = 4,
                TimeSlotID = 8,
                DateID = 3

            }); ; builder.Entity<Concert>().HasData(new Concert
            {
                Id = 108,
                StageID = 4,
                TimeSlotID = 10,
                DateID = 3

            });





        }

    }
}
