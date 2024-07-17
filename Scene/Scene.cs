using BitMapRenderer.Entities;
using BitMapRenderer.Rays;
using SkiaSharp;
using System;
using System.Numerics;

namespace BitMapRenderer.Scene
{
    public class Scene
    {
        private List<Entity> entities = new List<Entity> { };

        public Scene() { }

        public void AddEntity(Entity newEntity)
        {
            entities.Add(newEntity);
        }

        public List<Entity> GetEntities()
        {
            return this.entities;
        }

        public SKColor TraceRay(Ray ray, float tMin, float tMax, SKColor defaultColor)
        {
            float closestRayParam = float.PositiveInfinity;
            Entity? closestEntity = null;

            foreach (Entity entity in entities)
            {
                if (entity is Sphere)
                {
                    Vector2 tIntersect = ray.SphereIntersect(entity as Sphere);
                    if ((tIntersect.X > tMin) & (tIntersect.X < tMax) & (tIntersect.X < closestRayParam))
                    {
                        closestRayParam = tIntersect.X;
                        closestEntity = entity;
                    }
                    if ((tIntersect.Y > tMin) & (tIntersect.Y < tMax) & (tIntersect.Y < closestRayParam))
                    {
                        closestRayParam = tIntersect.Y;
                        closestEntity = entity;
                    }
                }
            }
            
            if (closestEntity == null)
            {
                return defaultColor;
            }
            return closestEntity.GetColor();
        }
    }
}
