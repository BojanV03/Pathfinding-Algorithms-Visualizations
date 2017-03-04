namespace Pathfinding
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAStar = new System.Windows.Forms.RadioButton();
            this.rbDFS = new System.Windows.Forms.RadioButton();
            this.rbBFS = new System.Windows.Forms.RadioButton();
            this.tick = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAStar);
            this.groupBox1.Controls.Add(this.rbDFS);
            this.groupBox1.Controls.Add(this.rbBFS);
            this.groupBox1.Location = new System.Drawing.Point(13, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(126, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Algorithm";
            // 
            // rbAStar
            // 
            this.rbAStar.AutoSize = true;
            this.rbAStar.Location = new System.Drawing.Point(7, 68);
            this.rbAStar.Name = "rbAStar";
            this.rbAStar.Size = new System.Drawing.Size(36, 17);
            this.rbAStar.TabIndex = 2;
            this.rbAStar.TabStop = true;
            this.rbAStar.Text = "A*";
            this.rbAStar.UseVisualStyleBackColor = true;
            // 
            // rbDFS
            // 
            this.rbDFS.AutoSize = true;
            this.rbDFS.Location = new System.Drawing.Point(7, 44);
            this.rbDFS.Name = "rbDFS";
            this.rbDFS.Size = new System.Drawing.Size(46, 17);
            this.rbDFS.TabIndex = 1;
            this.rbDFS.TabStop = true;
            this.rbDFS.Text = "DFS";
            this.rbDFS.UseVisualStyleBackColor = true;
            // 
            // rbBFS
            // 
            this.rbBFS.AutoSize = true;
            this.rbBFS.Location = new System.Drawing.Point(7, 20);
            this.rbBFS.Name = "rbBFS";
            this.rbBFS.Size = new System.Drawing.Size(45, 17);
            this.rbBFS.TabIndex = 0;
            this.rbBFS.TabStop = true;
            this.rbBFS.Text = "BFS";
            this.rbBFS.UseVisualStyleBackColor = true;
            this.rbBFS.CheckedChanged += new System.EventHandler(this.rbBFS_CheckedChanged);
            // 
            // tick
            // 
            this.tick.Interval = 1;
            this.tick.Tick += new System.EventHandler(this.tick_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(586, 449);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbAStar;
        private System.Windows.Forms.RadioButton rbDFS;
        private System.Windows.Forms.RadioButton rbBFS;
        private System.Windows.Forms.Timer tick;
        private System.Windows.Forms.Button button1;
    }
}
