using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Classes
{
    /// <summary>
    /// Used to model Wall in scenario. Provide constraint to robot spider.
    /// </summary>
    /// <param name="height"></param>
    /// <param name="width"></param>
    public class Wall(int height, int width)
    {
        public int Height { get; set; } = height;
        public int Width { get; set; } = width;
    }
}
