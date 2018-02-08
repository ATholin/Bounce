using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment2
{
	class ShapeDelegate : Form
	{
		private MainForm form;

		public ShapeDelegate(MainForm form)
		{
			this.form = form;
		}

		public void MClick(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				var context = new ContextMenuStrip();
				context.Items.Add("Add SpeedBox", null, new EventHandler(SpeedBox));
				context.Items.Add("Add SlowBox", null, new EventHandler(SlowBox));
				context.Items.Add("Add Horizontal Line", null, new EventHandler(HorizontalLine));
				context.Items.Add("Add Vertical Line", null, new EventHandler(VerticalLine));
				context.Show(Cursor.Position);
			}
		}

		public void CreateShape()
		{
			var label = new Label();
			label.AutoSize = true;
			label.Text = "Choose two points.";

			form.Controls.Add(label);
		}

		private void SpeedBox(object sender, EventArgs e)
		{
			CreateShape();
			this.UseWaitCursor = true;
		}

		private void SlowBox(object sender, EventArgs e)
		{
			CreateShape();
		}

		private void HorizontalLine(object sender, EventArgs e)
		{
			CreateShape();
		}

		private void VerticalLine(object sender, EventArgs e)
		{
			CreateShape();
		}
	}
}
