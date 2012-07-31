using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Engine
{
    public class MainForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        public MainEngine engine = null;


        public MainForm()
        {
            InitializeComponent();
            engine = new MainEngine(this);
            engine.InitializeGraphics();
            engine.InitializeInput();
        }

        protected override void Dispose(bool disposing)
        {
            engine.DeInitializeGraphics();
            engine.DeInitializeInput();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "Engine";
            this.ResumeLayout(false);
        }
    }
}
