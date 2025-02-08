using RobotSpiders.Classes;
using RobotSpiders.Enums;

namespace RobotSpiders.Interfaces
{
    internal interface IActuator
    {
        public Position Turn(Position currentPosition,bool turnRight);
        public Position ContinueForward(Position currentPosition);
    }
}