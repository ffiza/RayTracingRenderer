using RayTracingRenderer.Scene;
using System.Numerics;

namespace RayTracingRenderer.Common
{
    public static class Coordinates
    {
        /// <summary>
        /// Return the viewport space coordinates based on the canvas space coordinates.
        /// </summary>
        /// <param name="xCanvas">The x position in canvas coordinates.</param>
        /// <param name="yCanvas">The y position in canvas coordinates.</param>
        /// <param name="canvas">The <c>Canvas</c> instance.</param>
        /// <param name="viewport">The <c>Viewport</c> instance.</param>
        /// <returns>The coordinates in viewport space.</returns>
        public static Vector2 CanvasToViewport(int xCanvas, int yCanvas, Canvas canvas, Viewport viewport)
        {
            float xViewport = xCanvas * viewport.GetWidth() / canvas.GetWidth();
            float yViewport = yCanvas * viewport.GetHeight() / canvas.GetHeight();
            return new Vector2(xViewport, yViewport);
        }

        /// <summary>
        /// Return the screen space coordinates based on the canvas space coordinates.
        /// </summary>
        /// <param name="xCanvas">The x position in canvas coordinates.</param>
        /// <param name="yCanvas">The y position in canvas coordinates.</param>
        /// <param name="canvas">The <c>Canvas</c> instance.</param>
        /// <returns>The coordinates in screen space.</returns>
        public static Vector2 CanvasToScreen(int xCanvas, int yCanvas, Canvas canvas)
        {
            int xScreen = xCanvas + canvas.GetWidth() / 2;
            int yScreen = - yCanvas + canvas.GetHeight() / 2;
            return new Vector2(xScreen, yScreen);
        }


        /// <summary>
        /// Return the canvas space coordinates based on the screen space coordinates.
        /// </summary>
        /// <param name="xScreen">The x position in screen coordinates.</param>
        /// <param name="yScreen">The y position in screen coordinates.</param>
        /// <param name="canvas">The <c>Canvas</c> instance.</param>
        /// <returns>The coordinates in canvas space.</returns>
        public static Vector2 ScreenToCanvas(int xScreen, int yScreen, Canvas canvas)
        {
            int xCanvas = xScreen - canvas.GetWidth() / 2;
            int yCanvas = -yScreen + canvas.GetHeight() / 2;
            return new Vector2(xCanvas, yCanvas);
        }
    }
}
