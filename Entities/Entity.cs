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
        private Vector3 position;
        private readonly SKColor color;

        public Entity(Vector3 position, SKColor color)
        {
            this.position = position;
            this.color = color;
        }

        public Vector3 GetPosition()
        {
            return this.position;
        }

        public SKColor GetColor()
        {
            return this.color;
        }
    }
}
