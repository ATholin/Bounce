using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Assignment2
{
	public class Engine
	{
		private MainForm form;
		private Timer timer;

		private ISet<Ball> balls = new HashSet<Ball>();
		private ISet<Ball> BallsToRemove = new HashSet<Ball>();

		private ISet<Box> collidables = new HashSet<Box>();

		private Random random = new Random();

		Label ballsLabel = new Label();

		public Engine()
		{
			form = new MainForm();
			timer = new Timer();

			var boxHandler = new BoxHandler(this);
			form.MouseDown += boxHandler.Form_MouseDown;
			form.MouseUp += boxHandler.Form_MouseUp;
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
			timer.Interval = 1000/25;
			timer.Start();

			Application.Run(form);

		}

		private void AddBall()
		{
			var ball = new Ball(400, 300, 10);
			ball.Speed = new Vector(random.Next(10) - 5, random.Next(10) - 5);
			balls.Add(ball);
		}

		public void AddBox(Box c)
		{
			collidables.Add(c);
		}

		private void TimerEventHandler(Object obj, EventArgs args)
		{
			if (random.Next(100) < 25) AddBall();

			foreach (var ball in balls)
			{
				foreach(var c in collidables)
				{
					if (c.Intersects(ball))
					{
						c.OnCollision(ball);
					}
				}

				ball.Move();

				if (ball.Position.X > form.Width || ball.Position.X < -20 || ball.Position.Y > form.Height || ball.Position.Y < -20)
				{
					BallsToRemove.Add(ball);
				}
			}

			RemoveBalls();
			BallsToRemove.Clear();

			form.Refresh();
		}

		private void Draw(Object obj, PaintEventArgs args)
		{
			foreach (var ball in balls)
			{
				ball.Draw(args.Graphics);
			}

			foreach(var c in collidables)
			{
				c.Draw(args.Graphics);
			}
		}

		private void RemoveBalls()
		{
			foreach (var ball in BallsToRemove)
			{
				balls.Remove(ball);
			}
		}
	}
}
