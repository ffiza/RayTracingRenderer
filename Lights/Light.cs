namespace RayTracingRenderer.Lights
{
    public class Light
    {
        public float Intensity { get; protected set; }
        
        public Light(float intensity)
        {
            Intensity = intensity;
        }
    }
}
