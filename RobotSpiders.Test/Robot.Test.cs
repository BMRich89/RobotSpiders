using RobotSpiders.Classes;
using RobotSpiders.Interfaces;

namespace RobotSpiders.Test
{
    [TestClass]
    public class RobotTest
    {
        IRobot robot;
        readonly string moveForward = "F";
        readonly string turnLeft = "L";
        readonly string turnRight = "R";
        readonly Position startPosition = new Position(1, 1, Enums.Direction.Up);

        [TestInitialize]
        public void TestInitialize()
        {
            var wall = new Wall(5, 5);
            var position = startPosition;
            robot = new Robot(wall,position);
        }

        [TestMethod]
        public void MoveForwardFacingUp_IncrementsY()
        {
            robot.Command(moveForward);
            Assert.IsTrue(robot.Position.YPosition == startPosition.YPosition + 1);
        }

        [TestMethod]
        public void MoveForwardFacingDown_DecrementsY()
        {
            robot.Command(turnRight);
            robot.Command(turnRight);
            robot.Command(moveForward);
            Assert.IsTrue(robot.Position.YPosition == startPosition.YPosition - 1);
        }

        [TestMethod]
        public void MoveForwardFacingRight_IncrementsX()
        {
            robot.Command(turnRight);
            robot.Command(moveForward);
            Assert.IsTrue(robot.Position.XPosition == startPosition.XPosition + 1);

        }

        [TestMethod]
        public void TurnRightFromStart_ReturnsRightFacing()
        {
            robot.Command(turnRight);
            Assert.IsTrue(robot.Position.Facing == Enums.Direction.Right);
        }

        [TestMethod]
        public void TurningRightFourTimes_ReturnToOriginalDirection()
        {
            robot.Command(turnRight);
            robot.Command(turnRight);
            robot.Command(turnRight);
            robot.Command(turnRight);
            Assert.IsTrue(robot.Position.Facing == startPosition.Facing);
        }

        [TestMethod]
        public void TurningLeftFourTimes_ReturnToOriginalDirection()
        {
            robot.Command(turnLeft);
            robot.Command(turnLeft);
            robot.Command(turnLeft);
            robot.Command(turnLeft);
            Assert.IsTrue(robot.Position.Facing == startPosition.Facing);
        }

        [TestMethod]
        public void MoveForwardFacingLeft_DecrementsX()
        {
            robot.Command(turnLeft);
            robot.Command(moveForward);
            Assert.IsTrue(robot.Position.XPosition == startPosition.XPosition - 1);
        }

        [TestMethod]
        public void TurnLeftFromStart_ReturnsLeftFacing()
        {
            robot.Command(turnLeft);
            Assert.IsTrue(robot.Position.Facing == Enums.Direction.Left);
        }

        [TestMethod]
        public void InvalidCommand_PreventsAction()
        {
            robot.Command("T");
            Assert.IsTrue(robot.Position.IsEqual(startPosition));
        }

        [TestMethod]
        public void MovingForwardAtEndOfXAxis_DoesNothing()
        {
            var wall = new Wall(2, 2);
            var position = new Position(2, 1, Enums.Direction.Right);
            var thisRobot = new Robot(wall, position);
            thisRobot.Command("F");

            Assert.IsTrue(thisRobot.Position.IsEqual(position));
        }

        [TestMethod]
        public void MovingForwardAtEndOfYAxis_DoesNothing()
        {
            var wall = new Wall(2, 2);
            var position = new Position(1, 2, Enums.Direction.Up);
            var thisRobot = new Robot(wall, position);
            thisRobot.Command("F");

            Assert.IsTrue(thisRobot.Position.IsEqual(position));
        }

        [TestMethod]
        public void MovingBackwardAtStartOfYAxis_DoesNothing()
        {
            var wall = new Wall(2, 2);
            var position = new Position(1, 0, Enums.Direction.Down);
            var thisRobot = new Robot(wall, position);
            thisRobot.Command("F");

            Assert.IsTrue(thisRobot.Position.IsEqual(position));
        }

        [TestMethod]
        public void MovingForwardAtStartOfXAxis_DoesNothing()
        {
            var wall = new Wall(2, 2);
            var position = new Position(0, 1, Enums.Direction.Left);
            var thisRobot = new Robot(wall, position);
            thisRobot.Command("F");

            Assert.IsTrue(thisRobot.Position.IsEqual(position));
        }

        [TestMethod]
        public void TechTest_ExampleInput_HasCorrectOutput()
        {
            var wall = new Wall(7, 15);
            var position = new Position(2, 4, Enums.Direction.Left);
            var robot = new Robot(wall, position);

            robot.Command("FLFLFRFFLF");

            Assert.IsTrue(robot.Position.XPosition == 3);
            Assert.IsTrue(robot.Position.YPosition == 1);
            Assert.IsTrue(robot.Position.Facing == Enums.Direction.Right);
        }        
    }
}