using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Assignment2
{
	public class Engine
	{
		public MainForm form;
		private Timer timer;
		ShapeDelegate ShapeDelegate;

		private ISet<Ball> balls = new HashSet<Ball>();
		private ISet<Shape> shapes = new HashSet<Shape>();

		private Random random = new Random();

		public Engine()
		{
			form = new MainForm();
			timer = new Timer();
			ShapeDelegate = new ShapeDelegate(this);
			form.MouseDown += ShapeDelegate.Form_MouseDown;
			form.MouseUp += ShapeDelegate.Form_MouseUp;

			AddBall();
		}

		public void Run()
		{
			form.BackColor = Color.Black;
			form.Paint += new PaintEventHandler(Draw);

			timer.Tick += new EventHandler(TimerEventHandler);
			timer.Interval = 1000 / 25;
			timer.Start();

			Application.Run(form);

		}

		private void AddBall()
		{
			var ball = new Ball(400, 300, 10);
			do
			{
				ball.Speed = new Vector(random.Next(10) - 5, random.Next(10) - 5);
			} while(ball.Speed.X == 0 || ball.Speed.Y == 0);
			balls.Add(ball);
		}

		public void AddShape(Shape shape)
		{
			shapes.Add(shape);
		}

		private void TimerEventHandler(Object obj, EventArgs args)
		{
			if (random.Next(100) < 25) AddBall();

			foreach (var ball in balls)
			{
				var shape = CheckIntersect(ball);
				if (shape != null)
				{
					switch (shape.ShapeType)
					{
						case Shape.Type.speed:
							/*
							var speedX = (double)ball.Speed.X;
							var speedY = (double)ball.Speed.Y;
							Math.Round(speedX * 2);
							Math.Round(speedY * 2);

							ball.Speed.X = (int)speedX;
							ball.Speed.Y = (int)speedY;
							*/
							ball.Speed = new Vector(ball.Speed.X + ball.Speed.X / 5, ball.Speed.Y + ball.Speed.Y / 5);
							break;
						case Shape.Type.slow:
							//move and decrease speed
							break;
						case Shape.Type.vertical:
							//move and invert y speed
							break;
						case Shape.Type.horizontal:
							//move and invert x speed
							break;
					}
				}
				ball.Move();
			}
			form.Refresh();
		}

		private Shape CheckIntersect(Ball ball)
		{
			Point rect = ball.position;
			Rectangle ballRectangle = new Rectangle(rect.X, rect.Y, 20, 20);

			foreach(var shape in shapes)
			{
				var rekt = shape.MakeREKT();
				if (ballRectangle.IntersectsWith(rekt))
				{
					return shape;
				}
			}
			return null;
		}

		private void Draw(Object obj, PaintEventArgs args)
		{
			foreach (var ball in balls)
			{
				ball.Draw(args.Graphics);
			}
			foreach (var shape in shapes)
			{
				shape.Draw(args.Graphics);
			}
		}
	}
}
