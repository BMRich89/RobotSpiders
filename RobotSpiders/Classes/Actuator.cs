using RobotSpiders.Enums;
using RobotSpiders.Interfaces;

namespace RobotSpiders.Classes
{
    /// <summary>
    /// Class used to move process move commands and validate if commands are actionable.
    /// </summary>
    /// <param name="xLimit"></param>
    /// <param name="yLimit"></param>
    internal class Actuator(int xLimit, int yLimit) : IActuator
    {
        private int XLimit { get; set; } = xLimit;
        private int YLimit { get; set; } = yLimit;

        /// <summary>
        /// Method which processes turn command (L/R) and returns new position.
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="turnRight"></param>
        /// <returns>Position</returns>
        public Position Turn(Position currentPosition, bool turnRight)
        {
            //If we're facing left and turning right we need to set direction to up rather than incrementing enum
            if (turnRight && currentPosition.Facing == Direction.Left)
            {
                return new Position(currentPosition.XPosition, currentPosition.YPosition, Direction.Up);
            }

            //If we're facing up and turning left we need to set direction to up rather than decrementing enum
            if (!turnRight && currentPosition.Facing == Direction.Up)
            {
                return new Position(currentPosition.XPosition, currentPosition.YPosition, Direction.Left);
            }

            //We're not in danger of going out of bounds of the enums so decrement/increment direction enum accordingly
            var newFacing = (Direction)(turnRight ? (int)currentPosition.Facing + 1 : (int)currentPosition.Facing - 1);
            return new Position(currentPosition.XPosition, currentPosition.YPosition, newFacing);
        }

        /// <summary>
        /// Method to process move forward command (F) and returns new position.
        /// Checks if we are unable to move forward using XLimit/YLimit
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <returns>Position</returns>
        public Position ContinueForward(Position currentPosition)
        {

            switch (currentPosition.Facing)
            {
                case Direction.Up:
                    if (currentPosition.YPosition != YLimit) 
                    { 
                        return currentPosition.AdjustXYPosition(0, 1); 
                    }
                    break;
                case Direction.Right:
                    if (currentPosition.XPosition != XLimit)
                    {
                        return currentPosition.AdjustXYPosition(1, 0);
                    }
                    break;
                case Direction.Down:
                    if (currentPosition.YPosition != 0)
                    {
                        return currentPosition.AdjustXYPosition(0, -1);
                    }
                    break;
                case Direction.Left:
                    if (currentPosition.XPosition != 0)
                    {
                        return currentPosition.AdjustXYPosition(-1, 0);
                    }
                    break;
            }

            return currentPosition;
        }

    }
}
