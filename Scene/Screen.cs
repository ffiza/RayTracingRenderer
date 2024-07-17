namespace BitMapRenderer.Scene
{
    public class Screen
    {
        private float width;
        private float height;

        public Screen(float width, float height)
        {
            this.width = width;
            this.height = height;
        }

        public float GetWidth()
        {
            return this.width;
        }

        public float GetHeight()
        {
            return this.height;
        }
    }
}
