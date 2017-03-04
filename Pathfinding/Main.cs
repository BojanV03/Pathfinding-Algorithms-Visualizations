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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }

        GridControl g1;

        public void startTimer()
        {
            tick.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g1 = new GridControl(this);
            Controls.Add(g1);
            g1.Visible = true;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            g1.ResizeGrid(e, this.Height, this.Width);
        }

        private void rbBFS_CheckedChanged(object sender, EventArgs e)
        {

        }

        public Point CurrentDFSNode;
        public Stack<Point> P = new Stack<Point>();
        static int currP = 0;
        int frameNumber = 0;

        private void tick_Tick(object sender, EventArgs e)
        {
            if(rbDFS.Checked)
            {                
                P.Push(Algorithm.DFSNextStep(CurrentDFSNode.X, CurrentDFSNode.Y, g1.graph));
                CurrentDFSNode = P.Peek();

                if (CurrentDFSNode.X == -1 || CurrentDFSNode.Y == -1)
                {
                    tick.Enabled = false;
                    MessageBox.Show("Cilj!!" + frameNumber.ToString());
                }
                else if(CurrentDFSNode.X == -2 || CurrentDFSNode.Y == -2)
                {
                    while(P.Peek().X == -2)
                        P.Pop();
                    P.Pop();
                    if (P.Count == 0)
                    {
                        tick.Enabled = false;
                        MessageBox.Show("Fail");
                        return;
                    }
                    CurrentDFSNode = P.Peek();
                }
                g1.Invalidate();
            }
            frameNumber++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CurrentDFSNode = g1.initialNode;
            P.Push(CurrentDFSNode);
            tick.Enabled = true;
        }
    }
}
