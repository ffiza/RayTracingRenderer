using System;
using SkiaSharp;

class Program
{
    static void Main()
    {
        // Define the image size
        int width = 800;
        int height = 600;

        // Create a new SKBitmap object
        using (var bmp = new SKBitmap(width, height))
        {
            // Create a new canvas to draw on the bitmap
            using (var canvas = new SKCanvas(bmp))
            {
                // Clear the canvas with a white color
                canvas.Clear(SKColors.White);

                // Paint the pixel in the top left corner red
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        bmp.SetPixel(x, y, new SKColor(255, 0, 0));
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
