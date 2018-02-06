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

		private Random random = new Random();

		public Engine()
		{
			form = new MainForm();
			timer = new Timer();

			AddBall();
		}

		public void Run()
		{
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

		private void TimerEventHandler(Object obj, EventArgs args)
		{
			if (random.Next(100) < 25) AddBall();

			foreach (var ball in balls)
			{
				ball.Move();
			}

			form.Refresh();
		}

		private void Draw(Object obj, PaintEventArgs args)
		{
			foreach (var ball in balls)
			{
				ball.Draw(args.Graphics);
			}
		}

	}
}
