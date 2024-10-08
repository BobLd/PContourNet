﻿namespace PContourNet.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] bitmap = new int[]
            {
                0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 1, 1, 0, 0,
                0, 1, 1, 1, 1, 1, 0, 0,
                0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 1, 1, 1, 1, 0, 0,
                0, 0, 0, 1, 1, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0,
            };

            int width = 8;
            int height = 8;

            // find contours
            var contours = PContour.FindContours(bitmap, width, height);

            // simplify the polyline
            for (int i = 0; i < contours.Count; i++)
            {
                contours[i].points = PContour.ApproxPolyDP(contours[i].GetPointsSpan(), 1).ToArray().ToList();
            }
        }
    }
}
