using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanced_types
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Creator: Felipe Bossolani - fbossolani[at]gmail.com");
            Console.WriteLine(@"Examples based on: http://returnsmart.blogspot.com/2015/08/mcsd-programming-in-c-part-5-70-483.html");
            Console.WriteLine("Choose a Thread Method: ");
            Console.WriteLine("01- Simple Enum");
            Console.WriteLine("02- Enum w/ Flags Decorate");
            Console.WriteLine("03- Struct");
            Console.WriteLine("04- Extension Methods");
            Console.WriteLine("05- User-defined Convertion - Explicit/Implicit way");

            int option = 0;
            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1:
                    {
                        SimpleEnum();
                        break;
                    }
                case 2:
                    {
                        FlagsEnum();
                        break;
                    }
                case 3:
                    {
                        Struct();
                        break;
                    }
                case 4:
                    {
                        ExtensionMethod();
                        break;
                    }
                case 5:
                    {
                        UserDefined();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid option...");
                        break;
                    }
            }
        }

        public static void UserDefined()
        {
            MyMoney myMoney = new MyMoney(42.43M);

            decimal dMoney = myMoney;
            int iMoney = (int)myMoney;
            Console.WriteLine($"Implicit decimal value: {dMoney}, Explicit int value: {iMoney}");
        }

        public class MyMoney
        {
            public decimal Quantity { get; set; }
            public MyMoney(decimal q)
            {
                Quantity = q;
            }

            public static implicit operator decimal(MyMoney myMoney)
            {
                return myMoney.Quantity;
            }

            public static explicit operator int(MyMoney myMoney)
            {
                return (int)myMoney.Quantity;
            }
        }

        public static void ExtensionMethod()
        {
            Product product = new Product();
            product.Price = 100;
            Console.WriteLine($"Original Price: {product.Price}. Discounted Price: {product.Discount()}");
        }

        public static void Struct()
        {
            Console.WriteLine("Structs are similar to classes but you can`t inherit and you MUST create a construct with Parameters");
            var coordXY = new CoordXY(4, 5);
            Console.WriteLine(coordXY.ToString());
        }
           
        public struct CoordXY
        {
            public int X;
            public int Y;

            public CoordXY(int cordX, int cordY)
            {
                X = cordX;
                Y = cordY;
            }

            public override string ToString()
            {
                return $"Coord X:{X}, Y:{Y}";
            }
        }

        [Flags]
        public enum Days2
        {
            None = 0x0,
            Saturday = 0x1,
            Sunday = 0x2,
            Monday = 0x4,
            Tuesday = 0x8,
            Wednesday = 0x10,
            Thursday = 0x20,
            Friday = 0x30
        }

        private static void FlagsEnum()
        {
            Console.WriteLine("Using Enum w/ Flags Decorate");

            Days2 d = Days2.Monday | Days2.Saturday;

            Console.WriteLine("Days that can read {0}", d.ToString());
        }

        public enum Days : Byte
        {
            Saturday = 1,
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday
        }

        public static void SimpleEnum()
        {
            Console.WriteLine("Simple Enum that uses base 1");
            Days d = Days.Monday;
            if ((byte)d == 3)
            {
                Console.WriteLine("Today is Monday");
            }
        }
    }

    public class Product
    {
        public decimal Price { get; set; }
    }

    public static class MyExtensions
    {
        public static decimal Discount(this Product product)
        {
            return product.Price * 0.9M;
        }
    }
}
