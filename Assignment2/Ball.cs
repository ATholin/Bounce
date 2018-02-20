using System.Collections.Generic;
using System.Drawing;
using System;

namespace Assignment2
{
	public class Ball : IDrawable
	{
		private Pen pen = new Pen(Color.White);
		public int Radius { get; private set; }
        public PointF Position { get; set; }

		public Ball(Point position, int radius)
		{
            this.Position = position;
			this.Radius = radius;
		}

		public Ball(int x, int y, int radius) : this(new Point(x, y), radius)
		{
			this.Radius = radius;
		}

		public void Draw(Graphics g)
		{
			g.DrawEllipse(pen,Position.X - Radius, Position.Y - Radius, 2 * Radius, 2 * Radius);
		}

		public void Move()
		{
			// check intersection with all shapes
			Position = new PointF(Position.X + speed.X, Position.Y + speed.Y);
		}

		private Vector speed;

		public Vector Speed
		{
			get { return speed; }
			set { speed = value; }
		}
	}
}