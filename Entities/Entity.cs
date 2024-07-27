using SkiaSharp;
using System.Numerics;

namespace RayTracingRenderer.Entities
{
    public class Entity
    {
        private readonly Vector3 position;
        private readonly SKColor color;
        private readonly float specularExponent;
        private readonly float reflectionIndex;

        public Entity(Vector3 position, SKColor color, float specularExponent = -1f, float reflectionIndex = 1f)
        {
            this.position = position;
            this.color = color;
            this.specularExponent = specularExponent;
            this.reflectionIndex = reflectionIndex;
        }

        public Vector3 GetPosition()
        {
            return position;
        }

        public SKColor GetColor()
        {
            return color;
        }

        public float GetSpecularExponent()
        {
        return specularExponent;
        }

        public float GetReflectionIndex()
        {
            return reflectionIndex;
        }
    }
}
