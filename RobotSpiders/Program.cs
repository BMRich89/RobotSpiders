// See https://aka.ms/new-console-template for more information
using RobotSpiders.Classes;
using RobotSpiders.Enums;
using RobotSpiders.Helpers;

///Capture height and width of wall.
int height = IntInputPrompt.InputPrompt("Enter height of wall (without unit)", "Input must be integer.");
int width = IntInputPrompt.InputPrompt("Enter width of wall (without unit)", "Input must be integer.");

//Capture X and Y co-ordinates of robot position and make sure they are within confines of wall dimensions
int xCoord = IntInputPrompt.InputPromptWithConstraints("Enter X coordinate of robot. Hit enter for 0", "Input must be integer.",0,width,$"X must be between 0 and {width} inclusively");
int yCoord = IntInputPrompt.InputPromptWithConstraints("Enter Y coordinate of robot. Hit enter for 0", "Input must be integer.", 0, height, $"Y must be between 0 and {height} inclusively");

//Capture facing direction of robot, numbers are linked to enum values for direction and remove the need for parsing string inputs.
string facingPrompt = "Enter integer to select facing direction of robot.\n"
                    + "0. Up\n"
                    + "1. Right\n"
                    + "2. Down\n"
                    + "3. Left";

int facing = IntInputPrompt.InputPromptWithConstraints(facingPrompt, "Input must be integer.",0,3,"Input must be either 0,1,2 or 3.");

//Create wall and robot
var wall = new Wall(height, width);
var robot = new Robot(wall, new Position(xCoord, yCoord, (Direction)facing));

Console.WriteLine($"Robot's current position is {robot.ReportPosition()}");
Console.WriteLine("Enter commands as string of characters.");
Console.WriteLine("F - Moves robot forward 1 place in direction robot is facing.");
Console.WriteLine("L - Turns robot left");
Console.WriteLine("R - Turns robot right");
Console.WriteLine("Command can be continous string of characters i.e LFRLFRFFL");

//Allow continuous entry of commands until user opts to terminate session
var closeSession = false;
while(!closeSession)
{
    Console.WriteLine("Please enter command string or 'x' to close session:");
    var commands = Console.ReadLine();
    if (string.Equals(commands, "x", StringComparison.OrdinalIgnoreCase))
    {
        closeSession = true;
    }
    else
    {
        robot.Command(commands);
        Console.WriteLine($"Robot's current position is {robot.ReportPosition()}");
    }
}
Console.WriteLine("Press any key to exit...");
Console.ReadKey();