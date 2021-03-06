﻿namespace Pathfinding
{
    partial class Form1
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
            this.btn1 = new System.Windows.Forms.Button();
            this.DFS = new System.Windows.Forms.Timer(this.components);
            this.btnRand = new System.Windows.Forms.Button();
            this.btnDFS = new System.Windows.Forms.RadioButton();
            this.btnBFS = new System.Windows.Forms.RadioButton();
            this.btnA = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.NodeSpawnTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.Enabled = false;
            this.btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btn1.Location = new System.Drawing.Point(51, 206);
            this.btn1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(74, 31);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "Maze Fill";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btnRand
            // 
            this.btnRand.Location = new System.Drawing.Point(51, 171);
            this.btnRand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRand.Name = "btnRand";
            this.btnRand.Size = new System.Drawing.Size(74, 31);
            this.btnRand.TabIndex = 1;
            this.btnRand.Text = "Rand()";
            this.btnRand.UseVisualStyleBackColor = true;
            this.btnRand.Click += new System.EventHandler(this.btnRand_Click);
            // 
            // btnDFS
            // 
            this.btnDFS.AutoSize = true;
            this.btnDFS.Checked = true;
            this.btnDFS.Location = new System.Drawing.Point(4, 17);
            this.btnDFS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDFS.Name = "btnDFS";
            this.btnDFS.Size = new System.Drawing.Size(46, 17);
            this.btnDFS.TabIndex = 2;
            this.btnDFS.TabStop = true;
            this.btnDFS.Text = "DFS";
            this.btnDFS.UseVisualStyleBackColor = true;
            this.btnDFS.CheckedChanged += new System.EventHandler(this.btnDFS_CheckedChanged);
            // 
            // btnBFS
            // 
            this.btnBFS.AutoSize = true;
            this.btnBFS.Location = new System.Drawing.Point(114, 17);
            this.btnBFS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBFS.Name = "btnBFS";
            this.btnBFS.Size = new System.Drawing.Size(85, 17);
            this.btnBFS.TabIndex = 3;
            this.btnBFS.Text = "BFS/Dijkstra";
            this.btnBFS.UseVisualStyleBackColor = true;
            this.btnBFS.CheckedChanged += new System.EventHandler(this.btnBFS_CheckedChanged);
            // 
            // btnA
            // 
            this.btnA.AutoSize = true;
            this.btnA.Location = new System.Drawing.Point(238, 17);
            this.btnA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(36, 17);
            this.btnA.TabIndex = 4;
            this.btnA.Text = "A*";
            this.btnA.UseVisualStyleBackColor = true;
            this.btnA.CheckedChanged += new System.EventHandler(this.btnA_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDFS);
            this.groupBox1.Controls.Add(this.btnA);
            this.groupBox1.Controls.Add(this.btnBFS);
            this.groupBox1.Location = new System.Drawing.Point(74, 48);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(275, 42);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Algoritam";
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(129, 171);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(56, 31);
            this.btnHelp.TabIndex = 6;
            this.btnHelp.Text = "halp!";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // NodeSpawnTimer
            // 
            this.NodeSpawnTimer.Interval = 1;
            this.NodeSpawnTimer.Tick += new System.EventHandler(this.NodeSpawnTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 449);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRand);
            this.Controls.Add(this.btn1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Timer DFS;
        private System.Windows.Forms.Button btnRand;
        private System.Windows.Forms.RadioButton btnDFS;
        private System.Windows.Forms.RadioButton btnBFS;
        private System.Windows.Forms.RadioButton btnA;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Timer NodeSpawnTimer;
    }
}
