using System;
using System.Drawing;

namespace Assignment2
{
	public class Ball : IDrawable
	{
		private Pen pen = new Pen(Color.Black);
		private int radius;
        Point position;

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
			position.X = position.X + speed.X;
			position.Y = position.Y + speed.Y;
		}

		private Vector speed;

		public Vector Speed
		{
			get { return speed; }
			set { speed = value; }
		}

	}
}
