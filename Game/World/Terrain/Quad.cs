using System.Drawing;
using System.Numerics;

namespace Cupcake.Game.World.Terrain
{
	static class Quad
	{
		public static int VertLength = 36;

		public static float[] GenVerts(Color color, Facing facing, Vector3 offset)
		{
			Vector3 vertA = Vector3.Zero;
			Vector3 vertB = Vector3.Zero;
			Vector3 vertC = Vector3.Zero;
			Vector3 vertD = Vector3.Zero;
			Vector3 normal = Vector3.Zero;

			switch (facing)
			{
				case Facing.TOP:
					vertA = new Vector3(0, 1, 0);
					vertC = new Vector3(0, 1, 1);
					vertB = new Vector3(1, 1, 0);
					vertD = new Vector3(1, 1, 1);
					normal = Vector3.UnitY;
					break;

				case Facing.BOTTOM:
					vertA = new Vector3(0, 0, 0);
					vertC = new Vector3(1, 0, 0);
					vertB = new Vector3(0, 0, 1);
					vertD = new Vector3(1, 0, 1);
					normal = -Vector3.UnitY;
					break;

				case Facing.NORTH:
					vertA = new Vector3(0, 0, 1);
					vertC = new Vector3(1, 0, 1);
					vertB = new Vector3(0, 1, 1);
					vertD = new Vector3(1, 1, 1);
					normal = Vector3.UnitZ;
					break;

				case Facing.SOUTH:
					vertA = new Vector3(0, 0, 0);
					vertC = new Vector3(0, 1, 0);
					vertB = new Vector3(1, 0, 0);
					vertD = new Vector3(1, 1, 0);
					normal = -Vector3.UnitZ;
					break;

				case Facing.EAST:
					vertA = new Vector3(1, 0, 0);
					vertC = new Vector3(1, 1, 0);
					vertB = new Vector3(1, 0, 1);
					vertD = new Vector3(1, 1, 1);
					normal = Vector3.UnitX;
					break;

				case Facing.WEST:
					vertA = new Vector3(0, 0, 0);
					vertC = new Vector3(0, 0, 1);
					vertB = new Vector3(0, 1, 0);
					vertD = new Vector3(0, 1, 1);
					normal = -Vector3.UnitX;
					break;
			}

			return new float[] {
				offset.X + vertA.X, offset.Y + vertA.Y, offset.Z + vertA.Z,
				color.R / 255f, color.G / 255f, color.B / 255f,
				normal.X, normal.Y, normal.Z,

				offset.X + vertB.X, offset.Y + vertB.Y, offset.Z + vertB.Z,
				color.R / 255f, color.G / 255f, color.B / 255f,
				normal.X, normal.Y, normal.Z,

				offset.X + vertC.X, offset.Y + vertC.Y, offset.Z + vertC.Z,
				color.R / 255f, color.G / 255f, color.B / 255f,
				normal.X, normal.Y, normal.Z,


				offset.X + vertB.X, offset.Y + vertB.Y, offset.Z + vertB.Z,
				color.R / 255f, color.G / 255f, color.B / 255f,
				normal.X, normal.Y, normal.Z,

				offset.X + vertD.X, offset.Y + vertD.Y, offset.Z + vertD.Z,
				color.R / 255f, color.G / 255f, color.B / 255f,
				normal.X, normal.Y, normal.Z,

				offset.X + vertC.X, offset.Y + vertC.Y, offset.Z + vertC.Z,
				color.R / 255f, color.G / 255f, color.B / 255f,
				normal.X, normal.Y, normal.Z,
			};
		}
	}
}