using System.Numerics;

namespace BitMapRenderer.Scene
{
    public class Camera
    {
        private Vector3 position;

        public Camera(Vector3 position)
        {
            this.position = position;
        }

        public Vector3 GetPosition()
        {
            return this.position;
        }
    }
}
