using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Pathfinding
{
    class Algorithm
    {
        private static bool DFSCompleted = false;
        private static bool BFSCompleted = false;

        public static void initDFS(int x, int y, Node[,] graph)
        {
            DFSCompleted = false;
            DFS(x, y, graph);
        }

        public static Point DFSNextStep(int x, int y, Node[,] graph)
        {
            int columns = graph.GetLength(0);
            int rows = graph.GetLength(1);

            if (graph[x, y].IsGoal)
                return new Point(-1, -1);

            graph[x, y].IsVisited = true;

            if (x + 1 < columns && !graph[x + 1, y].IsSet && !graph[x + 1, y].IsVisited)
                return new Point(x + 1, y);
            else if (x - 1 >= 0 && !graph[x - 1, y].IsSet && !graph[x - 1, y].IsVisited)
                return new Point(x - 1, y);
            else if (y + 1 < rows && !graph[x, y + 1].IsSet && !graph[x, y + 1].IsVisited)
                return new Point(x, y + 1);
            else if (y - 1 >= 0 && !graph[x, y - 1].IsSet && !graph[x, y - 1].IsVisited)
                return new Point(x, y - 1);
            else
                return new Point(-2, -2);

        }
        public static void DFS(int x, int y, Node[,] graph)
        {
            int columns = graph.GetLength(0);
            int rows = graph.GetLength(1);
            if (graph[x, y].IsGoal)
            {
                DFSCompleted = true;
                //                MessageBox.Show("Uspeh\n\n\n\n\n\n\n\n\n\n\nbre");
                return;
            }
            graph[x, y].IsVisited = true;


            if (x + 1 < columns && !graph[x + 1, y].IsSet && !graph[x + 1, y].IsVisited && !DFSCompleted)
                DFS(x + 1, y, graph);

            if (x - 1 >= 0 && !graph[x - 1, y].IsSet && !graph[x - 1, y].IsVisited && !DFSCompleted)
                DFS(x - 1, y, graph);

            if (y + 1 < rows && !graph[x, y + 1].IsSet && !graph[x, y + 1].IsVisited && !DFSCompleted)
                DFS(x, y + 1, graph);

            if (y - 1 >= 0 && !graph[x, y - 1].IsSet && !graph[x, y - 1].IsVisited && !DFSCompleted)
                DFS(x, y - 1, graph);

        }

        public static void initBFS(int x, int y, Node[,] graph)
        {
            BFSCompleted = false;
            BFS(x, y, graph);
        }

        public static void BFS(int x, int y, Node[,] graph)
        {
            int columns = graph.GetLength(0);
            int rows = graph.GetLength(1);
            
            if (graph[x, y].IsGoal)
            {
                DFSCompleted = true;
                return;
            }
            graph[x, y].IsVisited = true;

            Point[] P = new Point[columns * rows];
            P[0] = new Point(x, y);
            int i=1, j=0;

            while (i > j)
            {
                x = P[j].X;
                y = P[j].Y;



                if (x + 1 < columns && !graph[x + 1, y].IsSet && !graph[x + 1, y].IsVisited && !BFSCompleted)
                {
                    P[i++] = new Point(x + 1, y);
                    graph[x + 1, y].IsVisited = true;
                    if (graph[x + 1, y].IsGoal)
                    {
                        BFSCompleted = true;
                        break;
                    }
                }

                if (x - 1 >= 0 && !graph[x - 1, y].IsSet && !graph[x - 1, y].IsVisited && !BFSCompleted)
                {
                    P[i++] = new Point(x - 1, y);
                    graph[x - 1, y].IsVisited = true;
                    if (graph[x - 1, y].IsGoal)
                    {
                        BFSCompleted = true;
                        break;
                    }
                }

                if (y + 1 < rows && !graph[x, y + 1].IsSet && !graph[x, y + 1].IsVisited && !BFSCompleted)
                {
                    P[i++] = new Point(x, y + 1);
                    graph[x, y + 1].IsVisited = true;
                    if (graph[x, y+1].IsGoal)
                    {
                        BFSCompleted = true;
                        break;
                    }
                }

                if (y - 1 >= 0 && !graph[x, y - 1].IsSet && !graph[x, y - 1].IsVisited && !BFSCompleted)
                {
                    P[i++] = new Point(x, y - 1);
                    graph[x, y - 1].IsVisited = true;
                    if (graph[x, y-1].IsGoal)
                    {
                        BFSCompleted = true;
                        break;
                    }
                }
                j++;
            }
        }


    }
}
