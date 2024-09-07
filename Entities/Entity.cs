using SkiaSharp;
using System.Numerics;

namespace RayTracingRenderer.Entities
{
    public class Entity
    {
        public Vector3 Position { get; protected set; }
        public SKColor Color { get; protected set; }
        public float SpecularExponent { get; protected set; }
        public float ReflectionIndex { get; protected set; }

        public Entity(Vector3 position, SKColor color, float specularExponent = -1f, float reflectionIndex = 1f)
        {
            Position = position;
            Color = color;
            SpecularExponent = specularExponent;
            ReflectionIndex = reflectionIndex;
        }
    }
}
