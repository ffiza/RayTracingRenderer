namespace BitMapRenderer.Lights
{
    internal class BaseLight
    {
        private readonly float intensity;
        
        public BaseLight(float intensity)
        {
            this.intensity = intensity;
        }

        public float GetIntensity()
        {
            return intensity;
        }
    }
}
