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
		
		public Type ShapeType;

		public RectangleF MakeREKT()
		{
			return new RectangleF(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y), Math.Max(point1.X, point2.X) - Math.Min(point1.X, point2.X), Math.Max(point1.Y, point2.Y) - Math.Min(point1.Y, point2.Y));
		}

		public enum Type
		{
			speed,
			slow,
			vertical,
			horizontal
		}

		

		public PointF GetPointOne()
		{
			return point1;
		}

		public PointF GetPointTwo()
		{
			return point2;
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
		}
	}
}
