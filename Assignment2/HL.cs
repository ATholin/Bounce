using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment2
{
	class HL : Box, ICollision
	{
		public HL(PointF p1, PointF p2) : base(p1, p2)
		{
			pen = new Pen(Color.Green);
			p2.Y = p1.Y + 1;
		}

		public void OnCollision(Ball b)
		{
			b.Speed = new Vector(b.Speed.X, b.Speed.Y *= -1);
		}
	}
}
