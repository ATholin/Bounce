using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
	public interface ICollision
	{
		bool Intersects(Ball ball);
		void OnCollision(Ball ball);
	}
}
