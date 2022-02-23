using GLFW;
using System.Drawing;
using System.Numerics;
using static OpenGL.GL;

namespace Cupcake.Rendering.Display
{
	static class DisplayManager
	{
		public static Window Window { get; set; }
		public static Vector2 WindowSize { get; set; }

		public static void CreateWindow(int width, int height, string title)
		{
			WindowSize = new Vector2(width, height);

			Glfw.Init();

			Glfw.WindowHint(Hint.ContextVersionMajor, 3);
			Glfw.WindowHint(Hint.ContextVersionMinor, 3);
			Glfw.WindowHint(Hint.OpenglProfile, Profile.Core);

			Glfw.WindowHint(Hint.Focused, true);
			Glfw.WindowHint(Hint.Resizable, true);

			Window = Glfw.CreateWindow(width, height, title, GLFW.Monitor.None, Window.None);

			if (Window == Window.None)
			{
				return;
			}

			Rectangle screen = Glfw.PrimaryMonitor.WorkArea;
			int x = (screen.Width - width) / 2;
			int y = (screen.Height - height) / 2;

			Glfw.SetWindowPosition(Window, x, y);

			Glfw.MakeContextCurrent(Window);
			Import(Glfw.GetProcAddress);

			glViewport(0, 0, width, height);
			Glfw.SwapInterval(0); // 0 - VSync off | 1 - VSync on
		}

		public static void CloseWindow()
		{
			Glfw.Terminate();
		}
	}
}