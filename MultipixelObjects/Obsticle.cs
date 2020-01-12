using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ray.MultipixelObjects
{
    class Obsticle : MultipixelObject
    {
        public Obsticle(char shape , ConsoleColor color) : base(shape, color)
        {

        }

        public void AddLineBody(Pixel startPoint, Pixel endPoint)
        {
            double distX = endPoint.x - startPoint.x;
            double distY = endPoint.y - startPoint.y;

            double directionCoef = Math.Abs(distX / distY);

            if (distX == 0 || distY == 0)
            {
                directionCoef = 1;
            }

            double directionCoef1Plus = directionCoef > 1 ? directionCoef : 1 / directionCoef;
            double restrictedMovesMaxFloor = Math.Floor(directionCoef1Plus);
            double FloatingPointDelta = directionCoef1Plus - Math.Floor(directionCoef1Plus);
            double moderatedMovesLeft = 0;
            int freeMovesLeft = 0;

            Pixel currentCell = startPoint;

            while ((currentCell.x == endPoint.x && currentCell.y == endPoint.y) == false)
            {
                freeMovesLeft++;
                moderatedMovesLeft += restrictedMovesMaxFloor;
                FreeMovement(ref currentCell, ref moderatedMovesLeft, ref freeMovesLeft, startPoint, endPoint);
                RestrictedMovement(ref currentCell, ref moderatedMovesLeft, FloatingPointDelta, startPoint, endPoint);
            }
        }

        private void RestrictedMovement(ref Pixel currentCell, ref double moderatedMovesLeft, double FloatingPointDelta, Pixel startPoint, Pixel endPoint)
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

                currentCell.shape = Shape;
                currentCell.color = Color;
                Body.Pixels.Add(currentCell);
            }
        }

        private void FreeMovement(ref Pixel currentCell, ref double moderatedMovesLeft, ref int freeMovesLeft, Pixel startPoint, Pixel endPoint)
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

                currentCell.shape = Shape;
                currentCell.color = Color;
                Body.Pixels.Add(currentCell);
            }
        }
    }
}
