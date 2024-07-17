using System.Numerics;
using BitMapRenderer.Common;
using BitMapRenderer.Entities;
using BitMapRenderer.Lights;
using BitMapRenderer.Rays;
using BitMapRenderer.Scene;
using SkiaSharp;

class Program
{
    static void Main()
    {
        // Define the image size
        int width = 1000;
        int height = 1000;
        SKColor backgroundColor = SKColors.WhiteSmoke;

        Scene scene = new();
        Camera camera = new(Vector3.Zero);
        Viewport viewport = new(1f, 1f, 1f);
        Canvas sceneCanvas = new(width, height);
        scene.AddEntity(new Sphere(new Vector3(0f, -1f, 3f), 1f, new SKColor(255, 0, 0)));
        scene.AddEntity(new Sphere(new Vector3(2f, 0f, 4f), 1f, new SKColor(0, 0, 255)));
        scene.AddEntity(new Sphere(new Vector3(-2f, 0f, 4f), 1f, new SKColor(0, 255, 0)));
        scene.AddEntity(new Sphere(new Vector3(0f, -5001f, 0f), 5000f, new SKColor(255, 255, 0)));
        scene.AddLight(new AmbientLight(0.2f));
        scene.AddLight(new PointLight(0.6f, new Vector3(2f, 1f, 0f)));
        scene.AddLight(new DirectionalLight(0.2f, new Vector3(1f, 4f, 4f)));

        // Create a new SKBitmap object
        using var bmp = new SKBitmap(width, height);
        {
            // Create a new canvas to draw on the bitmap
            using (var canvas = new SKCanvas(bmp))
            {
                // Clear the canvas with a white color
                canvas.Clear(backgroundColor);

                // Paint the pixel in the top left corner red
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        Vector2 canvasCoords = Coordinates.ScreenToCanvas(x, y, sceneCanvas);
                        Vector2 viewportCoord = Coordinates.CanvasToViewport((int)canvasCoords.X, (int)canvasCoords.Y, sceneCanvas, viewport);
                        Vector3 viewportCoord3 = new(viewportCoord.X, viewportCoord.Y, viewport.GetCameraDistance());
                        Ray ray = new(camera.GetPosition(), viewportCoord3);
                        SKColor pixelColor = scene.TraceRay(ray, 1f, float.PositiveInfinity, backgroundColor);
                        bmp.SetPixel(x, y, pixelColor);
                    }
                }
            }

            // Save the image to a file
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
