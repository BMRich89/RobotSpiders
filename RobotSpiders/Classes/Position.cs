using RobotSpiders.Enums;

namespace RobotSpiders.Classes
{
    /// <summary>
    /// Class to model robot positions.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="facing"></param>
    public class Position(int x, int y, Direction facing)
    {
        public int XPosition { get; set; } = x;
        public int YPosition { get; set; } = y;

        public Direction Facing { get; set; } = facing;

        /// <summary>
        /// returns new position based on provided adjustments
        /// </summary>
        /// <param name="XAdjustment"></param>
        /// <param name="YAdjustment"></param>
        /// <returns>Position</returns>
        public Position AdjustXYPosition(int XAdjustment, int YAdjustment)
        {
            int newX = XPosition + XAdjustment;
            int newY = YPosition + YAdjustment;

            return new Position (newX, newY, Facing);
        }

        /// <summary>
        /// Returns user friendly position string.
        /// </summary>
        /// <returns>string</returns>
        public string PrintPosition()
        {
            return $"position is X: {XPosition}, Y: {YPosition}, facing: {Facing}.";
        }

        /// <summary>
        /// Checks for equality between this position and provided one.
        /// </summary>
        /// <param name="aPosition"></param>
        /// <returns>bool</returns>
        public bool IsEqual(Position aPosition)
        { 
            return XPosition == aPosition.XPosition && YPosition == aPosition.YPosition && Facing == aPosition.Facing;
        }
    }
}
