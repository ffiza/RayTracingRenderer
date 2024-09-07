namespace RayTracingRenderer.Scene
{
    public class Canvas
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Canvas(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
