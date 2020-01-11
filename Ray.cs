using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ray
{
    class Ray
    {
        private Pixel startPoint;
        private Pixel endPoint;
        public PixelBody Body;

        public Ray(int startX, int startY, int endX, int endY)
        {
            startPoint = new Pixel(startX, startY);
            endPoint = new Pixel(endX, endY);
            Body = new PixelBody();
            GenerateBody();
            //Body.Pixels.Add(startPoint);
            Body.Pixels.Add(endPoint);
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
            //if (toRight == 0 && downwards == 0)
            //{
            //    throw new Exception("line has no demensins");
            //}
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

            double directionCoef =Math.Abs(distX / distY);

            if (distX==0||distY==0)
            {
                GenerateStraightLine();
                return;
            }

            double directionCoef1Plus = directionCoef > 1 ? directionCoef : 1/directionCoef;
            double restrictedMovesMax = (directionCoef1Plus);
            //double coefFloatingPart = Math.Abs(directionCoef1Plus-restrictedMovesMax);

            Pixel currentCell = startPoint;
            while (currentCell.x != endPoint.x && currentCell.y != endPoint.y)
            {
                //currentCell.Draw(); //for debugging
                //endPoint.Draw(); //for debugging

                double moderatedMovesLeft = restrictedMovesMax;
                int freeMovesLeft = 1;
                MoveFreely(ref currentCell, ref moderatedMovesLeft, ref freeMovesLeft);
                //currentCell.Draw(); //for debugging
                RestrictedMovement(ref currentCell, ref moderatedMovesLeft);
            }
        }

        private void RestrictedMovement(ref Pixel currentCell, ref double moderatedMovesLeft)
        {
            while (moderatedMovesLeft > 0)
            {
                Pixel nearestCellSoFar = currentCell;

                var surroundingCells = GetSurroundingCells(currentCell);
                for (int i = 0; i < surroundingCells.Count; i++)
                {
                    Pixel cellOnReview = surroundingCells[i];

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

        private void MoveFreely(ref Pixel currentCell, ref double moderatedMovesLeft, ref int freeMovesLeft)
        {
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
        }
    }
}
