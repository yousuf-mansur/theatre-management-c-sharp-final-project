using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatreManagement.Entities;
using TheatreManagement.Manager;

namespace TheatreManagement.Factory
{
    public class PermanentArtistFactory : BaseArtistFactory
    {
        Artist _artist;
        public PermanentArtistFactory(Artist artist) : base(artist)
        {
            this._artist = artist;
        }

        public override IArtistManager Create()
        {
            PermanentArtistManager manager = new PermanentArtistManager();
            _artist.Grant = manager.GetGrant();
            return manager;
        }
    }
}
