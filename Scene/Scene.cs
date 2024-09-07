using RayTracingRenderer.Entities;
using RayTracingRenderer.Rays;
using RayTracingRenderer.Lights;
using SkiaSharp;
using System.Numerics;

namespace RayTracingRenderer.Scene
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

        public List<object> ClosestIntersection(Ray ray, float tMin, float tMax)
        {
            List<object> result = new();
            float closestRayParam = float.PositiveInfinity;
            Entity? closestEntity = null;

            foreach (Entity entity in entities)
            {
                if ((Sphere)entity is not null)
                {
                    Vector2 tIntersect = ray.SphereIntersect((Sphere)entity);
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
            result.Add(closestEntity);
            result.Add(closestRayParam);
            return result;
        }

        public Vector3 TraceRay(Ray ray, float tMin, float tMax, Vector3 defaultColor, int recursionDepth)
        {
            List<object> closestIntersection = ClosestIntersection(ray, tMin, tMax);
            Entity closestEntity = (Entity)closestIntersection[0];
            float closestRayParam = (float)closestIntersection[1];

            if (closestEntity == null)
            {
                return defaultColor;
            }

            Vector3 pointCoords = ray.Position + closestRayParam * ray.Direction;
            Vector3 surfaceNormal = pointCoords - closestEntity.Position;
            surfaceNormal /= surfaceNormal.Length();

            SKColor entityColor = closestEntity.Color;
            float intensity = ComputeLightning(pointCoords, surfaceNormal, - ray.Direction, closestEntity.SpecularExponent, tMax);
            Vector3 localColor = new(entityColor.Red * intensity,
                                     entityColor.Green * intensity,
                                     entityColor.Blue * intensity);
            localColor = ClampColor(localColor);

            // Check the recursion depth
            float r = closestEntity.ReflectionIndex;
            if ((recursionDepth <= 0) || (r <= 0f))
            {
                return localColor;
            }

            // Compute reflection
            Vector3 reflectedDir = -Vector3.Reflect(-ray.Direction, surfaceNormal);
            Ray reflectedRay = new(pointCoords, reflectedDir);
            Vector3 reflectedColor = TraceRay(reflectedRay, 0.05f, float.PositiveInfinity, defaultColor, recursionDepth - 1);

            // Blend result
            Vector3 color = localColor * (1 - r) + reflectedColor * r;
            return color;
        }

        public static void PrintColorDebug(Vector3 color)
        {
            if (color.X > 255) { Console.WriteLine("R: " + color.X); }
            if (color.Y > 255) { Console.WriteLine("G: " + color.Y); }
            if (color.Z > 255) { Console.WriteLine("B: " + color.Z); }
        }

        public static Vector3 ClampColor(Vector3 color)
        {
            Byte rValue = (byte)Math.Clamp((int)color.X, 0, 255);
            Byte gValue = (byte)Math.Clamp((int)color.Y, 0, 255);
            Byte bValue = (byte)Math.Clamp((int)color.Z, 0, 255);
            return new Vector3(rValue, gValue, bValue);
        }

        public float ComputeLightning(Vector3 pointCoords, Vector3 surfaceNormal, Vector3 viewDirection, float specularExponent, float tMax)
        {
            float i = 0f;
            foreach (Light light in this.GetLights())
            {
                if (light is AmbientLight)
                {
                    i += light.Intensity;
                }
                else
                {
                    Vector3 lightDirection;
                    if (light is PointLight)
                    {
                        lightDirection = ((PointLight)light).Position - pointCoords;
                    }
                    else
                    {
                        lightDirection = ((DirectionalLight)light).Direction;
                    }

                    // Shadow check
                    Ray shadowRay = new(pointCoords, lightDirection);
                    List<object> closestIntersection = ClosestIntersection(shadowRay, 0.001f, tMax);
                    Entity closestEntity = (Entity)closestIntersection[0];
                    if (closestEntity is not null)
                    {
                        continue;
                    }

                    // Diffuse reflection
                    float normDotLight = Vector3.Dot(surfaceNormal, lightDirection);
                    if (normDotLight > 0)
                    {
                        i += light.Intensity * normDotLight / surfaceNormal.Length() / lightDirection.Length();
                    }

                    // Compute specular reflection
                    if (specularExponent > -1)
                    {
                        Vector3 reflectedDir = - Vector3.Reflect(lightDirection, surfaceNormal);
                        float reflectedDotView = Vector3.Dot(reflectedDir, viewDirection);
                        if (reflectedDotView > 0)
                        {
                            i += light.Intensity * MathF.Pow(reflectedDotView / reflectedDir.Length() / viewDirection.Length(), specularExponent);
                        }
                    }
                }
            }
            return i;
        }
    }
}
