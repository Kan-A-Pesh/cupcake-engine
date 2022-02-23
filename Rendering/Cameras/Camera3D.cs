using System.Numerics;
using Cupcake.GameLoop;
using Cupcake.Rendering.Display;

namespace Cupcake.Rendering.Cameras
{
	class Camera3D
	{
		public float Fov { get; set; }
		public float AspectRatio { get; set; }

		public Vector3 Position { get; set; }

		public Vector3 Rotation { get; set; }

		public Vector3 Forward
		{
			get
			{
				Vector3 r = Rotation;

				Vector2 cos = new Vector2(MathF.Cos(r.X), MathF.Cos(r.Y));
				Vector2 sin = new Vector2(MathF.Sin(r.X), MathF.Sin(r.Y));

				return -new Vector3(sin.X * MathF.Abs(cos.Y), -sin.Y, cos.X * MathF.Abs(cos.Y));
			}
		}

		public Vector3 Right
		{
			get
			{
				return Vector3.Normalize(Vector3.Cross(Vector3.UnitY, -Forward));
			}
		}

		public Vector3 Up
		{
			get
			{
				return Vector3.Normalize(Vector3.Cross(-Forward, Right));
			}
		}



		public Camera3D(float fov, float aspectRatio)
		{
			this.Fov = fov;
			this.AspectRatio = aspectRatio;
			this.Position = Vector3.Zero;
			this.Rotation = Vector3.Zero;
		}

		public Matrix4x4 GetProjectionMatrix()
		{
			Matrix4x4 mat = Matrix4x4.CreatePerspectiveFieldOfView(Fov, AspectRatio, 0.01f, 1000f);

			return mat;
		}

		public Matrix4x4 GetViewMatrix()
		{

			Matrix4x4 trans = Matrix4x4.CreateTranslation(Position.X, Position.Y, Position.Z);
			Matrix4x4 rot = Matrix4x4.CreateFromYawPitchRoll(Rotation.X, Rotation.Y, Rotation.Z);

			if (Matrix4x4.Invert(rot * trans, out Matrix4x4 invert))
			{
				return invert;
			}
			else
			{
				throw new NotSupportedException("Inverse of View Matrix cannot be calculated");
			}
		}
	}
}