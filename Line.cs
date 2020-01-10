using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray
{
    class Line
    {
        private Pixel startPoint;
        private Pixel endPoint;
        private PixelBody Body;

        public Line(int startX, int startY, int endX, int endY)
        {
            startPoint = new Pixel(startX, startY);
            endPoint = new Pixel(endX, endY);
            Body = new PixelBody();
            Body.Pixels.Add(startPoint);
            Body.Pixels.Add(endPoint);
        }
        public void Draw()
        {
            Body.Pixels.ForEach(p => p.Draw());
        }

        //private GenerateBody()
        //{

        //}
        //public static void MoveFromPlayer(Pixel a, Pixel b)
        //{
        //        Pixel chosenCell = food.SurroundingCells.OrderByDescending(cell => cell.DistanceToPlayer(player))
        //            .Where(cell =>
        //            cell.x != 0 &&
        //            cell.y != 0 &&
        //            cell.x != PlayGround.width - 1 &&
        //            cell.y != PlayGround.hight - 1).First();
        //        food.pixel.x = chosenCell.x;
        //        food.pixel.y = chosenCell.y;
        //}
    }
}
