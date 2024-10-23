using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatreManagement.Entities;

namespace TheatreManagement.Factory
{
    public class ArtistManagerFactory
    {
        public BaseArtistFactory CreateFactory(Artist artist)
        {
            BaseArtistFactory returnValue = null;
            if (artist.ArtistType == TypeOfArtist.Permanent)
            {
                returnValue = new PermanentArtistFactory(artist);
            }
            else if (artist.ArtistType == TypeOfArtist.Guest)
            {
                returnValue = new GuestArtistFactory(artist);
            }
            return returnValue;
        }
    }

}
