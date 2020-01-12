using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ray.MultipixelObjects
{
    class LightRay : MultipixelObject
    {
        private Pixel startPoint;
        private Pixel endPoint;

        public LightRay(Pixel source, Pixel goal, ref MultipixelObject obsticle, char shape = '.', ConsoleColor color = ConsoleColor.White) : base(shape, color)
        {
            startPoint = source;
            endPoint = goal;
            GenerateBody( ref obsticle);
        }

        private bool CheckIfIntersectedAnyVisiblePixel(Pixel currentPixel,  ref MultipixelObject obsticle)
        {
            bool result = false;
            foreach (Pixel block in obsticle.Body.Pixels)
            {
                if (block.x == currentPixel.x && block.y == currentPixel.y)
                {
                    result = true;
                    block.IsLit = result;
                }
            }
            return result;
        }

        private void GenerateStraightLine(ref MultipixelObject obsticle)
        {
            int toRight = endPoint.x - startPoint.x;
            int downwards = endPoint.y - startPoint.y;

            if (toRight != 0 && downwards != 0)
            {
                throw new Exception($"line is not straight: startPoint.x = {startPoint.x}, startPoint.y = {startPoint.y};  endPoint.x = {endPoint.x}  endPoint.y = {endPoint.y} ");
            }

            if (downwards == 0) // to draw horizontally
            {
                if (toRight > 0)
                {
                    for (int i = 0; i <= Math.Abs(toRight); i++)
                    {
                        Pixel currentPixel = new Pixel(startPoint.x + i, startPoint.y, Shape, Color);
                        if (CheckIfIntersectedAnyVisiblePixel(currentPixel, ref obsticle))
                        {
                            break;
                        }
                        Body.Pixels.Add(currentPixel);
                    }
                }

                else
                {
                    for (int i = 0; i <= Math.Abs(toRight); i++)
                    {
                        Pixel currentPixel = new Pixel(startPoint.x - i, startPoint.y, Shape, Color);
                        if (CheckIfIntersectedAnyVisiblePixel(currentPixel, ref obsticle))
                        {
                            break;
                        }
                        Body.Pixels.Add(currentPixel);
                    }
                }
            }

            else //the draw vertically
            {
                if (downwards > 0)
                {
                    for (int i = 0; i <= Math.Abs(downwards); i++)
                    {
                        Pixel currentPixel = new Pixel(startPoint.x, startPoint.y + i, Shape, Color);
                        if (CheckIfIntersectedAnyVisiblePixel(currentPixel, ref obsticle))
                        {
                            break;
                        }
                        Body.Pixels.Add(currentPixel);
                    }
                }

                else
                {
                    for (int i = 0; i <= Math.Abs(downwards); i++)
                    {
                        Pixel currentPixel = new Pixel(startPoint.x, startPoint.y - i, Shape, Color);
                        if (CheckIfIntersectedAnyVisiblePixel(currentPixel, ref obsticle))
                        {
                            break;
                        }
                        Body.Pixels.Add(currentPixel);
                    }
                }
            }
        }

        protected void GenerateBody(ref MultipixelObject obsticle)
        {
            double distX = endPoint.x - startPoint.x;
            double distY = endPoint.y - startPoint.y;

            double directionCoef = Math.Abs(distX / distY);

            if (distX == 0 || distY == 0)
            {
                GenerateStraightLine(ref obsticle);
                return;
            }

            double directionCoef1Plus = directionCoef > 1 ? directionCoef : 1 / directionCoef;
            double restrictedMovesMax = (directionCoef1Plus);
            //double coefFloatingPart = Math.Abs(directionCoef1Plus-restrictedMovesMax);

            Pixel currentCell = startPoint;
            while (currentCell.x != endPoint.x && currentCell.y != endPoint.y)
            {
                //currentCell.Draw(); //for debugging
                //endPoint.Draw(); //for debugging

                double moderatedMovesLeft = restrictedMovesMax;
                int freeMovesLeft = 1;
                MoveFreely(ref currentCell, ref moderatedMovesLeft, ref freeMovesLeft, ref obsticle);
                //currentCell.Draw(); //for debugging
                RestrictedMovement(ref currentCell, ref moderatedMovesLeft, ref obsticle);
            }
        }

        private void RestrictedMovement(ref Pixel currentCell, ref double moderatedMovesLeft, ref MultipixelObject obsticle)
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
                if (CheckIfIntersectedAnyVisiblePixel(currentCell, ref obsticle))
                {
                    break;
                }
                Body.Pixels.Add(currentCell);
            }
        }

        private void MoveFreely(ref Pixel currentCell, ref double moderatedMovesLeft, ref int freeMovesLeft, ref MultipixelObject obsticle)
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
                if (CheckIfIntersectedAnyVisiblePixel(currentCell, ref obsticle))
                {
                    break;
                }
                Body.Pixels.Add(currentCell);
            }
        }
    }
}
