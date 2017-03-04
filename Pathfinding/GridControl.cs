using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Pathfinding
{
    public class GridControl : Panel
    {
        public int columns = 100;
        public int rows = 50;
        public Node[,] graph;
        private Point currentGoal = new Point(-1, -1);
        private bool drawing = false;
        private Main form1;
        public Point initialNode;



        public GridControl(Main _form1)
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;

            form1 = _form1;
            graph = new Node[columns, rows];

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    graph[x, y] = new Node();
                }
            }
        }

        public void ResizeGrid(EventArgs e, int WindowHeight, int WindowWidth)
        {
            int top = 0;

            this.Location = new Point(150, 25);

            this.Height = WindowHeight-75-Location.Y;
            this.Width = WindowWidth-25-Location.X;

            int cellWidth = this.Width / columns;
            int cellHeight = this.Height / rows;

            for (int y = 0; y < rows; y++)
            {
                int left = 0;
                for (int x = 0; x < columns; x++)
                {
                    graph[x, y].Bounds = new Rectangle(left, top, cellWidth, cellHeight);
                    left += cellWidth;
                }
                top += cellHeight;
            }

            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillRectangle(Brushes.Gray, 0, 0, Width, Height);
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    if (graph[x, y].IsGoal)
                        e.Graphics.FillRectangle(Brushes.DarkRed, graph[x, y].Bounds);
                    else if (graph[x, y].IsSet)
                        e.Graphics.FillRectangle(Brushes.DarkGray, graph[x, y].Bounds);
                    else if(graph[x, y].IsVisited)
                        e.Graphics.FillRectangle(Brushes.DarkGreen, graph[x, y].Bounds);
                    else
                        e.Graphics.FillRectangle(Brushes.LightBlue, graph[x, y].Bounds);
                }
            }
            base.OnPaint(e);
        }

        Point previousMouseLocation = new Point(0, 0);

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!drawing)
                return;

            int prevX = (previousMouseLocation.X / graph[0, 0].Bounds.Width);
            int prevY = (previousMouseLocation.Y / graph[0, 0].Bounds.Height);

            int x = (int)(e.X / graph[0, 0].Bounds.Width);
            int y = (int)(e.Y / graph[0, 0].Bounds.Height);


            if (prevX != x || prevY != y)
            {
                ClickButton(x, y, e.Button);
            }
            previousMouseLocation = new Point(e.X, e.Y);

            base.OnMouseMove(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            int x = (int)(e.X / graph[0, 0].Bounds.Width);
            int y = (int)(e.Y / graph[0, 0].Bounds.Height);

            ClickButton(x, y, e.Button);

            base.OnMouseDown(e);
        }

        private bool ClickButton(int x, int y, MouseButtons mb)
        {
            if (x >= columns || x < 0 || y >= rows || y < 0)
                return false;

            if (mb.Equals(MouseButtons.Middle))
            {
                if (graph[x, y].IsGoal)
                {
                    graph[x, y].IsGoal = false;
                    currentGoal = new Point(-1, -1);
                }
                else
                {
                    if(currentGoal.X != -1 && currentGoal.Y != -1)
                        graph[currentGoal.X, currentGoal.Y].IsGoal = false;

                    graph[x, y].IsGoal = true;
                    currentGoal = new Point(x, y);
                }

            }
            else if (mb.Equals(MouseButtons.Right))
            {
                drawing = !drawing;
            }
            else if (mb.Equals(MouseButtons.None))
            {
                graph[x, y].IsSet = !graph[x, y].IsSet;
            }
            else if (mb.Equals(MouseButtons.Left))
                StartSearch(x, y);

            this.Invalidate();
            return true;
        }

        private bool StartSearch(int x, int y)
        {
            foreach(Node n in graph)
            {
                n.IsVisited = false;
                n.IsClosed = false;
            }
            if (graph[x, y].IsSet || graph[x, y].IsGoal)
            {
                MessageBox.Show("Invalid start position");
                return false;
            }
            else if (currentGoal.X == -1 || currentGoal.Y == -1)
            {
                MessageBox.Show("You forgot to set a goal");
                return false;
            }

            initialNode = new Point(x, y);
            return true;
        }        
    }
}
