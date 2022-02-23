using Cupcake.Rendering.Display;
using GLFW;

namespace Cupcake.GameLoop
{
	abstract class Game
	{
		protected int InitialWindowWidth { get; set; }
		protected int InitialWindowHeight { get; set; }
		protected string InitialWindowTitle { get; set; }

		public Game(int initialWindowWidth, int initialWindowHeight, string initialWindowTitle)
		{
			this.InitialWindowWidth = initialWindowWidth;
			this.InitialWindowHeight = initialWindowHeight;
			this.InitialWindowTitle = initialWindowTitle;
		}

		public void Run()
		{
			Initialize();

			DisplayManager.CreateWindow(InitialWindowWidth, InitialWindowHeight, InitialWindowTitle);

			LoadContent();

			while (!Glfw.WindowShouldClose(DisplayManager.Window))
			{
				GameTime.DeltaTime = (float)Glfw.Time - GameTime.TotalElapsedSeconds;
				GameTime.TotalElapsedSeconds = (float)Glfw.Time;

				Update();

				Glfw.PollEvents();

				Render();
			}

			DisplayManager.CloseWindow();
		}

		protected abstract void Initialize();
		protected abstract void LoadContent();

		protected abstract void Update();
		protected abstract void Render();
	}
}