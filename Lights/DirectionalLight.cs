using System.Numerics;

namespace BitMapRenderer.Lights
{
    public class DirectionalLight : Light
    {
        private Vector3 direction;

        public DirectionalLight(float intensity, Vector3 direction) : base(intensity)
        {
            this.direction = direction;
        }

        public Vector3 GetDirection()
        {
            return this.direction;
        }
    }
}
