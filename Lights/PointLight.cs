using System.Numerics;

namespace RayTracingRenderer.Lights
{
    public class PointLight : Light
    {
        public Vector3 Position { get; private set; }

        public PointLight(float intensity, Vector3 position) : base(intensity)
        {
            Position = position;
        }
    }
}
