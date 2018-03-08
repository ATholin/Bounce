using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment2
{
	class SDB : Box, ICollision
	{
		public SDB(PointF p1, PointF p2) : base(p1, p2)
		{
			pen = new Pen(Color.Blue);
		}

		public override void OnCollision(Ball b)
		{
			b.Speed.X *= (float)0.98;
			b.Speed.Y *= (float)0.98;
		}
	}
}
