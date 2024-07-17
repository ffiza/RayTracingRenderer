using System.Numerics;
using BitMapRenderer.Common;
using BitMapRenderer.Entities;
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

        Scene scene = new Scene();
        Camera camera = new Camera(Vector3.Zero);
        Viewport viewport = new Viewport(1f, 1f, 1f);
        Canvas sceneCanvas = new Canvas(width, height);
        Sphere sphere = new Sphere(new Vector3(0f, -1f, 3f), 1f, new SKColor(255, 0, 0));
        scene.AddEntity(sphere);
        sphere = new Sphere(new Vector3(2f, 0f, 10f), 1f, new SKColor(0, 0, 255));
        scene.AddEntity(sphere);
        sphere = new Sphere(new Vector3(-2f, 0f, 4f), 1f, new SKColor(0, 255, 0));
        scene.AddEntity(sphere);

        // Create a new SKBitmap object
        using (var bmp = new SKBitmap(width, height))
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
                        Vector2 viewportCoord = Coordinates.CanvasToViewport((int) canvasCoords.X, (int) canvasCoords.Y, sceneCanvas, viewport);
                        Vector3 viewportCoord3 = new Vector3(viewportCoord.X, viewportCoord.Y, viewport.GetCameraDistance());
                        Ray ray = new Ray(camera.GetPosition(), viewportCoord3);
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
