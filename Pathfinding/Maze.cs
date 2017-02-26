using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    class Maze
    {
        public static int[,] RandoMaze(int WIDTH, int HEIGHT)
        {
            int[,] Maze = new int[HEIGHT, WIDTH];
            int[,] Marked = new int[HEIGHT, WIDTH];

            for(int i = 0; i<HEIGHT; i++)
                for(int j = 0; j<WIDTH; j++)
                {
                    Maze[i, j] = 0;
                    Marked[i, j] = 0;
                }

            return Maze;
        }
    }
}
