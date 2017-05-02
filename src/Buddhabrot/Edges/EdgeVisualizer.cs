﻿using System.Drawing;
using Buddhabrot.Images;
using log4net;

namespace Buddhabrot.Edges
{
    static class EdgeVisualizer
    {
        private static readonly ILog Log = LogManager.GetLogger(nameof(EdgeLocator));

        public static void Render(string edgesFilePath, string imageFilePath)
        {
            Log.Info($"Loading file: {edgesFilePath}, output image: {imageFilePath}");

            var edgeAreas = EdgeAreas.Load(edgesFilePath);
            var image = new FastImage(edgeAreas.GridResolution);
            image.Fill(Color.White);
            var halfHeight = edgeAreas.GridResolution.Height / 2;
            foreach (var location in edgeAreas.GetAreaLocations())
            {
                // the grid locations are based on the real axis
                image.SetPixel(location.X, halfHeight - location.Y, Color.Black);
                image.SetPixel(location.X, location.Y + halfHeight, Color.Black);
            }
            image.Save(imageFilePath);
        }
    }
}
