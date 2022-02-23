using Cupcake.Numerics;
using Cupcake.Rendering.Shaders;
using static OpenGL.GL;

namespace Cupcake.Rendering.Meshes
{
	public class Mesh
	{
		public Transform Transform;
		public float[] Data;

		public Mesh(Transform transform, float[] data)
		{
			Transform = transform;
			Data = data;
		}

		public unsafe void Render(ref uint vbo, ref uint vao, ref Shader shader)
		{
			fixed (float* v = &Data[0])
			{
				glBufferData(GL_ARRAY_BUFFER, sizeof(float) * Data.Length, v, GL_STATIC_DRAW);
				/*void* ptr = (void*)glMapBuffer(GL_ARRAY_BUFFER, GL_WRITE_ONLY);
				Buffer.MemoryCopy(data, ptr, size, size);
				glUnmapBuffer(GL_ARRAY_BUFFER);*/
			}

			glBindBuffer(GL_ARRAY_BUFFER, vbo);

			shader.SetMatrix4x4("model", Transform.GetTRSMatrix());

			glBindVertexArray(vao);
			glDrawArrays(GL_TRIANGLES, 0, Data.Length / 9);
		}
	}
}