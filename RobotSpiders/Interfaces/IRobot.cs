using RobotSpiders.Classes;
using RobotSpiders.Enums;

namespace RobotSpiders.Interfaces
{
    public interface IRobot
    {
        public Position Position { get; }
        string ReportPosition();
        void Command(string input);
    }
}