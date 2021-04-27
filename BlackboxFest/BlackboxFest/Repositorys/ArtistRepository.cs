using BlackboxFest.Data;
using BlackboxFest.Models;
using BlackboxFest.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackboxFest.Repositorys
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ApplicationDbContext _context = null;
        private readonly IConfiguration _configuration;
        public ArtistRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<int> AddNewArtist(ArtistViewModel model)
        {
            var newArtist = new Artist()
            {
                Id = model.Id,
                Name = model.Name,
                ArtistShortDescription = model.ArtistShortDescription,
                ArtistLongDescription = model.ArtistLongDescription,
                MusicGenre = model.MusicGenre,
               

            };
            newArtist.Timetables = new List<TimeTable>();
            await _context.Artists.AddAsync(newArtist);
            await _context.SaveChangesAsync();

            return newArtist.Id;
        }

        public async Task<List<ArtistViewModel>> GetAllArtists()
        {
            return await _context.Artists
                  .Select(artist => new ArtistViewModel()
                  {
                      Id = artist.Id,
                      Name = artist.Name,
                      ArtistShortDescription = artist.ArtistShortDescription,
                      ArtistLongDescription = artist.ArtistLongDescription,
                     
                      MusicGenre = artist.MusicGenre
                     
                    

                  }).ToListAsync();
        }

        public async Task<ArtistViewModel> GetArtistById(int id)
        {
            return await _context.Artists.Where(x => x.Id == id)
                 .Select(artist => new ArtistViewModel()
                 {
                     Id = artist.Id,
                     Name = artist.Name,
                     ArtistShortDescription = artist.ArtistShortDescription,
                     ArtistLongDescription = artist.ArtistLongDescription,
            
                     MusicGenre = artist.MusicGenre
                 }).FirstOrDefaultAsync();
        }

        public List<ArtistViewModel> SearchArtist(string title, string authorName)
        {
            return null;
        }
    }
}
