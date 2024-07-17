namespace BitMapRenderer.Scene
{
    public class Canvas
    {
        private readonly int width;
        private readonly int height;

        public Canvas(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public int GetWidth()
        {
            return this.width;
        }

        public int GetHeight()
        {
            return this.height;
        }
    }
}
