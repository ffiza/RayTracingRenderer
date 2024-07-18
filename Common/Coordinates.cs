using RayTracingRenderer.Scene;
using System.Numerics;

namespace RayTracingRenderer.Common
{
    public class Coordinates
    {
        public Coordinates() { }

        public static Vector2 CanvasToViewport(int xCanvas, int yCanvas, Canvas canvas, Viewport viewport)
        {
            float xViewport = (float) xCanvas * viewport.GetWidth() / canvas.GetWidth();
            float yViewport = (float) yCanvas * viewport.GetHeight() / canvas.GetHeight();
            return new Vector2(xViewport, yViewport);
        }

        public static Vector2 CanvasToScreen(int xCanvas, int yCanvas, Canvas canvas)
        {
            int xScreen = xCanvas + canvas.GetWidth() / 2;
            int yScreen = - yCanvas + canvas.GetHeight() / 2;
            return new Vector2(xScreen, yScreen);
        }

        public static Vector2 ScreenToCanvas(int xScreen, int yScreen, Canvas canvas)
        {
            int xCanvas = xScreen - canvas.GetWidth() / 2;
            int yCanvas = -yScreen + canvas.GetHeight() / 2;
            return new Vector2(xCanvas, yCanvas);
        }
    }
}
