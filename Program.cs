using System;
using System.Reflection.Metadata.Ecma335;
using System.IO;

class Album
{
    public int ID;
    private string Title;
    private string Artist;

    private string ReleaseYear;

    private string genre;
    private DateTime time;

    private int rating;

    public Album(int ID, string Title, string Artist, string ReleaseYear, int rating)
    {
        this.ID = ID;
        this.Title = Title;
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
        return this.Title;
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
        string entry = this.ToString();
        if (File.Exists(filepath))
        {
            File.AppendAllText(filepath, entry + Environment.NewLine);
        }
        else {
            Console.WriteLine("ERROR: File does not exsit");
            Environment.Exit(1);
        }
    }
    public string ToString()
    {
        string album;
        album = string.Format("{0,-10}{1,-20} {2,-30} {3,-40} {4,-50}", this.ID, this.Title, this.Artist, this.ReleaseYear, this.rating);
        return album;
    }
}
namespace MyAlbumList
{

    class Program
    {
        public static void Main(string[] args)
        {
            string filepath = "./list.txt";
            Console.WriteLine("Welcome to MyAlbum List. Please select an option: ");

            Console.WriteLine("[1] Add new album");
            Console.WriteLine("[2] Print albums");
            Console.WriteLine("[3] Delete album");
            Console.WriteLine("[4] Exit ");

            char choice;
            choice = Console.ReadLine()[0];
            if (choice <= 48 || choice > 52)
            {
                do
                {
                    Console.WriteLine("Input out of range or invalid char, plese input a number between 1 and 4");
                    choice = Console.ReadLine()[0];

                } while (choice <= 48 || choice > 52);
            }
            switch (choice)
            {
                case '1':
                    AddEntry(filepath);
                    break;
                default:
                    break;
            }
        }

        public static void CreateList(string filepath)
        {
            File.Create(filepath).Close();
            var init = string.Format("{0,-10} {1,-20} {2,-30} {3,-40} {4,-50}", "ID", "Title", "Artist", "Release_Year", "Score");
            File.AppendAllText("./list.txt", init + Environment.NewLine);
            Console.WriteLine("File succesefully created");
        }
        public static void AddEntry(string filepath)
        {
            if (!File.Exists(filepath))
            {
                Console.WriteLine("List does not exsit, need to create the list first before adding entry");
                CreateList(filepath);
            }
            Album entry = CreateAlbum(filepath);

            entry.AddAlbum(filepath);
            Console.WriteLine("Succesefully added new album to list");
        }
        public static Album CreateAlbum(string filepath)
        {
            string title;
            string artist;
            string ReleaseYear;
            int score;

            Console.WriteLine("Input name of the album: ");
            title = Console.ReadLine();

            Console.WriteLine("Artist: ");
            artist = Console.ReadLine();

            Console.WriteLine("Date of release: ");
            ReleaseYear = Console.ReadLine();

            Console.WriteLine("Score: ");
            score = Int32.Parse(Console.ReadLine());
            if (score < 1 || score > 10)
            {

                do
                {
                    Console.WriteLine("Score is out of range, score must be between 1 and 10");
                    score = Int32.Parse(Console.ReadLine());
                } while (score < 1 || score > 10);
            }

            int id = CountList(filepath);

            return new Album(id, title, artist, ReleaseYear, score);

        }
        public static int CountList(string filepath)
        {
            if (!File.Exists(filepath))
            {
                Console.WriteLine("ERROR: File does not exsit");
                Environment.Exit(1);
            }
            //count number of line in file 
            int n = 0;
            using (var readear = File.OpenText(filepath))
            {
                while (readear.ReadLine() != null)
                {
                    n++;
                }
            
            }
            return n;
        }
    }
    

}
