using System;
namespace Assignment2
{
	public class Vector
	{
		private float x;
		private float y;

		public Vector(float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		public float X
		{
			get { return x; }
			set { x = value; }
		}

		public float Y
		{
			get { return y; }
			set { y = value; }
		}
	}
}
