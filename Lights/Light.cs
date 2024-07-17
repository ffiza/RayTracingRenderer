namespace BitMapRenderer.Lights
{
    internal class Light
    {
        private readonly float intensity;
        
        public Light(float intensity)
        {
            this.intensity = intensity;
        }

        public float GetIntensity()
        {
            return intensity;
        }
    }
}
