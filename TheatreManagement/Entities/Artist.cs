using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TheatreManagement.Entities
{
    public class Artist
    {
        int id;
        string name;
        string gender;
        int age;
        double salary;
        string role;
        TypeOfArtist artistType;
        

        public Artist(int id, string name, string gender, int age, double salary, string role, TypeOfArtist artistType)
        {
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.age = age;
            this.salary = salary;
            this.role = role;
            this.artistType = artistType;
        }

        public decimal ShowPercentage { get; set; }
        public decimal FoodAllowance { get; set; }
        public decimal TransportAllowance { get; set; }
        public decimal Grant { get; set; }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }
        public int Age { get => age; set => age = value; }
        public double Salary { get => salary; set => salary = value; }
        public string Role { get => role; set => role = value; }
        public TypeOfArtist ArtistType { get => artistType; set => artistType = value; }
     

        public Artist()
        {
        }
    }
}
