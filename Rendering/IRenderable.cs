using Cupcake.Rendering.Shaders;

namespace Cupcake.Rendering
{
	public interface IRenderable
	{
		public void Render(ref uint vbo, ref uint vao, ref Shader shader);
	}
}