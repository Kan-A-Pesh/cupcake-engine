using System.Drawing;
using System.Numerics;

namespace Cupcake.Game.World.Terrain
{
	class Block
	{
		public bool IsActive
		{
			get
			{
				return m_active;
			}
			set
			{
				SetActive(value);
			}
		}

		public void SetActive(bool active)
		{
			m_active = active;
		}

		private bool m_active;

		public Color Color;

		public Block() { }

		public Block(Color color)
		{
			this.SetActive(true);
			this.Color = color;
		}

		public float[] GenerateMesh(Chunk chunk, int x, int y, int z)
		{
			if (!IsActive) return new float[] { };

			List<float> verts = new List<float>();
			Vector3 pos = new Vector3(x, y, z);

			if (!chunk.IsBlockActive(x, y + 1, z)) verts.AddRange(Quad.GenVerts(Color, Facing.TOP, pos));
			if (!chunk.IsBlockActive(x, y - 1, z)) verts.AddRange(Quad.GenVerts(Color, Facing.BOTTOM, pos));
			if (!chunk.IsBlockActive(x, y, z + 1)) verts.AddRange(Quad.GenVerts(Color, Facing.NORTH, pos));
			if (!chunk.IsBlockActive(x, y, z - 1)) verts.AddRange(Quad.GenVerts(Color, Facing.SOUTH, pos));
			if (!chunk.IsBlockActive(x + 1, y, z)) verts.AddRange(Quad.GenVerts(Color, Facing.EAST, pos));
			if (!chunk.IsBlockActive(x - 1, y, z)) verts.AddRange(Quad.GenVerts(Color, Facing.WEST, pos));

			return verts.ToArray();
		}
	}
}