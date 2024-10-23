using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatreManagement.Entities;
using TheatreManagement.Manager;

namespace TheatreManagement.Factory
{
    public abstract class BaseArtistFactory
    {
        Artist _artist;
        protected BaseArtistFactory(Artist artist)
        {
            _artist = artist;
        }
        public abstract IArtistManager Create();
        public Artist ApplySalary()
        {
            IArtistManager manager = this.Create();
            _artist.ShowPercentage = manager.GetShowPercentage();
            _artist.Salary = (double)manager.GetPay();
            return _artist;
        }

    }
}
