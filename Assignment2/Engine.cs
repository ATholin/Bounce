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
		ShapeHandler ShapeDelegate;

		private ISet<Ball> balls = new HashSet<Ball>();
		private ISet<Ball> BallsToRemove = new HashSet<Ball>();

		private ISet<Shape> shapes = new HashSet<Shape>();

		private Random random = new Random();

		Label ballsLabel = new Label();

		public Engine()
		{
			form = new MainForm();
			timer = new Timer();
			ShapeDelegate = new ShapeHandler(this);
			form.MouseDown += ShapeDelegate.Form_MouseDown;
			form.MouseUp += ShapeDelegate.Form_MouseUp;
			form.Controls.Add(ballsLabel);

			ballsLabel.ForeColor = Color.White;
			ballsLabel.Location = new Point(5, 5);
			ballsLabel.AutoSize = true;

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
			Shape shape = null;

			if (random.Next(100) < 100) AddBall();

			foreach (var ball in balls)
			{
				foreach(var s in shapes)
				{
					shape = ball.CheckIntersect(s);
					if (shape != null)
					{
						switch (shape.ShapeType)
						{
							case Shape.Type.speed:
								ball.Speed.X *= (float)1.03;
								ball.Speed.Y *= (float)1.03;
								break;
							case Shape.Type.slow:
								ball.Speed.X *= (float)0.98;
								ball.Speed.Y *= (float)0.98;
								break;
							case Shape.Type.vertical:
								ball.Speed.X *= -1;

								break;
							case Shape.Type.horizontal:
								ball.Speed.Y *= -1;
								break;
						}
					}
				}

				ball.Move();

				var x = ball.position.X;
				var y = ball.position.Y;

				if (x > form.Width || x < -20 || y > form.Height || y < -20)
				{
					BallsToRemove.Add(ball);
				}
			}

			RemoveBalls();
			BallsToRemove.Clear();

			form.Refresh();

			ballsLabel.Text = "Balls: " + balls.Count;
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

		private void RemoveBalls()
		{
			foreach(var ball in BallsToRemove)
			{
				balls.Remove(ball);
			}
		}
	}
}
