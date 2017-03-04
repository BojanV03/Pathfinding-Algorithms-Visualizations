using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pathfinding
{
    class Node
    {
        private Button b;
        public double DistanceToGoal;        //za A*
        private bool Barrier;
        private bool Marked;
        private bool Goal;
        private int i, j;
        private static int GoalX, GoalY;
        static bool dragDraw = false;
        public double gScore = 55126;
        public double fScore = 0;
        public bool Scored = false;
        public Node CameFrom = null;

        public static int GoalCount = 0;


        public void ToggleMark()
        {
            Marked = !Marked;
            if (Marked)
            {
                b.BackColor = Color.MediumSpringGreen;
            }
            else
                b.BackColor = Color.NavajoWhite;
        }

        public int getI()
        {
            return i;
        }

        public int getJ()
        {
            return j;
        }

        public void setI(int a)
        {
            i = a;
        }

        public void setJ(int a)
        {
            j = a;
        }
        public Node(Node N)
        {
            DistanceToGoal = N.DistanceToGoal;
            Barrier = N.Barrier;
            Marked = N.Marked;
        }
        public Node()
        {
            b = new Button();
            b.Width = 20;
            b.Height = 20;
            b.Location = new Point(20, 20);
            b.Visible = true;
//            b.Text = "Djesi";
            b.Enabled = true;
            b.BackColor = Color.NavajoWhite;
            DistanceToGoal = 13245687;
            Barrier = false;
            Marked = false;
            Goal = false;
            b.MouseClick += new MouseEventHandler(ButtonClick);
            b.MouseUp += new MouseEventHandler(MouseUp);
            b.MouseEnter += new EventHandler(MouseHover);
        }

        private void MouseHover(object sender, EventArgs e)
        {
            if (dragDraw)
                toggleBarrier();
        }

        public bool getGoal()
        {
            return Goal;
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Nodes.UnMarkAll();
                if (Form1.algoritam == 1)
                    Nodes.DepthFirstSearch(this);
                else if (Form1.algoritam == 2)
                    Nodes.BreadthFirstSearch(this);
                else
                    Nodes.Azvezda(this);
            }
            else if (e.Button == MouseButtons.Middle)
                toggleGoal();
            else if (e.Button == MouseButtons.Right)
                dragDraw = !dragDraw;

        }

        private void ButtonClick(object sender, MouseEventArgs e)
        {
            /*
            if (e.Button == MouseButtons.Left)
                ToggleGoal();
            else if (e.Button == MouseButtons.Middle)
                ToggleBarrier();
            else if (e.Button == MouseButtons.Right)
                Mark();*/

        }

        public void toggleGoal()
        {
            if (Goal)
            {
                Goal = false;
                b.BackColor = Color.NavajoWhite;
                GoalCount--;
                Barrier = false;
            }
            else if (GoalCount == 0)
            {
                Goal = true;
                b.BackColor = Color.Red;
                Marked = false;
                GoalX = j;
                GoalY = i;
                GoalCount++;
            }
            else
                MessageBox.Show("Vec postoji jedan cilj");
        }

        public void calcDistanceToGoal()
        {
            int x = GoalX, y = GoalY;
            DistanceToGoal = Math.Sqrt((x - j) * (x - j) + (y - i) * (y - i));
            b.Text = DistanceToGoal.ToString();
            b.Font = new Font("Serif", 7);
        }

        public bool isMarked()
        {
            return Marked;
        }

        public void mark()
        {
            b.BackColor = Color.MediumSpringGreen;
            Marked = true;
        }
        public bool isBarrier()
        {
            return Barrier;
        }

        public void toggleBarrier()
        {
            if (Goal)
            {
                MessageBox.Show("Goal removed");
                toggleGoal();
            }
            Barrier = !Barrier;
            if (Barrier)
                b.BackColor = Color.Black;
            else
                b.BackColor = Color.NavajoWhite;
        }


        public Button getButton()
        {
            return b;
        }


        public Double getDist()
        {
            return DistanceToGoal;
        }
    }
}
