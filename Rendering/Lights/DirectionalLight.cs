using System.Numerics;
using Cupcake.Rendering.Shaders;

namespace Cupcake.Rendering.Lights
{
	public class DirectionalLight : IRenderable
	{
		private bool shouldRender;
		private Vector3 lightDir;

		public void Render(ref uint vbo, ref uint vao, ref Shader shader)
		{
			if (shouldRender)
			{
				shader.SetVector3("lightDir", lightDir);
				shouldRender = false;
			}
		}

		public DirectionalLight(Vector3 direction)
		{
			SetDirection(direction);
		}

		public void SetDirection(Vector3 direction)
		{
			lightDir = direction;
			shouldRender = true;
		}
	}
}