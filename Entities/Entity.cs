using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingRenderer.Entities
{
    public class Entity
    {
        private readonly Vector3 position;
        private readonly SKColor color;
        private readonly float specularExponent;

        public Entity(Vector3 position, SKColor color, float specularExponent = -1f)
        {
            this.position = position;
            this.color = color;
            this.specularExponent = specularExponent;
        }

        public Vector3 GetPosition()
        {
            return this.position;
        }

        public SKColor GetColor()
        {
            return this.color;
        }

        public float GetSpecularExponent()
        {
        return this.specularExponent;
        }
    }
}
