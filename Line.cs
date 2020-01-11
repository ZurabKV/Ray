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

        private void GenerateStraightLine()
        {
            int toRight = endPoint.x - startPoint.x;
            int downwards = endPoint.y - startPoint.y;
            if (toRight!=0&&downwards!=0)
            {
                throw new Exception($"line cannot be straight: startPoint.x = {startPoint.x}, startPoint.y = {startPoint.y};  endPoint.x = {endPoint.x}  endPoint.y = {endPoint.y} ");
            }
            if (toRight == 0 && downwards == 0)
            {
                throw new Exception("line has no demensins");
            }
            if (downwards==0) //the draw horizontally
            {
                if (toRight>0)
                {
                    for (int i = 0; i <= Math.Abs(toRight); i++)
                    {
                        Body.Pixels.Add(new Pixel(startPoint.x + i, startPoint.y));
                    } 
                }
                else
                {
                    for (int i = 0; i <= Math.Abs(toRight); i++)
                    {
                        Body.Pixels.Add(new Pixel(startPoint.x - i, startPoint.y));
                    }
                }
            }
            else //the draw vertically
            {
                if (downwards>0)
                {
                    for (int i = 0; i <= Math.Abs(downwards); i++)
                    {
                        Body.Pixels.Add(new Pixel(startPoint.x, startPoint.y + i));
                    }
                }
                else
                {
                    for (int i = 0; i <= Math.Abs(downwards); i++)
                    {
                        Body.Pixels.Add(new Pixel(startPoint.x, startPoint.y - i));
                    }
                }
            }
        }

        private void GenerateBody()
        {
            double distX = endPoint.x - startPoint.x;
            double distY = endPoint.y - startPoint.y;

            if (distX==0||distY==0)
            {
                GenerateStraightLine();
                return;
            }

            double directionCoef = distX / distY > 1 ? distX / distY : distY / distX;
            double restrictedMovesMax = (directionCoef);
            double coefFloatingPart = directionCoef-restrictedMovesMax;

            Pixel currentCell = startPoint;
            while (currentCell.x != endPoint.x && currentCell.y != endPoint.y)
            {
                //currentCell.Draw(); //for debugging
                //endPoint.Draw(); //for debugging

                double moderatedMovesLeft = restrictedMovesMax;
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
                //currentCell.Draw(); //for debugging
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
                    //currentCell.Draw(); //for debugging
                    moderatedMovesLeft--;
                    Body.Pixels.Add(currentCell);
                }
            }
        }
    }
}
