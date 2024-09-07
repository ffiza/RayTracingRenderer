using RayTracingRenderer.Entities;
using System.Numerics;

namespace RayTracingRenderer.Rays
{
    public class Ray
    {
        public Vector3 Position { get; private set; }
        public Vector3 Direction { get; private set; }

        public Ray(Vector3 position, Vector3 direction)
        {
            Position = position;
            Direction = direction;
        }

        public Vector2 SphereIntersect(Sphere sphere)
        {
            float sphereRadius = sphere.Radius;
            Vector3 spherePosToRayPos = Position - sphere.Position;

            float a = Vector3.Dot(Direction, Direction);
            float b = 2f * Vector3.Dot(spherePosToRayPos, Direction);
            float c = Vector3.Dot(spherePosToRayPos, spherePosToRayPos) - sphereRadius * sphereRadius;

            float discriminant = b * b - 4 * a * c;
            if (discriminant < 0)
            {
                return new Vector2(float.PositiveInfinity, float.PositiveInfinity);
            }

            float firstParam = (-b + MathF.Sqrt(discriminant)) / (2 * a);
            float secondParam = (-b - MathF.Sqrt(discriminant)) / (2 * a);
            return new Vector2(firstParam, secondParam);
        }
    }
}
