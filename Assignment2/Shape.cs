using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment2
{
	public class Shape : IDrawable
	{
		private Pen pen;
		private Point point1;
		private Point point2;
		public Type ShapeType;

		public Rectangle MakeREKT()
		{
			return new Rectangle(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y), Math.Max(point1.X, point2.X) - Math.Min(point1.X, point2.X), Math.Max(point1.Y, point2.Y) - Math.Min(point1.Y, point2.Y));
		}

		public enum Type
		{
			speed,
			slow,
			vertical,
			horizontal
		}

		public Shape(Type type, Point p1, Point p2)
		{
			this.ShapeType = type;
			point1 = p1;
			point2 = p2;
		}

		public void Draw(Graphics g)
		{
			switch (ShapeType)
			{
				case Type.speed:
					pen = new Pen(Color.Red);
					break;
				case Type.slow:
					pen = new Pen(Color.Blue);
					break;
				case Type.vertical:
					pen = new Pen(Color.Yellow);
					break;
				case Type.horizontal:
					pen = new Pen(Color.Green);
					break;
			}
			g.DrawRectangle(pen, Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y), Math.Max(point1.X, point2.X)- Math.Min(point1.X, point2.X), Math.Max(point1.Y, point2.Y) - Math.Min(point1.Y, point2.Y));
		}


		private Vector speed;

		public Vector Speed
		{
			get { return speed; }
			set { speed = value; }
		}

	}
}
