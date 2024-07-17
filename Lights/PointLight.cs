using System.Numerics;

namespace BitMapRenderer.Lights
{
    public class PointLight : Light
    {
        private Vector3 position;

        public PointLight(float intensity, Vector3 position) : base(intensity)
        {
            this.position = position;
        }

        public Vector3 GetPosition()
        {
            return this.position;
        }
    }
}
