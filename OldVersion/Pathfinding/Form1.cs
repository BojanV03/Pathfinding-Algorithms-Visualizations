using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pathfinding
{
    public partial class Form1 : Form
    {
        Nodes Graph;
        public static int algoritam = 1;
        public Form1()
        {
            InitializeComponent();
        }

        public int WIDTH = 76;
        public int HEIGHT = 42;
        private Button button1 = new Button();

        private void Form1_Load(object sender, EventArgs e)
        {
            btn1.Location = new Point(15, Height - 80);
            btnRand.Location = new Point(Width - 100, Height - 80);
            groupBox1.Location = new Point(Width / 2 - groupBox1.Width / 2, Height - 88);
            btnHelp.Location = new Point(btn1.Location.X + btn1.Width + 2, btn1.Location.Y);
            Graph = new Nodes(this);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Nodes.MazeGen();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            btn1.Location = new Point(15, Height - 80);
            btnRand.Location = new Point(Width - 100, Height - 80);
            groupBox1.Location = new Point(Width/2 - groupBox1.Width/2, Height - 88);
            btnHelp.Location = new Point(btn1.Location.X + btn1.Width  + 2, btn1.Location.Y);

            if(Graph != null)
            {
                for(int i=0; i<Nodes.HEIGHT; i++)
                    for(int j = 0; j<Nodes.WIDTH; j++)
                    {
                        this.Controls.Remove(Nodes.Graph[i, j].getButton());
                    }
                Graph = new Nodes(this);
            }
            NodeSpawnTimer.Enabled = true;
        }

        private void btnRand_Click(object sender, EventArgs e)
        {
            Nodes.UnMarkAll();
            Nodes.RandBarrier();
        }

        private void btnDFS_CheckedChanged(object sender, EventArgs e)
        {
            algoritam = 1;
        }

        private void btnBFS_CheckedChanged(object sender, EventArgs e)
        {
            algoritam = 2;
        }

        private void btnA_CheckedChanged(object sender, EventArgs e)
        {
            algoritam = 3;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Set desired window size(preferably full screen) and click on generate to create the buttons.\n\nControls:\nRight Mouse Button: Toggle Draw Barriers\nMiddle Mouse Button: Set goal\nLeft Mouse Button: Start Traversal\nUse the Rand() to fill the matrix with random()%4 == 0 barriers", "info");
        }

        public int timerCounter = 0;

        private void NodeSpawnTimer_Tick(object sender, EventArgs e)
        {
            if (timerCounter < (Nodes.WIDTH * Nodes.HEIGHT))
            {
                int i = timerCounter % Nodes.HEIGHT;
                int j = (timerCounter / Nodes.HEIGHT) % Nodes.WIDTH;
                Controls.Add(Nodes.Graph[i, j].getButton());
                timerCounter++;
            }
            else
            {
                NodeSpawnTimer.Enabled = false;
                timerCounter = 0;
            }

        }
    }
}
