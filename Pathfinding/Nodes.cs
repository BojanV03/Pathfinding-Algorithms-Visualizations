using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pathfinding
{
    class Nodes
    {
        public static int WIDTH = 48;
        public static int HEIGHT = 22;
        public static Node[,] Graph;

        public Nodes(Form F1)
        {
            Size BtnSize = new Size(F1.Width / WIDTH, (F1.Height - 80) / HEIGHT);
            double WJump = (F1.Width / WIDTH), HJump = ((F1.Height - 80) / HEIGHT);
            Graph = new Node[HEIGHT, WIDTH];
            Node.GoalCount = 0;
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    Graph[i, j] = new Node();
                    Graph[i, j].getButton().Location = new Point((int)(j * WJump), (int)(i * HJump));
                    Graph[i, j].getButton().Size = BtnSize;
                    Graph[i, j].setI(i);
                    Graph[i, j].setJ(j);
                    F1.Controls.Add(Graph[i, j].getButton());
                }
            }
        }

        public static void MazeGen()    //TODO: make it work
        {
            int i, j;
            Nodes.UnMarkAll();
            for (i = 0; i < HEIGHT; i++)
                for (j = 0; j < WIDTH; j++)
                {
                    if (Graph[i, j].isBarrier())
                        Graph[i, j].toggleBarrier();
                }
            MessageBox.Show("Obrisano");
            MazeGenDFS(Graph[0, 0]);
            for(i = 0; i < HEIGHT; i++)
                for(j = 0; j < WIDTH; j++)
                {
                    Graph[i, j].toggleBarrier();
                }

     //       Nodes.UnMarkAll();
        }   //some other time perhaps
        private static int MazeGenDFS(Node Start)
        {
            bool ret = true;
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    if (!Graph[i, j].isMarked())
                        ret = false;
                }
            }
            if (ret)
                return 0;
            Node[] Neighbours = getUnmarkedNeighbours(Start, false).Where(c => c != null && !c.isBarrier()).ToArray();
            bool NeighboursLeft = true;
            Random R = new Random();
            Start.mark();
            Start.toggleBarrier();
            while(NeighboursLeft && Neighbours.Length > 0)
            {
                NeighboursLeft = false;

                int index = R.Next() % Neighbours.Length;
                while(Neighbours[index].isBarrier())
                {
                    index = R.Next() % Neighbours.Length;
                }
                if(MazeGenDFS(Neighbours[index]) == 1)
                    return 1;
                for (int i=0; i<Neighbours.Length; i++)
                {
                    if (!Neighbours[i].isBarrier())
                        NeighboursLeft = true;
                }
            }
            return 0;
        }

        public static void RandBarrier()    //random fill
        {
            Random R = new Random();
            for(int i = 0; i < HEIGHT; i++)
                for(int j = 0; j < WIDTH; j++)
                {
                    if (R.Next() % 4 == 0 && !Graph[i, j].getGoal())
                        Graph[i, j].toggleBarrier();
                }
        }

        public static void UnMarkAll()
        {
            for (int i = 0; i < HEIGHT; i++)
                for (int j = 0; j < WIDTH; j++)
                {
                    if (Graph[i, j].isMarked() && !Graph[i, j].isBarrier())
                        Graph[i, j].ToggleMark();
                    Graph[i, j].CameFrom = null;
                    Graph[i, j].gScore = 55126;
                    Graph[i, j].fScore = 0;
                }
        }
        public static void Azvezda(Node Start)
        {
            if (Start.isBarrier() || Start.getGoal())
            {
                MessageBox.Show("Nemoš tako!");
            }
            else
                Astar(Start);
        }
        private static int Astar(Node Start)
        {
            Node[] Neighbours = getUnmarkedNeighbours(Start, true).Where(c => c != null && !c.isMarked()).ToArray();

            for(int i = 0; i < HEIGHT; i++)
                for(int j = 0; j < WIDTH; j++)
                {
                    Graph[i,j].calcDistanceToGoal();
                }

       //     MessageBox.Show("");
            Start.gScore = 0;
            Start.getButton().Text = "0";
            Neighbours[0] = Start;

            while (Neighbours.Length > 0)
            {
                Neighbours = Neighbours.OrderBy(x => x.fScore).ToArray();

                if(Neighbours[0].getGoal()) //reached the goal?
                {
                    if(Neighbours[0].CameFrom == null)  //failed to reconstruct path?
                        MessageBox.Show("Failed to find path, report to Boki");
                    else
                        MessageBox.Show("Shortest path of length " + Math.Round(Neighbours[0].gScore, 2) + " found");

                    ReconstructAzvezda(Neighbours[0].CameFrom);
                    return 2;
                }

                else
                {
                    if(!Neighbours[0].isMarked() && !Neighbours[0].isBarrier())
                    {
                        Node[] backUp = getUnmarkedNeighbours(Neighbours[0], true).Where(c => c != null).ToArray();
                        for (int i = 0; i < backUp.Length; i++)
                        {
                            if (true)
                            {
                                int x1 = Neighbours[0].getJ(), x2 = backUp[i].getJ();
                                int y1 = Neighbours[0].getI(), y2 = backUp[i].getI();
                                double dist = Neighbours[0].gScore + Math.Sqrt(((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)));
                                if (dist < backUp[i].gScore)
                                {
                                    backUp[i].CameFrom = Neighbours[0];
                                    backUp[i].gScore = dist;
                                    backUp[i].fScore = dist + backUp[i].getDist();
                                }
                                backUp[i].getButton().Text = backUp[i].gScore.ToString();
                            }
                        }
                        Neighbours[0].mark();
                        Neighbours[0].getButton().Visible = false;
                        Neighbours[0].getButton().Visible = true;
                        Neighbours = Neighbours.Concat(backUp).ToArray();
                    }
                    Neighbours = Neighbours.Skip(1).ToArray();
                }

            }
            MessageBox.Show("ne postoji put");
            return 0;

        }
        private static int ReconstructAzvezda(Node n)
        {
            while (n != null)
            {
                n.getButton().BackColor = Color.Orange;
                n = n.CameFrom;
            }

            return 1;
        }
        public static void BreadthFirstSearch(Node Start)
        {
            if (Start.isBarrier() || Start.getGoal())
            {
                MessageBox.Show("Nemoš tako!");
            }
            else
                BFS(Start);
        }
        private static int BFS(Node Start)
        {
            Node[] Neighbours = getUnmarkedNeighbours(Start, false).Where(c => c != null).ToArray();
            int k = 0;

            while (Neighbours[k] != null)
            {
                if (Neighbours[k].getGoal())
                {
                    MessageBox.Show("Stigli smo do cilja, ura!");
                    return 1;
                }
                if (!Neighbours[k].isMarked() && !Neighbours[k].isBarrier())
                {

                    Neighbours = Neighbours.Concat(getUnmarkedNeighbours(Neighbours[k], false).Where(c => c != null).ToArray()).ToArray();
                    Neighbours[k].mark();
                    Neighbours[k].getButton().Visible = false;
                    Neighbours[k].getButton().Visible = true;
                    System.Threading.Thread.Sleep(10);
                }
                k++;
                if(k>=Neighbours.Length)
                {
                    MessageBox.Show("Ne postoji put");
                    return 0;
                }
            }
            return 0;
        }
        public static void DepthFirstSearch(Node Start)
        {

            if (Start.isBarrier() || Start.getGoal())
            {
                MessageBox.Show("Nemoš tako!");
            }
            else
                if (DFS(Start) == 0)
                MessageBox.Show("Ne postoji put :/");
        }
        private static int DFS(Node Start)
        {
            if (Start.getGoal())
            {
                MessageBox.Show("Stigli smo do cilja, ura!");
                return 1;
            }
            else
            {
                int k=0;
                Start.mark();
                Start.getButton().Visible = false;
                Start.getButton().Visible = true;
                System.Threading.Thread.Sleep(10);
                Start.getButton().BackColor = Color.Blue;
                Node[] Neighbours =  getUnmarkedNeighbours(Start, false);
                while(Neighbours[k] != null )
                {
                    if (!Neighbours[k].isMarked() && !Neighbours[k].isBarrier())
                        if (DFS(Neighbours[k]) == 1)
                        {
            //                Neighbours[k].getButton().BackColor = Color.Orange;
                            return 1;
                        }
                    k++;
                }
                return 0;
            }
        }

        public static Node[] getUnmarkedNeighbours(Node Start, bool Diagonal)
        {
            Node[] Neighbours = new Node[9];
            int k = 0;
            int i = Start.getI(), j = Start.getJ();
            if (i > 0)
            {
                if (!Graph[i - 1, j].isMarked())
                {
                    Neighbours[k] = Graph[i - 1, j];
                    k++;
                }
                if (j > 0)
                {
                    if (Diagonal && !Graph[i - 1, j - 1].isMarked() && !Graph[i, j - 1].isBarrier() && !Graph[i - 1, j].isBarrier())
                        Neighbours[k++] = Graph[i - 1, j - 1];
                }
                if (j < WIDTH - 1)
                {
                    if (Diagonal && !Graph[i - 1, j + 1].isMarked() && !Graph[i, j + 1].isBarrier() && !Graph[i - 1, j].isBarrier())
                        Neighbours[k++] = Graph[i - 1, j + 1];
                }
            }
            if (i < HEIGHT-1)
            {
                if (!Graph[i + 1, j].isMarked())
                {
                    Neighbours[k] = Graph[i + 1, j];
                    k++;
                }
                if (j > 0)
                {
                    if (Diagonal && !Graph[i + 1, j - 1].isMarked() && !Graph[i, j - 1].isBarrier() && !Graph[i + 1, j].isBarrier())
                        Neighbours[k++] = Graph[i + 1, j - 1];
                }
                if (j < WIDTH - 1)
                {
                    if (Diagonal && !Graph[i + 1, j + 1].isMarked() && !Graph[i, j + 1].isBarrier() && !Graph[i + 1, j].isBarrier())
                        Neighbours[k++] = Graph[i + 1, j + 1];
                }
            }

            if (j > 0)
            {
                if (!Graph[i, j - 1].isMarked())
                {
                    Neighbours[k] = Graph[i, j - 1];
                    k++;
                }
            }
            if (j < WIDTH - 1)
            {
                if (!Graph[i, j + 1].isMarked())
                {
                    Neighbours[k] = Graph[i, j + 1];
                    k++;
                }
            }
            while(k<9)
            {
                Neighbours[k++] = null;
            }
            return Neighbours;
        }
    }
}
