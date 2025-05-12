using System;
using System.Reflection.Metadata.Ecma335;
using System.IO;

class Album{
    public int ID;
    private string Name;
    private string Artist;

    private string ReleaseYear;

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

    public int GetID(){
        return this.ID;
    }
    public string GetName(){
        return this.Name;
    }
    public string GetArtist(){
        return this.Artist;
    }
    public string GetReleaseYear(){
        return this.ReleaseYear;
    }
}
namespace MyAlbumList
{

    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to MyAlbum List. Please input an album you recently listend to and its rating:");
            string input = Console.ReadLine();
            if(File.Exists("./list.txt")){
                Console.WriteLine("File already exsit no need to init, just add the new entry");
            }
            else {
                Console.WriteLine("List does not exsit, need to create the list first before adding entry");
                CreateList();
            }
        }

        public static void CreateList(){
            File.Create("./list.txt");
            Console.WriteLine("File succesefully created");
        }
    }

}
