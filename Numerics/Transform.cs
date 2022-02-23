using System.Numerics;

namespace Cupcake.Numerics
{
	public struct Transform
	{
		public Vector3 Position;
		public Vector3 Rotation;
		public Vector3 Scale;

		public Transform()
		{
			Position = Vector3.Zero;
			Rotation = Vector3.Zero;
			Scale = Vector3.One;
		}
		public Transform(Vector3 position)
		{
			Position = position;
			Rotation = Vector3.Zero;
			Scale = Vector3.One;
		}
		public Transform(Vector3 position, Vector3 rotation)
		{
			Position = position;
			Rotation = rotation;
			Scale = Vector3.One;
		}
		public Transform(Vector3 position, Vector3 rotation, Vector3 scale)
		{
			Position = position;
			Rotation = rotation;
			Scale = scale;
		}

		public Matrix4x4 GetTRSMatrix()
		{
			Matrix4x4 trans = Matrix4x4.CreateTranslation(Position.X, Position.Y, Position.Z);
			Matrix4x4 sca = Matrix4x4.CreateScale(Scale.X, Scale.Y, Scale.Z);
			Matrix4x4 rot = Matrix4x4.CreateFromYawPitchRoll(Rotation.X, Rotation.Y, Rotation.Z);

			return sca * rot * trans;
		}
	}
}