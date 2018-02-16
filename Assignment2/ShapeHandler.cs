using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment2
{
	class ShapeHandler
	{

		Engine engine;

		Point p1 = new Point();
		Point p2 = new Point();

		public ShapeHandler(Engine engine)
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
			var shape = new Shape(Shape.Type.speed, p1, p2);
			engine.AddShape(shape);
		}

		private void SlowBox(object sender, EventArgs e)
		{
			var shape = new Shape(Shape.Type.slow, p1, p2);
			engine.AddShape(shape);
		}

		private void HorizontalLine(object sender, EventArgs e)
		{
			p2.Y = p1.Y + 1;
			var shape = new Shape(Shape.Type.horizontal, p1, p2);
			engine.AddShape(shape);
		}

		private void VerticalLine(object sender, EventArgs e)
		{
			p2.X = p1.X + 1;
			var shape = new Shape(Shape.Type.vertical, p1, p2);
			engine.AddShape(shape);
		}
	}
}
