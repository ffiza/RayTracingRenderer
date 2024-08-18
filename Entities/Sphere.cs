using System.Numerics;
using SkiaSharp;

namespace RayTracingRenderer.Entities
{
    public class Sphere : Entity
    {
        private readonly float radius;

        public Sphere(Vector3 position, float radius, SKColor color, float specularExponent = -1f, float reflectionIndex = 1f) : base(position, color, specularExponent, reflectionIndex)
        {
            this.radius = radius;
        }

        public float GetRadius()
        {
            return this.radius;
        }
    }
}
