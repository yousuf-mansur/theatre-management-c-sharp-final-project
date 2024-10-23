using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatreManagement.Entities;

namespace TheatreManagement.Repository
{
    public class ArtistRepository : IArtistRepository
    {
        private List<Artist> artistList;
        public ArtistRepository()
        {
            artistList = new List<Artist>()
            {
                new Artist(){Id=1, Name="Tarik Anam", Gender="Male", Age=65, Salary=12000, Role="Actor", ArtistType=TypeOfArtist.Guest},
                new Artist(){Id=2, Name="Syed Jamil Ahmed", Gender="Male", Age=50, Salary=18000, Role="Director", ArtistType=TypeOfArtist.Permanent},
                new Artist(){Id=3, Name="Sonia Akter", Gender="Female", Age=25, Salary=18000, Role="Actress", ArtistType=TypeOfArtist.Permanent},
                new Artist(){Id=4, Name="Abdullah Nur", Gender="Male", Age=55, Salary=12000, Role="Voice Artist", ArtistType=TypeOfArtist.Guest},
                new Artist(){Id=5, Name="Sarkar Imran", Gender="Male", Age=35, Salary=18000, Role="Costume Designer", ArtistType=TypeOfArtist.Permanent}
            };


        }
        public Artist CreateArtist(Artist artist)
        {
            Artist listedArtist=(from a in artistList orderby a.Id descending select a).Take(1).Single() as  Artist;
            artist.Id = listedArtist.Id+1;
            artistList.Add(artist);
            return artist;
        }

        public Artist DeleteArtist(int id)
        {
            Artist deleteArtist=GetArtist(id);
            if (deleteArtist != null) 
            {
                artistList.Remove(deleteArtist);
            }
            return deleteArtist;
        }

        public IEnumerable<Artist> GetAllArtists()
        {
            return artistList;
        }

        public Artist GetArtist(int id)
        {
            var artist=(from a in artistList where a.Id == id select a).Single();
            return artist;
        }

        public Artist UpdateArtist(Artist upArtist)
        {
            Artist artist=GetArtist(upArtist.Id);
            if (artist != null) 
            {
                artist.Id = upArtist.Id;
                artist.Name = upArtist.Name;
                artist.Age = upArtist.Age;
                artist.Gender = upArtist.Gender;
                artist.Role = upArtist.Role;
                artist.Salary = upArtist.Salary;
                artist.ArtistType = upArtist.ArtistType;
            }
            return artist;
        }
    }
}
