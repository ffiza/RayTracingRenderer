using BitMapRenderer.Entities;
using System.Numerics;

namespace BitMapRenderer.Rays
{
    public class Ray
    {
        Vector3 position;
        Vector3 direction;

        public Ray(Vector3 position, Vector3 direction)
        {
            this.position = position;
            this.direction = direction;
        }

        public Vector3 GetPosition()
        {
            return this.position;
        }

        public Vector3 GetDirection()
        { 
            return this.direction;
        }

        public Vector2 SphereIntersect(Sphere sphere)
        {
            float sphereRadius = sphere.GetRadius();
            Vector3 spherePosToRayPos = this.GetPosition() - sphere.GetPosition();

            float a = Vector3.Dot(this.GetDirection(), this.GetDirection());
            float b = 2f * Vector3.Dot(spherePosToRayPos, this.GetDirection());
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
