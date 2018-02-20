using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment2
{
	class VL : Box, ICollision
	{
		public VL(PointF p1, PointF p2) : base(p1, p2)
		{
			pen = new Pen(Color.Yellow);
			p2.X = p1.X + 1;
		}

		public void OnCollision(Ball b)
		{
			b.Speed = new Vector(b.Speed.X *= -1, b.Speed.Y);
		}
	}
}
