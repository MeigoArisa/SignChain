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
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;

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
        /// 
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 784);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(800, 100);
            this.button1.TabIndex = 0;
            this.button1.Click += Button1_Click;
            this.button1.Text = "+";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(337, 130);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(800, 654);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DrawItem += ListView1_DrawItem;
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.None;
            this.textBox1.Multiline = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox1.Font = new Font("10X10", 18, FontStyle.Regular);
            this.textBox1.Size = new Size(200,30);
            this.textBox1.Location = new Point(475,252);
            this.textBox1.BackColor = SystemColors.Control;
            this.textBox1.BorderStyle = BorderStyle.None;

            // 
            // textBox2
            // 
            this.textBox2.AcceptsReturn = true;
            this.textBox2.AcceptsTab = true;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.None;
            this.textBox2.Multiline = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox2.Font = new Font("10X10", 18, FontStyle.Regular);
            this.textBox2.Size = new Size(200, 30);
            this.textBox2.Location = new Point(475, 325);
            this.textBox2.BackColor = SystemColors.Control;
            this.textBox2.BorderStyle = BorderStyle.None;
            // 
            // textBox3
            // 
            this.textBox3.AcceptsReturn = true;
            this.textBox3.AcceptsTab = true;
            this.textBox3.Dock = System.Windows.Forms.DockStyle.None;
            this.textBox3.Multiline = true;
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox3.Font = new Font("10X10", 18, FontStyle.Regular);
            this.textBox3.Size = new Size(200, 30);
            this.textBox3.Location = new Point(475, 398);
            this.textBox3.BackColor = SystemColors.Control;
            this.textBox3.BorderStyle = BorderStyle.None;
            // 
            // textBox4
            // 
            this.textBox4.AcceptsReturn = true;
            this.textBox4.AcceptsTab = true;
            this.textBox4.Dock = System.Windows.Forms.DockStyle.None;
            this.textBox4.Multiline = true;
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox4.Font = new Font("10X10", 18, FontStyle.Regular);
            this.textBox4.Size = new Size(200, 30);
            this.textBox4.Location = new Point(475, 540);
            this.textBox4.BackColor = SystemColors.Control;
            this.textBox4.BorderStyle = BorderStyle.None;
            // 
            // textBox5
            // 
            this.textBox5.AcceptsReturn = true;
            this.textBox5.AcceptsTab = true;
            this.textBox5.Dock = System.Windows.Forms.DockStyle.None;
            this.textBox5.Multiline = true;
            this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox5.Font = new Font("10X10", 18, FontStyle.Regular);
            this.textBox5.Size = new Size(200, 30);
            this.textBox5.Location = new Point(475, 613);
            this.textBox5.BackColor = SystemColors.Control;
            this.textBox5.BorderStyle = BorderStyle.None;
            // 
            // textBox6
            // 
            this.textBox6.AcceptsReturn = true;
            this.textBox6.AcceptsTab = true;
            this.textBox6.Dock = System.Windows.Forms.DockStyle.None;
            this.textBox6.Multiline = true;
            this.textBox6.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox6.Font = new Font("10X10", 18, FontStyle.Regular);
            this.textBox6.Size = new Size(200, 30);
            this.textBox6.Location = new Point(475, 686);
            this.textBox6.BackColor = SystemColors.Control;
            this.textBox6.BorderStyle = BorderStyle.None;


            // 
            // UserForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1440, 1024);
            this.Name = "UserForm";
            this.Text = "AreaForm";
            this.Load += new System.EventHandler(this.UserFormLoad);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserFormPaint);
            this.ResumeLayout(false);

        }


        #endregion

        private Button button1;
        private ListView listView1;
    }
}