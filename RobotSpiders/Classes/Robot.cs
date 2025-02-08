using RobotSpiders.Enums;
using RobotSpiders.Interfaces;

namespace RobotSpiders.Classes
{
    /// <summary>
    /// Class to represent robot spider.
    /// Takes wall and position objects as input.
    /// </summary>
    /// <param name="wall"></param>
    /// <param name="position"></param>
    public class Robot(Wall wall, Position position) : IRobot
    {
        public Position Position { get; set; } = new Position(position.XPosition, position.YPosition, position.Facing);
        private readonly IActuator _actuator = new Actuator(wall.Height, wall.Width);

        /// <summary>
        /// Receives command string and processes each command iteratively.
        /// </summary>
        /// <param name="inputs"></param>
        public void Command(string inputs)
        {
            foreach (var input in inputs)
            {
                //Try to parse command using Inputs enum if not recognised do nothing.
                if (Enum.TryParse(input.ToString(), out Inputs inputEnum))
                {
                    ProcessCommand(inputEnum);
                }
            }
        }

        /// <summary>
        /// Takes single command and calls relevant method on actuator.
        /// </summary>
        /// <param name="input"></param>
        public void ProcessCommand(Inputs input)
        {
            switch (input)
            {
                case Inputs.L:
                    Position = _actuator.Turn(Position, false);
                    break;
                case Inputs.F:
                    Position = _actuator.ContinueForward(Position);
                    break;
                case Inputs.R:
                    Position = _actuator.Turn(Position, true);
                    break;
            }
        }

        /// <summary>
        /// Gives user friendly string describing robot position.
        /// </summary>
        /// <returns></returns>
        public string ReportPosition() => Position.PrintPosition();
    }
}
