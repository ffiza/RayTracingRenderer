using System.Numerics;
using SkiaSharp;

namespace RayTracingRenderer.Entities
{
    public class Sphere : Entity
    {
        public float Radius { get; private set; }

        public Sphere(Vector3 position, float radius, SKColor color, float specularExponent = -1f, float reflectionIndex = 1f) : base(position, color, specularExponent, reflectionIndex)
        {
            Radius = radius;
        }
    }
}
