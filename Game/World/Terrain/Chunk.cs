using System.Drawing;
using System.Numerics;
using GLFW;
using OpenGL;
using static OpenGL.GL;

namespace Cupcake.Game.World.Terrain
{
	class Chunk
	{
		public const int CHUNK_SIZE = 128;

		public Block[,,] Blocks
		{
			get
			{
				return m_Blocks;
			}
			private set
			{
				m_Blocks = value;
			}
		}

		private Block[,,] m_Blocks;

		private float[] verts;

		public void SetBlock(Block block, int x, int y, int z)
		{
			m_Blocks[x, y, z] = block;
			ReloadVertices();
		}

		public Chunk()
		{
			m_Blocks = new Block[CHUNK_SIZE, CHUNK_SIZE, CHUNK_SIZE];

			for (int x = 0; x < CHUNK_SIZE; x++)
			{
				for (int y = 0; y < CHUNK_SIZE; y++)
				{
					for (int z = 0; z < CHUNK_SIZE; z++)
					{
						m_Blocks[x, y, z] = new Block();
					}
				}
			}

			verts = new float[] { 0 };
		}

		public Chunk(Block[,,] Blocks)
		{
			if (Blocks.GetLength(0) != CHUNK_SIZE)
				throw new ArgumentException("X Length of Chunk is not equal to CHUNK_SIZE", "Blocks");

			if (Blocks.GetLength(1) != CHUNK_SIZE)
				throw new ArgumentException("Y Length of Chunk is not equal to CHUNK_SIZE", "Blocks");

			if (Blocks.GetLength(2) != CHUNK_SIZE)
				throw new ArgumentException("Z Length of Chunk is not equal to CHUNK_SIZE", "Blocks");

			m_Blocks = Blocks;
			verts = new float[] { 0 };
			ReloadVertices();
		}

		public bool IsBlockActive(int x, int y, int z)
		{
			if (x < 0 || x >= CHUNK_SIZE || y < 0 || y >= CHUNK_SIZE || z < 0 || z >= CHUNK_SIZE)
				return false;

			return m_Blocks[x, y, z].IsActive;
		}

		public void ReloadVertices()
		{
			List<float> v = new List<float>();

			for (int x = 0; x < CHUNK_SIZE; x++)
			{
				for (int y = 0; y < CHUNK_SIZE; y++)
				{
					for (int z = 0; z < CHUNK_SIZE; z++)
					{
						v.AddRange(m_Blocks[x, y, z].GenerateMesh(this, x, y, z));
					}
				}
			}

			verts = v.ToArray();
		}

		public float[] GetVertices()
		{
			return verts;
		}
	}
}