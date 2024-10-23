using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatreManagement.Entities;

namespace TheatreManagement.Repository
{
    public interface IArtistRepository
    {
        IEnumerable<Artist> GetAllArtists();
        Artist GetArtist(int id);
        Artist CreateArtist(Artist artist);
        Artist UpdateArtist(Artist artist);
        Artist DeleteArtist(int id);
    }
}
