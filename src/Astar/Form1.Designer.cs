
namespace Astar
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.graphVis = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.filename = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.chooseGraph = new System.Windows.Forms.Button();
            this.fromdropdown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.todropdown = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.jaraktempuh = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.filename.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // graphVis
            // 
            this.graphVis.Location = new System.Drawing.Point(2, 2);
            this.graphVis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.graphVis.Name = "graphVis";
            this.graphVis.Size = new System.Drawing.Size(686, 367);
            this.graphVis.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.filename);
            this.panel2.Controls.Add(this.chooseGraph);
            this.panel2.Location = new System.Drawing.Point(41, 386);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(153, 56);
            this.panel2.TabIndex = 1;
            // 
            // filename
            // 
            this.filename.Controls.Add(this.label3);
            this.filename.Dock = System.Windows.Forms.DockStyle.Top;
            this.filename.Location = new System.Drawing.Point(0, 0);
            this.filename.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filename.Name = "filename";
            this.filename.Size = new System.Drawing.Size(153, 23);
            this.filename.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 15);
            this.label3.TabIndex = 0;
            // 
            // chooseGraph
            // 
            this.chooseGraph.Location = new System.Drawing.Point(0, 28);
            this.chooseGraph.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chooseGraph.Name = "chooseGraph";
            this.chooseGraph.Size = new System.Drawing.Size(153, 28);
            this.chooseGraph.TabIndex = 0;
            this.chooseGraph.Text = "Choose Graph";
            this.chooseGraph.UseVisualStyleBackColor = true;
            this.chooseGraph.Click += new System.EventHandler(this.chooseGraph_Click);
            // 
            // fromdropdown
            // 
            this.fromdropdown.AllowDrop = true;
            this.fromdropdown.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fromdropdown.FormattingEnabled = true;
            this.fromdropdown.Location = new System.Drawing.Point(6, 17);
            this.fromdropdown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fromdropdown.Name = "fromdropdown";
            this.fromdropdown.Size = new System.Drawing.Size(133, 23);
            this.fromdropdown.TabIndex = 2;
            this.fromdropdown.SelectedIndexChanged += new System.EventHandler(this.fromdropdown_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(9, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "To";
            // 
            // todropdown
            // 
            this.todropdown.FormattingEnabled = true;
            this.todropdown.Location = new System.Drawing.Point(6, 67);
            this.todropdown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.todropdown.Name = "todropdown";
            this.todropdown.Size = new System.Drawing.Size(133, 23);
            this.todropdown.TabIndex = 5;
            this.todropdown.SelectedIndexChanged += new System.EventHandler(this.todropdown_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.todropdown);
            this.panel1.Controls.Add(this.fromdropdown);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(211, 386);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(151, 94);
            this.panel1.TabIndex = 6;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBox1.Location = new System.Drawing.Point(0, 22);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(268, 71);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(0, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(85, 15);
            this.lbl.TabIndex = 8;
            this.lbl.Text = "Jarak Tempuh: ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.jaraktempuh);
            this.panel3.Controls.Add(this.lbl);
            this.panel3.Location = new System.Drawing.Point(389, 373);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(268, 16);
            this.panel3.TabIndex = 9;
            // 
            // jaraktempuh
            // 
            this.jaraktempuh.AutoSize = true;
            this.jaraktempuh.Location = new System.Drawing.Point(98, 0);
            this.jaraktempuh.Name = "jaraktempuh";
            this.jaraktempuh.Size = new System.Drawing.Size(0, 15);
            this.jaraktempuh.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.richTextBox1);
            this.panel4.Location = new System.Drawing.Point(389, 404);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(268, 94);
            this.panel4.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Jalur: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 506);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.graphVis);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "ShortestPath";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.filename.ResumeLayout(false);
            this.filename.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel graphVis;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel filename;
        private System.Windows.Forms.Button chooseGraph;
        private System.Windows.Forms.ComboBox fromdropdown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox todropdown;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label jaraktempuh;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
    }
}

