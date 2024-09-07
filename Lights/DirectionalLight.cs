using System.Numerics;

namespace RayTracingRenderer.Lights
{
    public class DirectionalLight : Light
    {
        public Vector3 Direction { get; private set; }

        public DirectionalLight(float intensity, Vector3 direction) : base(intensity)
        {
            Direction = direction;
        }
    }
}
