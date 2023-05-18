using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz14
{
    internal class Task1
    {
        public static void Run()
        {
            int choice;
            using (Play play = new Play())
            {
                do
                {
                    Console.WriteLine("Enter what to do(1 - init new play, 2 - show current , 3 - clear current play, 0 - leave):");
                    int.TryParse(Console.ReadLine(), out choice);
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Init Play:");
                            play.Init();
                            break;
                        case 2:
                            try
                            {
                                Console.WriteLine("Play info:\n" + play);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Error collapsed: {e.Message}");
                            }
                            break;
                        case 3:
                            play.Dispose();
                            break;
                    }
                    Console.WriteLine();
                } while (choice != 0);
            }
        }
    }

    internal class Play : IDisposable
    {
        public StringBuilder Name { get; set; }
        public StringBuilder Author { get; set; }
        public StringBuilder Jenre { get; set; }
        public Nullable<int> CreationYear { get; set; }

        public Play(string name, string author, string jenre, int creationYear)
        {
            Name = new StringBuilder(name);
            Author = new StringBuilder(author);
            Jenre = new StringBuilder(jenre);
            CreationYear = creationYear;
        }

        public Play() : this(string.Empty, string.Empty, string.Empty, 0)
        { }

        public void Init()
        {
            Console.Write("Enter play name: ");
            Name = new StringBuilder(Console.ReadLine());
            Console.Write("Enter play author: ");
            Author = new StringBuilder(Console.ReadLine());
            Console.Write("Enter play jenre: ");
            Jenre = new StringBuilder(Console.ReadLine());
            Console.Write("Enter play creation year: ");
            int.TryParse(Console.ReadLine(), out int cre);
            CreationYear = cre;
        }

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"Play author: {Author}\n" +
                $"Jenre: {Jenre}\n" +
                $"Creation year: {CreationYear}";
        }

        public void Dispose()
        {
            Name = null;
            Author = null;
            Jenre = null;
            CreationYear = null;
            Console.WriteLine("Memory for play was cleared");
        }
    }
}
