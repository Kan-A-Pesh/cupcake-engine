using System.Numerics;
using Cupcake.Game.World;
using Cupcake.GameLoop;
using Cupcake.Rendering;
using Cupcake.Rendering.Cameras;
using Cupcake.Rendering.Display;
using Cupcake.Rendering.Lights;
using Cupcake.Rendering.Shaders;
using GLFW;
using static OpenGL.GL;

namespace Cupcake
{
	class TestGame : Cupcake.GameLoop.Game
	{
		string title;

		uint vao;
		uint vbo;

		Shader shader;
		Camera3D camera;

		List<IRenderable> renderables;

#pragma warning disable CS8618
		public TestGame(int initialWindowWidth, int initialWindowHeight, string initialWindowTitle) :
			base(initialWindowWidth, initialWindowHeight, initialWindowTitle)
		{
			this.title = initialWindowTitle;
		}
#pragma warning restore CS8618

		protected override void Initialize()
		{

		}

		protected unsafe override void LoadContent()
		{
			// Load shaders
			shader = Shader.LoadFromFiles(
				"@/assets/Shaders/mainVertex.vert",
				"@/assets/Shaders/mainFragment.frag"
			);
			shader.Load();

			renderables = new List<IRenderable>();

			// Create game World
			renderables.Add(new GameWorld());
			renderables.Add(new DirectionalLight(new Vector3(0.1881441f, -0.94072f, 0.282216f)));

			// Create VAO and VBO
			vao = glGenVertexArray();
			vbo = glGenBuffer();

			glBindVertexArray(vao);
			glBindBuffer(GL_ARRAY_BUFFER, vbo);

			float[] vertices = { 0 };

			// Get the address of the first vertices
			fixed (float* v = &vertices[0])
			{
				glBufferData(GL_ARRAY_BUFFER, sizeof(float) * vertices.Length, v, GL_STATIC_DRAW);
			}

			glVertexAttribPointer(0, 3, GL_FLOAT, false, 9 * sizeof(float), (void*)0);
			glEnableVertexAttribArray(0);

			glVertexAttribPointer(1, 3, GL_FLOAT, false, 9 * sizeof(float), (void*)(3 * sizeof(float)));
			glEnableVertexAttribArray(1);

			glVertexAttribPointer(2, 3, GL_FLOAT, false, 9 * sizeof(float), (void*)(6 * sizeof(float)));
			glEnableVertexAttribArray(2);

			glBindBuffer(GL_ARRAY_BUFFER, 0);
			glBindVertexArray(0);

			camera = new Camera3D(60f * MathF.PI / 180f, DisplayManager.WindowSize.X / DisplayManager.WindowSize.Y);

			Glfw.SetInputMode(DisplayManager.Window, InputMode.Cursor, (int)CursorMode.Disabled);
			Glfw.GetCursorPosition(DisplayManager.Window, out double x, out double y);
			lastCurX = x;
			lastCurY = y;

			shader.Use();
		}

		protected unsafe override void Render()
		{
			string FPS = MathF.Round(1 / GameTime.DeltaTime, 2) + " FPS";
			Glfw.SetWindowTitle(DisplayManager.Window, title + " - " + FPS);

			glClearColor(0, 0, 0, 0);
			glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
			glEnable(GL_DEPTH_TEST);

			shader.SetMatrix4x4("projection", camera.GetProjectionMatrix());
			shader.SetMatrix4x4("view", camera.GetViewMatrix());

			foreach (IRenderable renderable in renderables)
			{
				renderable.Render(ref vbo, ref vao, ref shader);
			}

			Glfw.SwapBuffers(DisplayManager.Window);
		}

		double lastCurX = 0;
		double lastCurY = 0;

		protected override void Update()
		{
			Vector3 velocity = Vector3.Zero;

			if (Glfw.GetKey(DisplayManager.Window, Keys.W) == InputState.Press) velocity.Z += 1;
			if (Glfw.GetKey(DisplayManager.Window, Keys.S) == InputState.Press) velocity.Z -= 1;
			if (Glfw.GetKey(DisplayManager.Window, Keys.A) == InputState.Press) velocity.X -= 1;
			if (Glfw.GetKey(DisplayManager.Window, Keys.D) == InputState.Press) velocity.X += 1;
			if (Glfw.GetKey(DisplayManager.Window, Keys.Q) == InputState.Press) velocity.Y += 1;
			if (Glfw.GetKey(DisplayManager.Window, Keys.E) == InputState.Press) velocity.Y -= 1;
			if (velocity != Vector3.Zero) velocity = Vector3.Normalize(velocity);

			camera.Position += (
				camera.Right * velocity.X +
				Vector3.UnitY * velocity.Y +
				camera.Forward * velocity.Z
			) * GameTime.DeltaTime * 10f;

			Glfw.GetCursorPosition(DisplayManager.Window, out double x, out double y);
			double deltaCurX = x - lastCurX;
			double deltaCurY = y - lastCurY;
			lastCurX = x;
			lastCurY = y;

			Vector2 angVelocity = new Vector2((float)deltaCurX, (float)deltaCurY);
			angVelocity /= -250f;

			camera.Rotation += new Vector3(angVelocity, 0f);

			if (Glfw.GetKey(DisplayManager.Window, Keys.Escape) == InputState.Press)
			{
				Glfw.SetWindowShouldClose(DisplayManager.Window, true);
			}
		}
	}
}