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
        private Pixel endPoint; //wall

        public LightRay(Pixel source, Pixel goal, MultipixelObject obsticle, char shape = '.', ConsoleColor color = ConsoleColor.White) : base(shape, color)
        {
            startPoint = source;
            endPoint = goal;
            GenerateBody(obsticle);
        }

        public override void Draw()
        {
            Body.Pixels/*.Skip(Body.Pixels.Count-5).Take(3)*/.ToList().ForEach(p => p.Draw());
        }

        private bool CheckIfIntersectedAnyVisiblePixel(Pixel currentPixel, MultipixelObject obsticle)
        {
            bool result = false;

            foreach (Pixel pixel in obsticle.Body.Pixels)
            {
                if (pixel.x == currentPixel.x && pixel.y == currentPixel.y)
                {
                    result = true;
                    pixel.IsLit = result;
                }
            }

            return result;
        }

        private void GenerateBody(MultipixelObject obsticle)
        {
            double distX = endPoint.x - startPoint.x;
            double distY = endPoint.y - startPoint.y;

            double directionCoef = Math.Abs(distX / distY);

            if (distX == 0 || distY == 0)
            {
                directionCoef=1;
            }

            double directionCoef1Plus = directionCoef > 1 ? directionCoef : 1 / directionCoef;
            double restrictedMovesMaxFloor = Math.Floor(directionCoef1Plus);
            double FloatingPointDelta = directionCoef1Plus - Math.Floor(directionCoef1Plus);
            double moderatedMovesLeft = 0;
            int freeMovesLeft = 0;

            Pixel currentCell = startPoint;
            //currentCell.Draw(); //for debugging
            //endPoint.Draw(); //for debugging

            while ((currentCell.x == endPoint.x && currentCell.y == endPoint.y) == false)
            {
                freeMovesLeft++;
                moderatedMovesLeft += restrictedMovesMaxFloor;
                if (FreeMovement(ref currentCell, ref moderatedMovesLeft, ref freeMovesLeft, obsticle))
                {
                    return;
                }
                ;
                if (RestrictedMovement(ref currentCell, ref moderatedMovesLeft, FloatingPointDelta, obsticle))
                {
                    return;
                }
            }

            endPoint.IsLit = true;
        }

        private bool RestrictedMovement(ref Pixel currentCell, ref double moderatedMovesLeft, double FloatingPointDelta, MultipixelObject obsticle)
        {
            moderatedMovesLeft += FloatingPointDelta;

            while (moderatedMovesLeft >= 1)
            {
                Pixel nearestCellSoFar = currentCell;

                var surroundingCells = GetSurroundingCells(currentCell);

                for (int i = 0; i < surroundingCells.Count; i++)
                {
                    Pixel cellOnReview = surroundingCells[i];

                    var nearestDistanceSoFar = nearestCellSoFar.DistanceToAnotherPixel(endPoint);
                    var distanceOnReviev = cellOnReview.DistanceToAnotherPixel(endPoint);

                    if (distanceOnReviev < nearestDistanceSoFar)
                    {
                        if (cellOnReview.IsNotDiagonalToAnotherNearestPixel(currentCell))
                        {
                            nearestCellSoFar = cellOnReview;
                        }
                    }
                }

                currentCell = nearestCellSoFar;
                moderatedMovesLeft--;
                //currentCell.Draw(); //for debugging

                if (CheckIfIntersectedAnyVisiblePixel(currentCell, obsticle))
                {
                    return true;
                }
                currentCell.shape = Shape;
                currentCell.color = Color;
                Body.Pixels.Add(currentCell);
            }
            return false;
        }

        private bool FreeMovement(ref Pixel currentCell, ref double moderatedMovesLeft, ref int freeMovesLeft, MultipixelObject obsticle)
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

                //currentCell.Draw(); //for debugging
                freeMovesLeft--;
                moderatedMovesLeft--; 

                if (CheckIfIntersectedAnyVisiblePixel(currentCell, obsticle))
                {
                    return true;
                }

                currentCell.shape = Shape;
                currentCell.color = Color;
                Body.Pixels.Add(currentCell);
            }
            return false;
        }
    }
}
