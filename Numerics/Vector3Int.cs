using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Cupcake.Numerics
{
	public struct Vector3Int : IEquatable<Vector3Int>, IFormattable
	{
		public int X;
		public int Y;
		public int Z;

		public Vector3Int(int value)
		{
			X = value;
			Y = value;
			Z = value;
		}

		public Vector3Int(ReadOnlySpan<int> values)
		{
			X = values[0];
			Y = values[1];
			Z = values[2];
		}

		//public Vector3Int(Vector2Int value, float z);
		public Vector3Int(int x, int y, int z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public static Vector3Int UnitY { get { return new Vector3Int(0, 1, 0); } }
		public static Vector3Int UnitX { get { return new Vector3Int(1, 0, 0); } }
		public static Vector3Int One { get { return new Vector3Int(1, 1, 1); } }
		public static Vector3Int UnitZ { get { return new Vector3Int(0, 0, 1); } }
		public static Vector3Int Zero { get { return new Vector3Int(0, 0, 0); } }

		public readonly override bool Equals([NotNullWhen(true)] object? obj)
		{
			if (obj is Vector3Int)
			{
				return Equals((Vector3Int)obj);
			}

			return false;
		}

		public readonly bool Equals(Vector3Int other)
		{
			return
				other.X == this.X &&
				other.Y == this.Y &&
				other.Z == this.Z;
		}

		public readonly override int GetHashCode()
		{
			return X.GetHashCode() ^ Y.GetHashCode() << 2 ^ Z.GetHashCode() >> 2;
		}

		public readonly string ToString(string? format, IFormatProvider? formatProvider)
		{
			return ToString();
		}

		public readonly string ToString(string? format)
		{
			return ToString();
		}


		public readonly override string ToString()
		{
			return "<" + X + ", " + Y + ", " + Z + ">";
		}
		public static Vector3Int operator *(int left, Vector3Int right)
		{
			return right * left;
		}
		public static Vector3Int operator *(Vector3Int left, int right)
		{
			left.X *= right;
			left.Y *= right;
			left.Z *= right;
			return left;
		}

		public static implicit operator Vector3(Vector3Int v)
		{
			return new Vector3(v.X, v.Y, v.Z);
		}

		/*public static Vector3Int Abs(Vector3Int value);
		public static Vector3Int Add(Vector3Int left, Vector3Int right);
		public static Vector3Int Clamp(Vector3Int value1, Vector3Int min, Vector3Int max);
		public static Vector3Int Cross(Vector3Int vector1, Vector3Int vector2);
		public static float Distance(Vector3Int value1, Vector3Int value2);
		public static float DistanceSquared(Vector3Int value1, Vector3Int value2);
		public static Vector3Int Divide(Vector3Int left, Vector3Int right);
		public static Vector3Int Divide(Vector3Int left, float divisor);
		public static float Dot(Vector3Int vector1, Vector3Int vector2);
		public static Vector3Int Lerp(Vector3Int value1, Vector3Int value2, float amount);
		public static Vector3Int Max(Vector3Int value1, Vector3Int value2);
		public static Vector3Int Min(Vector3Int value1, Vector3Int value2);
		public static Vector3Int Multiply(Vector3Int left, Vector3Int right);
		public static Vector3Int Multiply(float left, Vector3Int right);
		public static Vector3Int Multiply(Vector3Int left, float right);
		public static Vector3Int Negate(Vector3Int value);
		public static Vector3Int Normalize(Vector3Int value);
		public static Vector3Int Reflect(Vector3Int vector, Vector3Int normal);
		public static Vector3Int SquareRoot(Vector3Int value);
		public static Vector3Int Subtract(Vector3Int left, Vector3Int right);
		public static Vector3Int Transform(Vector3Int position, Matrix4x4 matrix);
		public static Vector3Int Transform(Vector3Int value, Quaternion rotation);
		public static Vector3Int TransformNormal(Vector3Int normal, Matrix4x4 matrix);
		public readonly void CopyTo(Span<float> destination);
		public readonly void CopyTo(float[] array);
		public readonly void CopyTo(float[] array, int index);
		public readonly override string ToString();
		public readonly float Length();
		public readonly float LengthSquared();
		public readonly bool TryCopyTo(Span<float> destination);

		public static Vector3Int operator +(Vector3Int left, Vector3Int right);
		public static Vector3Int operator -(Vector3Int value);
		public static Vector3Int operator -(Vector3Int left, Vector3Int right);
		public static Vector3Int operator *(Vector3Int left, Vector3Int right);
		public static Vector3Int operator /(Vector3Int left, Vector3Int right);
		public static Vector3Int operator /(Vector3Int value1, float value2);
		public static bool operator ==(Vector3Int left, Vector3Int right);
		public static bool operator !=(Vector3Int left, Vector3Int right);*/
	}
}