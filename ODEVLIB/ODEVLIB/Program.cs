/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**			         BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				          PROGRAMLAMAYA GİRİŞİ DERSİ
**	
**				ÖDEV NUMARASI…...: 2
**				ÖĞRENCİ ADI...............: EMİR ALİ DUMAN
**				ÖĞRENCİ NUMARASI.: G231210004
**				DERS GRUBU…………: 2. ÖĞRETİM C GRUBU
****************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ODEVLIB
{
    public static class Collisions
    {
       // Classes of the shapes
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }
        }

        public class Quadrilateral
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
        }

        public class Circle
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Radius { get; set; }
        }
        public class Rectangle
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
        }
        public class Sphere
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }
            public int Radius { get; set; }
        }
        public class Cylinder
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }
            public int Radius { get; set; }
            public int Height { get; set; }
        }
        public class Surface
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int Z { get; set; }
        }
        public class RectangularPrism
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int Z { get; set; }
            public int Depth { get; set; }
        }
        // Lists and dictionaries for the shapes
        public static List<Point> points = new List<Point>();
        public static Dictionary<Point, Quadrilateral> pointQuadMap = new Dictionary<Point, Quadrilateral>();
        public static Dictionary<Point, Circle > pointCircleMap = new Dictionary<Point, Circle>();
        public static Dictionary<Point, RectangularPrism> pointRectangularMap = new Dictionary<Point, RectangularPrism>();
        public static Dictionary<Point, Sphere> pointSphereMap = new Dictionary<Point, Sphere>();
        public static Dictionary<Point, Cylinder> pointCylinderMap = new Dictionary<Point, Cylinder>();
        public static Dictionary<Rectangle,Rectangle>rectangleRectangleMap = new Dictionary<Rectangle, Rectangle>();
        public static Dictionary<Rectangle, Circle> rectangleCircleMap = new Dictionary<Rectangle, Circle>();
        public static Dictionary<RectangularPrism,RectangularPrism> rectangularRectangularMap = new Dictionary<RectangularPrism, RectangularPrism>();
        public static Dictionary<RectangularPrism,Surface> rectangularSurfaceMap = new Dictionary<RectangularPrism, Surface>();
        public static Dictionary<Surface ,Sphere> surfaceSphereMap = new Dictionary<Surface, Sphere>();
        public static Dictionary<Surface, Cylinder> surfaceCylinderMap = new Dictionary<Surface, Cylinder>();
        public static Dictionary<RectangularPrism, Sphere> rectangularSphereMap = new Dictionary<RectangularPrism, Sphere>();
        public static Dictionary<Sphere,Sphere> sphereSphereMap = new Dictionary<Sphere, Sphere>();
        public static Dictionary<Circle,Circle> circleCircleMap = new Dictionary<Circle, Circle>();
        public static Dictionary<Sphere,Cylinder> sphereCylinderMap = new Dictionary<Sphere, Cylinder>();
        public static Dictionary<Cylinder,Cylinder> cylinderCylinderMap = new Dictionary<Cylinder, Cylinder>();
        public static Dictionary<Point, Rectangle> pointRectangleMap = new Dictionary<Point, Rectangle>();
        public static Dictionary<Point, Surface> pointSurfaceMap = new Dictionary<Point, Surface>();
        
        // Add shape methods
        public static void AddPointShape(Point p, object shape)
        {
            points.Add(p);
            switch (shape)
            {
                case Quadrilateral q:
                    pointQuadMap.Add(p, q);
                    break;
                case Circle c:
                    pointCircleMap.Add(p, c);
                    break;
                case Rectangle r:
                    pointRectangleMap.Add(p, r);
                    break;
                case Sphere s:
                    pointSphereMap.Add(p, s);
                    break;
                case Cylinder cy:
                    pointCylinderMap.Add(p, cy);
                    break;
                case Surface su:
                    pointSurfaceMap.Add(p, su);
                    break;
                case RectangularPrism rp:
                    pointRectangularMap.Add(p, rp);
                    break;
            }
        }
        
        // Collision methods for the shapes
        public static bool PointQuadCol(Point p, Quadrilateral s)
        {
            if (p.X > s.X && p.X < s.X + s.Width && p.Y > s.Y && p.Y < s.Y + s.Height)
            {
                return true;
            }
            return false;
        }
        public static bool PointSphereCol(Point p, Sphere s)
        {
            if (Math.Sqrt(Math.Pow(p.X - s.X, 2) + Math.Pow(p.Y - s.Y, 2) + Math.Pow(p.Z - s.Z, 2)) < s.Radius)
            {
                return true;
            }
            return false;
        }
        public static bool PointCylinderCol(Point p, Cylinder s)
        {
            if (Math.Sqrt(Math.Pow(p.X - s.X, 2) + Math.Pow(p.Y - s.Y, 2) + Math.Pow(p.Z - s.Z, 2)) < s.Radius && p.Z < s.Height)
            {
                return true;
            }
            return false;
        }
        public static bool PointSurfaceCol(Point p, Surface s)
        {
            if (p.X > s.X && p.X < s.X + s.Width && p.Y > s.Y && p.Y < s.Y + s.Height && p.Z == s.Z)
            {
                return true;
            }
            return false;
        }
        public static bool PointRectangularCol(Point p, RectangularPrism s)
        {
            if (p.X > s.X && p.X < s.X + s.Width && p.Y > s.Y && p.Y < s.Y + s.Height && p.Z > s.Z && p.Z < s.Z + s.Depth)
            {
                return true;
            }
            return false;
        }
        public static bool RectRectCol(Rectangle r1, Rectangle r2)
        {
            if (r1.X < r2.X + r2.Width && r1.X + r1.Width > r2.X && r1.Y < r2.Y + r2.Height && r1.Y + r1.Height > r2.Y)
            {
                return true;
            }
            return false;
        }
        public static bool RectCircleCol(Rectangle r, Circle c)
        {
            if (Math.Sqrt(Math.Pow(c.X - Math.Max(r.X, Math.Min(c.X, r.X + r.Width)), 2) + Math.Pow(c.Y - Math.Max(r.Y, Math.Min(c.Y, r.Y + r.Height)), 2)) < c.Radius)
            {
                return true;
            }
            return false;
        }
        public static bool RectangularRectangularCol(RectangularPrism r1, RectangularPrism r2)
        {
            if (r1.X < r2.X + r2.Width && r1.X + r1.Width > r2.X && r1.Y < r2.Y + r2.Height && r1.Y + r1.Height > r2.Y && r1.Z < r2.Z + r2.Depth && r1.Z + r1.Depth > r2.Z)
            {
                return true;
            }
            return false;
        }
        public static bool RectangularSurfaceCol(RectangularPrism r, Surface s)
        {
            if (r.X < s.X + s.Width && r.X + r.Width > s.X && r.Y < s.Y + s.Height && r.Y + r.Height > s.Y && r.Z < s.Z && r.Z + r.Depth > s.Z)
            {
                return true;
            }
            return false;
        }
        public static bool SurfaceSphereCol(Surface s, Sphere sp)
        {
            if (Math.Sqrt(Math.Pow(sp.X - Math.Max(s.X, Math.Min(sp.X, s.X + s.Width)), 2) + Math.Pow(sp.Y - Math.Max(s.Y, Math.Min(sp.Y, s.Y + s.Height)), 2) + Math.Pow(sp.Z - s.Z, 2)) < (double)sp.Radius)
            {
                return true;
            }
            return false;
        }
        public static bool SurfaceCylinderCol(Surface s, Cylinder c)
        {
            if (Math.Sqrt(Math.Pow(c.X - Math.Max(s.X, Math.Min(c.X, s.X + s.Width)), 2) + Math.Pow(c.Y - Math.Max(s.Y, Math.Min(c.Y, s.Y + s.Height)), 2) + Math.Pow(c.Z - s.Z, 2)) < (double)c.Radius && c.Z < s.Z + s.Height)
            {
                return true;
            }
            return false;
        }
        public static bool RectangularSphereCol(RectangularPrism r, Sphere s)
        {
            if (Math.Sqrt(Math.Pow(s.X - Math.Max(r.X, Math.Min(s.X, r.X + r.Width)), 2) + Math.Pow(s.Y - Math.Max(r.Y, Math.Min(s.Y, r.Y + r.Height)), 2) + Math.Pow(s.Z - Math.Max(r.Z, Math.Min(s.Z, r.Z + r.Depth)), 2)) < (double)s.Radius)
            {
                return true;
            }
            return false;
        }
        public static bool SphereSphereCol(Sphere s1, Sphere s2)
        {
            if (Math.Sqrt(Math.Pow(s1.X - s2.X, 2) + Math.Pow(s1.Y - s2.Y, 2) + Math.Pow(s1.Z - s2.Z, 2)) < s1.Radius + s2.Radius)
            {
                return true;
            }
            return false;
        }
        public static bool CircleCircleCol(Circle c1, Circle c2)
        {
            if (Math.Sqrt(Math.Pow(c1.X - c2.X, 2) + Math.Pow(c1.Y - c2.Y, 2)) < c1.Radius + c2.Radius)
            {
                return true;
            }
            return false;
        }
        public static bool SphereCylinderCol(Sphere s, Cylinder c)
        {
            if (Math.Sqrt(Math.Pow(c.X - s.X, 2) + Math.Pow(c.Y - s.Y, 2) + Math.Pow(c.Z - s.Z, 2)) < s.Radius + c.Radius && s.Z < c.Height)
            {
                return true;
            }
            return false;
        }
        public static bool CylinderCylinderCol(Cylinder c1, Cylinder c2)
        {
            if (Math.Sqrt(Math.Pow(c1.X - c2.X, 2) + Math.Pow(c1.Y - c2.Y, 2) + Math.Pow(c1.Z - c2.Z, 2)) < c1.Radius + c2.Radius && c1.Height < c2.Height)
            {
                return true;
            }
            return false;
        }
        public static List<Point> GetPoints()
        {
            return points;
        }
        // Collision method for point and circle
        public static bool PointCircleCol(Point p, Circle c)
        {
            if (Math.Sqrt(Math.Pow(p.X - c.X, 2) + Math.Pow(p.Y - c.Y, 2)) < c.Radius)
            {
                return true;
            }
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}