using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray
{
    class Screen
    {
        public PlayGround SquareA { get; set; }
        public Line line0 { get; set; }
        public Line line20 { get; set; }
        public Line line45 { get; set; }
        public Line line70 { get; set; }
        public Line line90 { get; set; }
        public Line line110 { get; set; }
        public Line line135 { get; set; }
        public Line line160 { get; set; }
        public Line line180 { get; set; }
        public Line line200 { get; set; }
        public Line line225 { get; set; }
        public Line line250 { get; set; }
        public Line line275{ get; set; }
        public Line line270 { get; set; }
        public Line line290 { get; set; }
        public Line line315 { get; set; }
        public Line line340 { get; set; }
        public Screen()
        {
            Console.WriteLine("0123456789012345678901234567890123456789");
            Console.WriteLine("1---------------------------------------");
            Console.WriteLine("2---------------------------------------");
            Console.WriteLine("3---------------------------------------");
            Console.WriteLine("4---------------------------------------");
            Console.WriteLine("5---------------------------------------");
            Console.WriteLine("6---------------------------------------");
            Console.WriteLine("7---------------------------------------");
            Console.WriteLine("8---------------------------------------");
            Console.WriteLine("9---------------------------------------");
            Console.WriteLine("10---------------------------------------");
            Console.WriteLine("11---------------------------------------");
            Console.WriteLine("12---------------------------------------");
            Console.WriteLine("13---------------------------------------");
            Console.WriteLine("14---------------------------------------");
            Console.WriteLine("15---------------------------------------");
            Console.WriteLine("16---------------------------------------");
            Console.WriteLine("17---------------------------------------");
            Console.WriteLine("18---------------------------------------");
            Console.WriteLine("19---------------------------------------");
            Console.WriteLine("20---------------------------------------");
            Console.WriteLine("21---------------------------------------");
            Console.WriteLine("22---------------------------------------");
            Console.WriteLine("23---------------------------------------");
            Console.WriteLine("24---------------------------------------");
            Console.WriteLine("25---------------------------------------");
            Console.WriteLine("26---------------------------------------");
            Console.WriteLine("27---------------------------------------");
            Console.WriteLine("28---------------------------------------");
            Console.WriteLine("29---------------------------------------");
            Console.WriteLine("30---------------------------------------");
            SquareA = new PlayGround(40, 30, 0, 0, '#', ConsoleColor.DarkCyan);

            line0 = new Line(20, 15, 38, 15);
            line20 = new Line(20, 15, 38, 12);
            line45 = new Line(20, 15, 30, 5);
            line70 = new Line(20, 15, 23, 5);
            line90 = new Line(20, 15, 20, 3);
            line110 = new Line(20, 15, 15, 3);
            line135 = new Line(20, 15, 10, 5);
            line160 = new Line(20, 15, 5, 12);
            line180 = new Line(20, 15, 3, 15);
            line200 = new Line(20, 15, 3, 18);
            line225 = new Line(20, 15, 10, 25);
            line250 = new Line(20, 15, 17, 28);
            line270 = new Line(20, 15, 20, 28);
            line290 = new Line(20, 15, 23, 28);
            line315 = new Line(20, 15, 30, 25);
            line340 = new Line(20, 15, 35, 18);

        }
    }
}
