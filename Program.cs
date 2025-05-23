using System;
using System.Reflection.Metadata.Ecma335;
using System.IO;

class Album
{
    public int ID;
    private string Name;
    private string Artist;

    private string ReleaseYear;

    private string genre;
    private DateTime time;

    private int rating;

    public Album(int ID, string Name, string Artist, string ReleaseYear, int rating){
        this.ID = ID;
        this.Name = Name;
        this.Artist = Artist;
        this.ReleaseYear = ReleaseYear;
        this.rating = rating;

        this.time = DateTime.Now;

    }

    public int GetID()
    {
        return this.ID;
    }
    public string GetName()
    {
        return this.Name;
    }
    public string GetArtist()
    {
        return this.Artist;
    }
    public string GetReleaseYear()
    {
        return this.ReleaseYear;
    }
    public void AddAlbum(string filepath)
    {
        string[] list = {this.Name, this.Artist, this.ReleaseYear };
        if(File.Exists(filepath)){
             File.AppendAllLines(filepath,list);
        }
    }
}
namespace MyAlbumList
{

    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to MyAlbum List. Please select an option: ");

            Console.WriteLine("[1] Add new album");
            Console.WriteLine("[2] Print albums");
            Console.WriteLine("[3] Delete album");
            Console.WriteLine("[4] Exit ");

            char choice;
            choice = Console.ReadLine()[0];
            if(choice <=48 || choice > 52){
                do
                {
                    Console.WriteLine("Input out of range or invalid char, plese input a number between 1 and 4");
                    choice = Console.ReadLine()[0];

                } while (choice <= 48 || choice > 52);
            }
            switch(choice){
                case '1':
                    AddEntry();
                    break;
                default:
                    break;
            }
        }

        public static void CreateList(){
            File.Create("./list.txt");
            Console.WriteLine("File succesefully created");
        }
        public static void AddEntry(){
            if(File.Exists("./list.txt")){
                Console.WriteLine("File already exsit no need to init, just add the new entry");
            }
            else {
                Console.WriteLine("List does not exsit, need to create the list first before adding entry");
                CreateList();
            }
            Album test = new Album(
                1, "All Eyez on Me", "2pac", "February 6th 1996",10 
            );
            test.AddAlbum("./list.txt");
        }
    }

}
