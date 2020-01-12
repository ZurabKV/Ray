using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ray
{
    static class Renderer
    {
        public static void DrawScreen(Screen screen)
        {
            //Console.Clear();
            //string fillament1 = "+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++";
            //string fillament2 = " ";
            //string fillament3 = "----------------------------------------------------------";
            //string fillament = fillament3;
            //Console.WriteLine("012345678901234567890123456789012345678901234567890123456789");
            //Console.WriteLine("1 {0}", fillament);
            //Console.WriteLine("2 {0}", fillament);
            //Console.WriteLine("3 {0}", fillament);
            //Console.WriteLine("4 {0}", fillament);
            //Console.WriteLine("5 {0}", fillament);
            //Console.WriteLine("6 {0}", fillament);
            //Console.WriteLine("7 {0}", fillament);
            //Console.WriteLine("8 {0}", fillament);
            //Console.WriteLine("9 {0}", fillament);
            //Console.WriteLine("0 {0}", fillament);
            //Console.WriteLine("1 {0}", fillament);
            //Console.WriteLine("2 {0}", fillament);
            //Console.WriteLine("3 {0}", fillament);
            //Console.WriteLine("4 {0}", fillament);
            //Console.WriteLine("5 {0}", fillament);
            //Console.WriteLine("6 {0}", fillament);
            //Console.WriteLine("7 {0}", fillament);
            //Console.WriteLine("8 {0}", fillament);
            //Console.WriteLine("9 {0}", fillament);
            //Console.WriteLine("0 {0}", fillament);
            //Console.WriteLine("1 {0}", fillament);
            //Console.WriteLine("2 {0}", fillament);
            //Console.WriteLine("3 {0}", fillament);
            //Console.WriteLine("4 {0}", fillament);
            //Console.WriteLine("5 {0}", fillament);
            //Console.WriteLine("6 {0}", fillament);
            //Console.WriteLine("7 {0}", fillament);
            //Console.WriteLine("8 {0}", fillament);
            //Console.WriteLine("9 {0}", fillament);
            //Console.WriteLine("0 {0}", fillament);


            screen.SquareA.Draw();
            screen.obsticle.Draw();
            screen.light.CastOn(screen.SquareA.Body, screen.obsticle);
        }
    }
}
