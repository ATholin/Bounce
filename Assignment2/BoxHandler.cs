using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment2
{
	class BoxHandler
	{

		Engine engine;

		Point p1 = new Point();
		Point p2 = new Point();

		public BoxHandler(Engine engine)
		{
			this.engine = engine;
		}

		public void Form_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				p1.X = e.X;
				p1.Y = e.Y;
			}
		}

		public void Form_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				p2.X = e.X;
				p2.Y = e.Y;
				var context = new ContextMenuStrip();
				context.Items.Add("Add SpeedBox", null, new EventHandler(SpeedBox));
				context.Items.Add("Add SlowBox", null, new EventHandler(SlowBox));
				context.Items.Add("Add Horizontal Line", null, new EventHandler(HorizontalLine));
				context.Items.Add("Add Vertical Line", null, new EventHandler(VerticalLine));
				context.Show(Cursor.Position);

				
			}
		}

		private void SpeedBox(object sender, EventArgs e)
		{
			var box = new SUB(p1, p2);
			engine.AddBox(box);
		}

		private void SlowBox(object sender, EventArgs e)
		{
			var box = new SDB(p1, p2);
			engine.AddBox(box);
		}

		private void HorizontalLine(object sender, EventArgs e)
		{
			var box = new HL(p1, p2);
			engine.AddBox(box);
		}

		private void VerticalLine(object sender, EventArgs e)
		{
			var box = new VL(p1, p2);
			engine.AddBox(box);
		}
	}
}
