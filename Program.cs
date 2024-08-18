using System.Numerics;
using RayTracingRenderer.Common;
using RayTracingRenderer.Entities;
using RayTracingRenderer.Lights;
using RayTracingRenderer.Rays;
using RayTracingRenderer.Scene;
using SkiaSharp;

class Program
{
    static void Main()
    {
        // Define the image size
        int width = 1000;
        int height = 1000;
        Vector3 backgroundColor = Vector3.Zero;

        int recursionDepth = 3;

        Scene scene = new();
        Camera camera = new(Vector3.Zero);
        Viewport viewport = new(1f, 1f, 1f);
        Canvas sceneCanvas = new(width, height);
        scene.AddEntity(new Sphere(new Vector3(0f, -1f, 3f), 1f, new SKColor(255, 0, 0), 500f, 0.2f));
        scene.AddEntity(new Sphere(new Vector3(2f, 0f, 4f), 1f, new SKColor(0, 0, 255), 500f, 0.4f));
        scene.AddEntity(new Sphere(new Vector3(-2f, 0f, 4f), 1f, new SKColor(0, 255, 0), 10f, 0.3f));
        scene.AddEntity(new Sphere(new Vector3(0f, -5001f, 0f), 5000f, new SKColor(255, 255, 0), 1000f, 0.5f));
        scene.AddLight(new AmbientLight(0.2f));
        scene.AddLight(new PointLight(0.6f, new Vector3(2f, 1f, 0f)));
        scene.AddLight(new DirectionalLight(0.2f, new Vector3(1f, 4f, 4f)));

        using var bmp = new SKBitmap(width, height);
        {
            using (var canvas = new SKCanvas(bmp))
            {
                canvas.Clear(new SKColor((byte)backgroundColor.X, (byte)backgroundColor.Y, (byte)backgroundColor.Z));

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        Vector2 canvasCoords = Coordinates.ScreenToCanvas(x, y, sceneCanvas);
                        Vector2 viewportCoord = Coordinates.CanvasToViewport((int)canvasCoords.X, (int)canvasCoords.Y, sceneCanvas, viewport);
                        Vector3 viewportCoord3 = new(viewportCoord.X, viewportCoord.Y, viewport.GetCameraDistance());
                        Ray ray = new(camera.GetPosition(), viewportCoord3);
                        Vector3 pixelColor = Scene.ClampColor(scene.TraceRay(ray, 1f, float.PositiveInfinity, backgroundColor, recursionDepth));
                        bmp.SetPixel(x, y, new SKColor((byte)pixelColor.X, (byte)pixelColor.Y, (byte)pixelColor.Z));
                    }
                }
            }

            string filePath = "image.png";
            using (var image = SKImage.FromBitmap(bmp))
            using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
            using (var stream = System.IO.File.OpenWrite(filePath))
            {
                data.SaveTo(stream);
            }

            Console.WriteLine($"Image saved to {filePath}");
        }
    }
}
