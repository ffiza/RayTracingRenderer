using System.Numerics;
using SkiaSharp;

namespace BitMapRenderer.Entities
{
    public class Sphere : Entity
    {
        private readonly float radius;

        public Sphere(Vector3 position, float radius, SKColor color) : base(position, color)
        {
            this.radius = radius;
        }

        public float GetRadius()
        {
            return this.radius;
        }
    }
}
