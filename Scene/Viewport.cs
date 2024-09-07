namespace RayTracingRenderer.Scene
{
    public class Viewport
    {
        public float CameraDistance { get; private set; }
        public float Width { get; private set; }
        public float Height { get; private set; }

        public Viewport(float cameraDistance, float width, float height)
        {
            CameraDistance = cameraDistance;
            Width = width;
            Height = height;
        }
    }
}
