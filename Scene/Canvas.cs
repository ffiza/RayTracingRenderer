namespace BitMapRenderer.Scene
{
    public class Canvas
    {
        private int width;
        private int height;

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
