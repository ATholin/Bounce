using System.Collections.Generic;
using System.Drawing;
using System;

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

		public Shape CheckIntersect(Shape shape)
		{
			var point1X = Math.Min(shape.GetPointOne().X, shape.GetPointTwo().X);
			var point1Y = Math.Min(shape.GetPointOne().Y, shape.GetPointTwo().Y);

			var point2X = Math.Max(shape.GetPointOne().X, shape.GetPointTwo().X);
			var point2Y = Math.Max(shape.GetPointOne().Y, shape.GetPointTwo().Y);

			var width = point2X - point1X;
			var height = point2Y - point1Y;

			var circleDistanceX = Math.Abs(position.X - point1X - width / 2);
			var circleDistanceY = Math.Abs(position.Y - point1Y - height / 2);

			if (circleDistanceX > (width / 2 + radius)) { return null; }
			if (circleDistanceY > (height / 2 + radius)) { return null; }

			if (circleDistanceX <= (width / 2)) { return shape; }
			if (circleDistanceY <= (height / 2)) { return shape; }
			var cornerDistance_sq = Math.Pow((circleDistanceX - width / 2), 2) +
								 Math.Pow((circleDistanceY - height / 2), 2);

			if (cornerDistance_sq <= (Math.Pow((radius), 2)))
			{
				return shape;
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