using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct Vector3
{
    public float x;
    public float y;
    public float z;

    public float magnitude { get => GetMagnitude(); }

    public Vector3 normalized { get => GetNormalized(); }

    public Vector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public float GetMagnitude()
    {
        return (float)Math.Sqrt(x * x + y * y + z * z);
    }

    public Vector3 GetNormalized()
    {
        return this * (1 / magnitude);
    }

    public static Vector3 operator +(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public static Vector3 operator -(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    public static Vector3 operator *(Vector3 v, float s)
    {
        return new Vector3(v.x * s, v.y * s, v.z * s);
    }

    public static Vector3 operator *(float s, Vector3 v)
    {
        return v * s;
    }

    public static bool operator ==(Vector3 a, Vector3 b)
    {
        return a.x == b.x && a.y == b.y && a.z == b.z;
    }

    public static bool operator !=(Vector3 a, Vector3 b)
    {
        return a.x != b.x || a.y != b.y || a.z != b.z;
    }

    public override string ToString()
    {
        return $"Vector {{ {x}, {y}, {z}}}";
    }

    public static float Dot(Vector3 a, Vector3 b)
    {
        return a.x * b.x + a.y * b.y + a.z * b.z;
    }

    public static Vector3 Cross(Vector3 a, Vector3 b)
    {
        return new Vector3(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
    }

}
