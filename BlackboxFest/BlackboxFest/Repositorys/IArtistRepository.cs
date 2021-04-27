using BlackboxFest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackboxFest.Repositorys
{
    public interface IArtistRepository
    {
        Task<int> AddNewArtist(ArtistViewModel model);
        Task<List<ArtistViewModel>> GetAllArtists();
        Task<ArtistViewModel> GetArtistById(int id);
        List<ArtistViewModel> SearchArtist(string title, string authorName);
        
       

       
    }
}
