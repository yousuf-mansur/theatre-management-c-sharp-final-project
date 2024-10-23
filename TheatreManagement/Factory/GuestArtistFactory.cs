using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatreManagement.Entities;
using TheatreManagement.Manager;

namespace TheatreManagement.Factory
{
    public class GuestArtistFactory : BaseArtistFactory
    {
        Artist _artist;
        public GuestArtistFactory(Artist artist) : base(artist)
        {
            _artist = artist;
        }

        public override IArtistManager Create()
        {
            GuestArtistManager manager = new GuestArtistManager();
            _artist.TransportAllowance=manager.GetTransportAllowance();
            _artist.FoodAllowance=manager.GetFoodAllowance();
            return manager;
        }
    }
}
