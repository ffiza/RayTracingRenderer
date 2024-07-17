using BitMapRenderer.Entities;
using BitMapRenderer.Rays;
using BitMapRenderer.Lights;
using SkiaSharp;
using System;
using System.Numerics;

namespace BitMapRenderer.Scene
{
    public class Scene
    {
        private readonly List<Entity> entities = new() { };
        private readonly List<Light> lights = new() { };

        public Scene() { }

        public void AddEntity(Entity newEntity)
        {
            entities.Add(newEntity);
        }

        public List<Entity> GetEntities()
        {
            return this.entities;
        }

        public void AddLight(Light newLight)
        {
            lights.Add(newLight);
        }

        public List<Light> GetLights()
        {
            return this.lights;
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

            Vector3 pointCoords = ray.GetPosition() + closestRayParam * ray.GetDirection();
            Vector3 surfaceNormal = pointCoords - closestEntity.GetPosition();
            surfaceNormal /= surfaceNormal.Length();

            SKColor entityColor = closestEntity.GetColor();
            float intensity = ComputeLightning(pointCoords, surfaceNormal);
            SKColor color = new((byte)(entityColor.Red * intensity), (byte)(entityColor.Green * intensity), (byte)(entityColor.Blue * intensity));

            return color;
        }

        public float ComputeLightning(Vector3 pointCoords, Vector3 surfaceNormal)
        {
            float i = 0f;
            foreach (Light light in lights)
            {
                if (light is AmbientLight)
                {
                    i += light.GetIntensity();
                }
                else
                {
                    Vector3 lightDirection;
                    if (light is PointLight)
                    {
                        lightDirection = (light as PointLight).GetPosition() - pointCoords;
                    }
                    else
                    {
                        lightDirection = (light as DirectionalLight).GetDirection();
                    }
                    float normDotLight = Vector3.Dot(surfaceNormal, lightDirection);
                    if (normDotLight > 0)
                    {
                        i += light.GetIntensity() * normDotLight / surfaceNormal.Length() / lightDirection.Length();
                    }
                }
            }
            return i;
        }
    }
}
