using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TheatreManagement.Entities;
using TheatreManagement.Factory;
using TheatreManagement.Repository;

namespace TheatreManagement
{
    internal class Program
    {
        public static ArtistRepository repo=new ArtistRepository();
        static void Main(string[] args)
        {
            try
            {
                DoTask();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { Console.ReadKey(); }
        }

        private static void DoTask()
        { 
            Console.WriteLine("\t\t\t Information\r");
            Console.WriteLine("\t\t\t-------------\n");
            Console.WriteLine();
            Console.WriteLine("\t\t\tTrainee ID\t: 1280670\r");
            Console.WriteLine("\t\t\tName\t\t: Md. Yousuf Mansur\r");
            Console.WriteLine("\t\t\tBatch ID\t: CS/SCSL-A/58/01\r");
            Console.WriteLine("\t\t\t\t-------------------\n");
            Console.WriteLine("\t\tHow many operation would you like to perform?\r");
            Console.WriteLine();
            int count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("\t\t\t\tSelect Operation\n");
                   
                    Console.WriteLine("\t\t\t\tHint: \n\t\t\t\tShow\t -1\n\t\t\t\tCreate\t -2\n\t\t\t\tUpdate\t -3\n\t\t\t\tDelete\t -4\n");
                    int operationNumber = Convert.ToInt16(Console.ReadLine());
                    switch (operationNumber)
                    {
                        case 1:
                            ShowAllArtist(null);
                            Console.WriteLine();
                            break;

                        case 2:
                            CreateNewArtist();
                            Console.WriteLine();
                            break;

                        case 3:
                            UpdateArtist();
                            Console.WriteLine();
                            break;

                        case 4:
                            DeleteArtist();
                            Console.WriteLine();
                            break;
                        default:
                            Console.WriteLine("Invalid operation");
                            break;
                    }
                
            }
        }

        private static void DeleteArtist()
        {
            Console.WriteLine("Enter ID of the Artist that you want to delete");
            int deleteId = Convert.ToInt32(Console.ReadLine());
            Artist deleteArtist = new Artist();
            deleteArtist.Id = deleteId;
            deleteArtist=repo.DeleteArtist(deleteId);
            Console.WriteLine("\t\t\t\t*Artist deleted successfully");
            Console.WriteLine();
            ShowAllArtist(deleteArtist);
        }

        private static void UpdateArtist()
        {
            Console.WriteLine("Enter ID");
            int iD = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\t\t\tEnter Name");
            string name = Console.ReadLine();
            Console.WriteLine("\t\t\tEnter Age ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\t\t\tEnter Gender ");
            string gender = Console.ReadLine();
            Console.WriteLine("\t\t\tEnter Basic Salary ");
            double salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\t\t\tEnter Basic Role ");
            string role = Console.ReadLine();
            


        EnterMemberType:
            Console.WriteLine("Enter Member Type *Hint: Permanent-1, Guest-2");
            string typeRead = Console.ReadLine();
            TypeOfArtist typeOfArtist;
            try
            {
                typeOfArtist = (TypeOfArtist)Enum.Parse(typeof(TypeOfArtist), typeRead);
            }
            catch
            {
                Console.WriteLine("Invalid type!! Try Again");
                goto EnterMemberType;
            }

            Artist updateArtist = new Artist();
            updateArtist.Id = iD;
            updateArtist.Name = name;
            updateArtist.Age = age;
            updateArtist.Gender = gender;
            updateArtist.Salary = salary;
            updateArtist.Role = role;
            updateArtist.ArtistType = typeOfArtist;



            updateArtist.ArtistType = typeOfArtist;
            updateArtist = repo.UpdateArtist(updateArtist);

            Console.WriteLine("\t\t\t\t*Artist updated successfully");
            Console.WriteLine();
            ShowAllArtist(updateArtist);
        }

        private static void CreateNewArtist()
        {
            
            Console.WriteLine("\t\t\tEnter Name");
            string name = Console.ReadLine();
            Console.WriteLine("\t\t\tEnter Age ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\t\t\tEnter Gender ");
            string gender = Console.ReadLine();
            Console.WriteLine("\t\t\tEnter  Salary ");
            double salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\t\t\tEnter Basic Role ");
            string role = Console.ReadLine();
            Console.WriteLine("\t\t\tEnter Artist Type ");
            


        EnterType:
            Console.WriteLine("Enter Member Type *Hint: Permanent-1, Guest-2");
            string typeRead = Console.ReadLine().ToLower(); 
            TypeOfArtist typeArtist;

            try
            {
                typeArtist = (TypeOfArtist)Enum.Parse(typeof(TypeOfArtist), typeRead);
            }
            catch
            {
                Console.WriteLine("Invalid type!! Try Again");
                goto EnterType;
            }

            Artist artist = new Artist(1, name, gender, age, salary, role, typeArtist); 
            BaseArtistFactory artistFactory = new ArtistManagerFactory().CreateFactory(artist);
            artistFactory.ApplySalary();
            repo.CreateArtist(artist);
            Console.WriteLine("\t\t\t\t*Artist added successfully");
            Console.WriteLine();
            ShowAllArtist(artist);

        }

        

        private static void ShowAllArtist(Artist artist)
        {
            IEnumerable<Artist> artists = repo.GetAllArtists();
            Console.WriteLine(string.Format("| {0,2}| {1,16}| {2,6}| {3,4}| {4,12}| {5,20}| {6,20}|", "ID", "Name", "Gender", "Age", "Salary", "Role", "Type"));
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            if (artists != null)
            {
                foreach (Artist item in artists)
                {
                    Console.WriteLine(string.Format("| {0,2}| {1,16}| {2,6}| {3,4}| {4,12}| {5,20}| {6,20}|", item.Id, item.Name, item.Gender, item.Age, item.Salary, item.Role, item.ArtistType));
                }
            }
            else
            {
                Console.WriteLine(string.Format("| {0,2}| {1,16}| {2,6}| {3,4}| {4,12}| {5,10}| {6,12}|", artist.Id, artist.Name, artist.Gender, artist.Age, artist.Salary, artist.Role, artist.ArtistType));
            }
        }

    }
}

