using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pathfinding
{
    public class Node
    {
        public Rectangle Bounds { get; set; }
        public bool IsSet { get; set; }
        public bool IsGoal { get; set; }
        public bool IsVisited { get; set; }
        public bool IsClosed { get; set; }
    }

}
