﻿namespace BitMapRenderer.Scene
{
    public class Viewport
    {
        private float cameraDistance;
        private float width;
        private float height;

        public Viewport(float cameraDistance, float width, float height)
        {
            this.cameraDistance = cameraDistance;
            this.width = width;
            this.height = height;
        }

        public float GetCameraDistance()
        {
            return this.cameraDistance;
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
