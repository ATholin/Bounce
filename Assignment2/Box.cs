using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment2
{
	abstract class Box: IDrawable
	{
		public Pen pen;
		private PointF point1;
		private PointF point2;

		public Box(PointF p1, PointF p2)
		{
			pen = new Pen(Color.White);
			point1 = p1;
			point2 = p2;
		}

		public void Draw(Graphics g)
		{
			g.DrawRectangle(pen, Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y), Math.Max(point1.X, point2.X) - Math.Min(point1.X, point2.X), Math.Max(point1.Y, point2.Y) - Math.Min(point1.Y, point2.Y));
		}

		public bool Intersects(Ball b)
		{
			PointF p1 = new PointF(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y));
			PointF p2 = new PointF(Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y));

			var width = p2.X - p1.X;
			var height = p2.Y - p1.Y;

			var circleDistanceX = Math.Abs(b.Position.X - p1.X - width / 2);
			var circleDistanceY = Math.Abs(b.Position.Y - p1.Y - height / 2);

			if (circleDistanceX > (width / 2 + b.Radius)) { return false; }
			if (circleDistanceY > (height / 2 + b.Radius)) { return false; }

			if (circleDistanceX <= (width / 2)) { return true; }
			if (circleDistanceY <= (height / 2)) { return true; }
			var cornerDistance_sq = Math.Pow((circleDistanceX - width / 2), 2) +
								 Math.Pow((circleDistanceY - height / 2), 2);

			return (cornerDistance_sq <= (Math.Pow((b.Radius), 2)));
		}

	}
}
