using System.Collections.Generic;
using System.Drawing;

namespace Assignment2
{
	public class Ball : IDrawable
	{
		private Pen pen = new Pen(Color.White);
		private int radius;
        public PointF position;

		public Ball(Point position, int radius)
		{
            this.position = position;
			this.radius = radius;
		}

		public Ball(int x, int y, int radius) : this(new Point(x, y), radius)
		{
			this.radius = radius;
		}

		public void Draw(Graphics g)
		{
			g.DrawEllipse(pen,position.X - radius, position.Y - radius, 2 * radius, 2 * radius);
		}

		public void Move()
		{
			// check intersection with all shapes
			position.X = position.X + speed.X;
			position.Y = position.Y + speed.Y;
		}

		public Shape CheckIntersect(ISet<Shape> shapes)
		{
			RectangleF ballRectangle = new RectangleF(position.X - 10, position.Y - 10, 20, 20);

			foreach (var shape in shapes)
			{
				var rekt = shape.MakeREKT();
				if (ballRectangle.IntersectsWith(rekt))
				{
					return shape;
				}
			}
			return null;
		}

		private Vector speed;

		public Vector Speed
		{
			get { return speed; }
			set { speed = value; }
		}
	}
}
