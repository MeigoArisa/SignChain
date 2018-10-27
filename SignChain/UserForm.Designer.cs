using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SignChain
{
    partial class UserForm : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private TextBox textBox1;
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UserForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1440, 1024);
            this.Name = "UserForm";
            this.Text = "AreaForm";
            this.Load += new System.EventHandler(this.UserFormLoad);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserFormPaint);
            this.ResumeLayout(false);
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.Multiline = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Width = 132;
            this.textBox1.Height = 30;
            this.textBox1.Top = 252;
            this.textBox1.Left = 475;
        }

        #endregion
    }
}