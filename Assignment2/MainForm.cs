using System;
using System.Windows.Forms;


namespace Assignment2
{
	public class MainForm : Form
	{
		
		public MainForm() : base()
		{
			this.DoubleBuffered = true;
			Text = "Assignment 2";
			Width = 800;
			Height = 600;
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// MainForm
			// 
			this.ClientSize = new System.Drawing.Size(784, 467);
			this.Name = "MainForm";
			this.ResumeLayout(false);

		}
	}
}
