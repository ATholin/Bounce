using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment2
{
	class Shape : IDrawable
	{
		private Pen pen = new Pen(Color.Black);
		private int width;
		private int heigth;
		Point position;

		public Shape(Point position, int width, int heigth)
		{
			this.position = position;
			this.width = width;
			this.heigth = heigth;
		}

		public Shape(int x, int y, int width, int height) : this(new Point(x, y), width, height)
		{
			this.width = width;
			this.heigth = heigth;
		}

		public void Draw(Graphics g)
		{
			g.DrawRectangle(pen, position.X, position.Y, width, heigth);
		}

		public void Move()
		{
			position.X = position.X + speed.X;
			position.Y = position.Y + speed.Y;
		}

		private Vector speed;

		public Vector Speed
		{
			get { return speed; }
			set { speed = value; }
		}

	}
}
