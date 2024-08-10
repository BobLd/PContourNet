# PContourNet
C# library for finding contours in binary images. Ported from java to C# from https://github.com/LingDong-/PContour

### From original README:
Similar to OpenCV's `cv::findContours` and `cv::approxPolyDP`, the algorithms implement the following papers:
- Suzuki, S. and Abe, K., Topological Structural Analysis of Digitized Binary Images by Border Following
- David Douglas and Thomas Peucker, Algorithms for the reduction of the number of points required to represent a digitized line or its caricature

## Usage
```csharp
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
```
