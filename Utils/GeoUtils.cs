using fagsystem_1.Dtos;

namespace fagsystem_1.Utils;


public static class GeoUtils
{
    public static BBox CalcBbox(IEnumerable<UtmPoint> points)
    {
        if (points == null || !points.Any())
        {
            return new BBox();
        }

        double minX = double.MaxValue;
        double minY = double.MaxValue;
        double maxX = double.MinValue;
        double maxY = double.MinValue;

        foreach (var point in points)
        {
            if (point.X < minX)
                minX = point.X;
            if (point.X > maxX)
                maxX = point.X;

            if (point.Y < minY)
                minY = point.Y;
            if (point.Y > maxY)
                maxY = point.Y;
        }

        var bbox = new BBox
        {
            Left = minX,
            Bottom = minY,
            Right = maxX,
            Top = maxY
        };

        return bbox;
    }

    public static bool BBoxIntersects(BBox bbox1, BBox bbox2)
    {
        if (bbox1.Right < bbox2.Left || bbox1.Left > bbox2.Right ||
            bbox1.Top < bbox2.Bottom || bbox1.Bottom > bbox2.Top)
        {
            return false;
        }
        return true;
    }


}