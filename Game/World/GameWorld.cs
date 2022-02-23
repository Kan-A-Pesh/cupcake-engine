using System.Drawing;
using System.Numerics;
using Cupcake.Game.World.Terrain;
using Cupcake.Numerics;
using Cupcake.Rendering.Shaders;
using Cupcake.Rendering.Meshes;
using static OpenGL.GL;
using Cupcake.Rendering;

namespace Cupcake.Game.World
{
	class GameWorld : IRenderable
	{
		public Dictionary<Vector3Int, Chunk> Chunks { get; set; }

		public GameWorld()
		{
			Chunks = new Dictionary<Vector3Int, Chunk>();
			Block[,,] Blocks = new Block[Chunk.CHUNK_SIZE, Chunk.CHUNK_SIZE, Chunk.CHUNK_SIZE];

			for (int x = 0; x < Chunk.CHUNK_SIZE; x++)
			{
				for (int z = 0; z < Chunk.CHUNK_SIZE; z++)
				{
					float height = SimplexNoise.Noise.CalcPixel2D(x, z, 0.001f) / 255f;

					for (int y = 0; y < Chunk.CHUNK_SIZE; y++)
					{
						if ((float)y > (height * Chunk.CHUNK_SIZE))
						{
							Blocks[x, y, z] = new Block();
						}
						else
						{
							int v = (int)(height * 255f);
							Color color = Color.FromArgb(255, 255 - v, v, v);
							Blocks[x, y, z] = new Block(color);
						}
					}
				}
			}

			Chunks.Add(Vector3Int.Zero, new Chunk(Blocks));
			Chunks.Add(Vector3Int.UnitX, new Chunk(Blocks));
		}

		public void Render(ref uint vbo, ref uint vao, ref Shader shader)
		{
			//List<float> verts = new List<float>();

			foreach (KeyValuePair<Vector3Int, Chunk> chunk in Chunks)
			{
				Transform transform = new Transform(chunk.Key * Chunk.CHUNK_SIZE);

				float[] data = chunk.Value.GetVertices();

				Mesh mesh = new Mesh(transform, data);
				mesh.Render(ref vbo, ref vao, ref shader);
			}

			//return verts.ToArray();
		}
	}
}