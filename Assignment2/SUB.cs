using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment2
{
	class SUB : Box, ICollision
	{
		public SUB(PointF p1, PointF p2) : base(p1, p2)
		{
			pen = new Pen(Color.Red);
		}

		public override void OnCollision(Ball b)
		{
			b.Speed.X *= (float)1.03;
			b.Speed.Y *= (float)1.03;
		}
	}
}
