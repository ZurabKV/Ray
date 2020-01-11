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
            GenerateBody();
            //Body.Pixels.Add(startPoint);
            //Body.Pixels.Add(endPoint);
        }
        public void Draw()
        {
            Body.Pixels.ForEach(p => p.Draw());
        }

        public List<Pixel> GetSurroundingCells(Pixel pixel)
        {
            return new List<Pixel>
            {
                new Pixel(pixel.x-1,pixel.y-1),
                new Pixel(pixel.x,  pixel.y-1),
                new Pixel(pixel.x+1,pixel.y-1),
                new Pixel(pixel.x-1,pixel.y),
                new Pixel(pixel.x+1,pixel.y),
                new Pixel(pixel.x-1,pixel.y+1),
                new Pixel(pixel.x,  pixel.y+1),
                new Pixel(pixel.x+1,pixel.y+1),
            };
        }


        //private void GenerateBody()
        //{
        //    Console.WriteLine("0123456789");
        //    Console.WriteLine("1---------");
        //    Console.WriteLine("2---------");
        //    Console.WriteLine("3---------");
        //    Console.WriteLine("4---------");
        //    Console.WriteLine("5---------");

        //    Pixel chosenCell = startPoint;
        //    while (chosenCell.x != endPoint.x && chosenCell.y != endPoint.y) 
        //    {
        //        chosenCell.Draw();
        //        endPoint.Draw();

        //        int distX = endPoint.x - startPoint.x;
        //        int distY = endPoint.y - startPoint.y;
        //        double directionCoef = distX / distY > 1 ? distX / distY : distY / distX;
        //        int stepsInOneDirectionMade = 0;
        //        int diagonalstepsMade = 0;

        //        var surroundingCells = GetSurroundingCells(chosenCell);
        //        foreach (Pixel cell in surroundingCells)
        //        {
        //            var chosenDist = chosenCell.DistanceToAnotherPixel(endPoint);
        //            var dist = cell.DistanceToAnotherPixel(endPoint);

        //            if (dist < chosenDist)
        //            {
        //                chosenCell = cell;
        //            }
        //        }
        //        Body.Pixels.Add(chosenCell);


        //        //chosenCell = GetSurroundingCells(chosenCell)
        //        //    .OrderBy(cell => cell.DistanceToAnotherPixel(endPoint))
        //        //    .First();
        //    }
        //}

        private void GenerateBody()
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
            Console.WriteLine("0---------------------------------------");
            Console.WriteLine("1---------------------------------------");
            Console.WriteLine("2---------------------------------------");
            Console.WriteLine("3---------------------------------------");
            Console.WriteLine("4---------------------------------------");
            Console.WriteLine("5---------------------------------------");
            Console.WriteLine("6---------------------------------------");
            Console.WriteLine("7---------------------------------------");
            Console.WriteLine("8---------------------------------------");
            Console.WriteLine("9---------------------------------------");
            Console.WriteLine("0---------------------------------------");
            Console.WriteLine("1---------------------------------------");
            Console.WriteLine("2---------------------------------------");
            Console.WriteLine("3---------------------------------------");
            Console.WriteLine("4---------------------------------------");
            Console.WriteLine("5---------------------------------------");
            Console.WriteLine("6---------------------------------------");
            Console.WriteLine("7---------------------------------------");
            Console.WriteLine("8---------------------------------------");
            Console.WriteLine("9---------------------------------------");
            Console.WriteLine("0---------------------------------------");

            int distX = endPoint.x - startPoint.x;
            int distY = endPoint.y - startPoint.y;
            double directionCoef = distX / distY > 1 ? distX / distY : distY / distX;
            int moderatedMovesMax = (int)Math.Round(directionCoef);

            Pixel currentCell = startPoint;
            while (currentCell.x != endPoint.x && currentCell.y != endPoint.y)
            {
                currentCell.Draw(); //for debugging
                endPoint.Draw(); //for debugging

                int moderatedMovesLeft = moderatedMovesMax;
                int freeMovesLeft = 1;

                while (freeMovesLeft >= 1)
                {
                    var surroundingCells = GetSurroundingCells(currentCell);
                    foreach (Pixel cell in surroundingCells)
                    {
                        var chosenDist = currentCell.DistanceToAnotherPixel(endPoint);
                        var dist = cell.DistanceToAnotherPixel(endPoint);

                        if (dist < chosenDist)
                        {
                            currentCell = cell;
                        }
                    }

                    freeMovesLeft--;
                    moderatedMovesLeft--;
                    Body.Pixels.Add(currentCell);
                }
                currentCell.Draw(); //for debugging
                while (moderatedMovesLeft > 0)
                {
                    Pixel nearestCellSoFar = currentCell;

                    var surroundingCells = GetSurroundingCells(currentCell);
                    for (int i = 0; i < surroundingCells.Count; i++)
                    {
                        Pixel cellOnReview = surroundingCells[i];
                        cellOnReview.SetCursorOnIt();

                        var nearestDistanceSoFar = nearestCellSoFar.DistanceToAnotherPixel(endPoint);
                        var distanceOnReviev = cellOnReview.DistanceToAnotherPixel(endPoint);

                        if (distanceOnReviev < nearestDistanceSoFar)//
                        {
                            if (cellOnReview.IsNotDiagonalToAnotherNearestPixel(currentCell))
                            {
                                nearestCellSoFar = cellOnReview;
                            }
                        }
                    }
                    currentCell = nearestCellSoFar;
                    currentCell.Draw(); //for debugging
                    moderatedMovesLeft--;
                    Body.Pixels.Add(currentCell);
                }
            }
        }
    }
}
