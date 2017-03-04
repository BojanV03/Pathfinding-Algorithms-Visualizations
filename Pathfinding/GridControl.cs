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
        private int columns = 100;
        private int rows = 50;
        private Node[,] graph;

        public GridControl()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;

            // initialize mine field:
            graph = new Node[columns, rows];
            for (int y = 0; y < rows; ++y)
            {
                for (int x = 0; x < columns; ++x)
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
            e.Graphics.FillRectangle(Brushes.Black, 0, 0, Width, Height);
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    if (graph[x, y].IsRevealed)
                    {
                        e.Graphics.FillRectangle(Brushes.DarkGray, graph[x, y].Bounds);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.LightBlue, graph[x, y].Bounds);
                    }
                }
            }
            base.OnPaint(e);
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
            graph[x, y].IsRevealed = true;
            this.Invalidate();
            MessageBox.Show(
              string.Format("You pressed on button ({0}, {1})",
              x.ToString(), y.ToString()));
            return true;
        }
    }
}
