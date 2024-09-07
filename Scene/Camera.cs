using System.Numerics;

namespace RayTracingRenderer.Scene
{
    public class Camera
    {
        public Vector3 Position { get; private set; }

        public Camera(Vector3 position)
        {
            Position = position;
        }
    }
}
