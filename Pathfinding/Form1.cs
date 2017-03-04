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
        public Form1()
        {
            InitializeComponent();

        }

        GridControl g1 = new GridControl();

        private void Form1_Load(object sender, EventArgs e)
        {
            Controls.Add(g1);
            g1.Visible = true;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            g1.ResizeGrid(e, this.Height, this.Width);
        }
    }
}
