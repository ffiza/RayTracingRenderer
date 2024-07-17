using System.Numerics;
using SkiaSharp;

namespace BitMapRenderer.Entities
{
    public class Sphere : Entity
    {
        private readonly float radius;
        private readonly SKColor color;

        public Sphere(Vector3 position, float radius, SKColor color) : base(position, color)
        {
            this.radius = radius;
            this.color = color;
        }

        public float GetRadius()
        {
            return this.radius;
        }
    }
}
