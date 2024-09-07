namespace RayTracingRenderer.Scene
{
    public class Screen
    {
        public float Width { get; private set; }
        public float Height { get; private set; }

        public Screen(float width, float height)
        {
            Width = width;
            Height = height;
        }
    }
}
