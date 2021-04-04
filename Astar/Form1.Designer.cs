
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
            this.chooseGraph = new System.Windows.Forms.Button();
            this.fromdropdown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.todropdown = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // graphVis
            // 
            this.graphVis.Location = new System.Drawing.Point(2, 2);
            this.graphVis.Name = "graphVis";
            this.graphVis.Size = new System.Drawing.Size(784, 489);
            this.graphVis.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.filename);
            this.panel2.Controls.Add(this.chooseGraph);
            this.panel2.Location = new System.Drawing.Point(192, 546);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(175, 74);
            this.panel2.TabIndex = 1;
            // 
            // filename
            // 
            this.filename.Dock = System.Windows.Forms.DockStyle.Top;
            this.filename.Location = new System.Drawing.Point(0, 0);
            this.filename.Name = "filename";
            this.filename.Size = new System.Drawing.Size(175, 31);
            this.filename.TabIndex = 1;
            // 
            // chooseGraph
            // 
            this.chooseGraph.Location = new System.Drawing.Point(0, 37);
            this.chooseGraph.Name = "chooseGraph";
            this.chooseGraph.Size = new System.Drawing.Size(175, 37);
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
            this.fromdropdown.Location = new System.Drawing.Point(7, 23);
            this.fromdropdown.Name = "fromdropdown";
            this.fromdropdown.Size = new System.Drawing.Size(151, 28);
            this.fromdropdown.TabIndex = 2;
            this.fromdropdown.SelectedIndexChanged += new System.EventHandler(this.fromdropdown_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "To";
            // 
            // todropdown
            // 
            this.todropdown.FormattingEnabled = true;
            this.todropdown.Location = new System.Drawing.Point(7, 89);
            this.todropdown.Name = "todropdown";
            this.todropdown.Size = new System.Drawing.Size(151, 28);
            this.todropdown.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.todropdown);
            this.panel1.Controls.Add(this.fromdropdown);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(388, 516);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 125);
            this.panel1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 675);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.graphVis);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
    }
}

