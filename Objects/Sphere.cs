using System.Numerics;
using SkiaSharp;

namespace BitMapRenderer.Objects
{
    public class Sphere
    {
        private readonly Vector3 position;
        private readonly float radius;
        private readonly SKColor color;

        public Sphere(float xPosition, float yPosition, float zPosition, float radius, Byte rColor = 255, Byte gColor = 255, Byte bColor = 255)
        {
            this.position = new Vector3(xPosition, yPosition, zPosition);
            this.radius = radius;
            this.color = new SKColor(rColor, gColor, bColor);
        }

        public Vector3 GetPosition()
        {
            return this.position;
        }

        public float GetRadius()
        {
            return this.radius;
        }

        public SKColor GetColor()
        {
            return this.color;
        }
    }
}
