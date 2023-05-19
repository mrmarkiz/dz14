using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz14
{
    internal class Task2
    {
        public static void Run()
        {
            int choice;
            using (Shop shop = new Shop())
            {
                do
                {
                    Console.WriteLine("Enter what to do(1 - init new shop, 2 - show current , 3 - clear current shop, 0 - leave):");
                    int.TryParse(Console.ReadLine(), out choice);
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Init Shop:");
                            shop.Init();
                            break;
                        case 2:
                            try
                            {
                                Console.WriteLine("Shop info:\n" + shop);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Error collapsed: {e.Message}");
                            }
                            break;
                        case 3:
                            shop.Dispose();
                            break;
                    }
                    Console.WriteLine();
                } while (choice != 0);
            }
        }
    }

    internal class Shop : IDisposable
    {
        public StringBuilder Name { get; set; }
        public StringBuilder Adress { get; set; }
        public Nullable<MyType> ShopType { get; set; }

        public Shop(string name, string adress, MyType shopType)
        {
            Name = new StringBuilder(name);
            Adress = new StringBuilder(adress);
            ShopType = MyType.None;
        }

        public Shop() : this(string.Empty, string.Empty, MyType.None)
        { }

        public void Init()
        {
            Console.Write("Enter shop name: ");
            Name = new StringBuilder(Console.ReadLine());
            Console.Write("Enter shop adress: ");
            Adress = new StringBuilder(Console.ReadLine());
            Console.WriteLine("Choose shop type(1 - product, 2 - household, 3 - clothes, 4 - shoes):");
            int.TryParse(Console.ReadLine(), out int type);
            if (type < 0 || type > 4)
                type = 0;
            ShopType = (MyType)type;
        }

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"Adress: {Adress}\n" +
                $"Shop type: {ShopType.ToString()}";
        }

        public void Dispose()
        {
            Name = null;
            Adress = null;
            ShopType = null;
            Console.WriteLine("Memory for shop was cleared");
        }
    }
}
