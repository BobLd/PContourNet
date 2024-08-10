namespace PContourNet.Tests
{
    public class ReadMeTests
    {
        [Fact]
        public void Test1()
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

            Assert.Equal(2, contours.Count);

            Assert.Equal(2, contours[0].id);
            Assert.False(contours[0].isHole);
            Assert.Equal(0, contours[0].parent);
            Assert.Equal(16, contours[0].points.Count);

            Assert.Equal(3, contours[1].id);
            Assert.True(contours[1].isHole);
            Assert.Equal(2, contours[1].parent);
            Assert.Equal(9, contours[1].points.Count);

            // simplify the polyline
            var contour0 = PContour.ApproxPolyDP(contours[0].GetPointsSpan(), 1);
            Assert.Equal(6, contour0.Length);

            var contour1 = PContour.ApproxPolyDP(contours[1].GetPointsSpan(), 1);
            Assert.Equal(5, contour1.Length);
        }
    }
}