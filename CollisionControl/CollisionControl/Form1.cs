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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using ODEVLIB;

namespace CollisionControl
{
    public partial class Form1 : Form
    {
        private List<object> shapes = new List<object>();

        public class DoubleBufferedPanel : Panel
        {
            public DoubleBufferedPanel()
            {
                this.DoubleBuffered = true;
            }
        }
        public Form1()
        {
            InitializeComponent();
            this.Text = "Collision Control";
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer1.Interval = 100; 
            timer1.Tick += Timer_Tick; 
            timer1.Start();
            
            // Codes for double buffering to prevent flickering
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);

            DoubleBufferedPanel doubleBufferedPanel = new DoubleBufferedPanel
            {
            
                Location = panel.Location,
                Size = panel.Size,
                Anchor = panel.Anchor,
                BackColor = panel.BackColor
            };


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Start button click event
        private void startBt_Click(object sender, EventArgs e)
        {

            shapes.Clear();
            ShapeDialog shapeDialog1 = new ShapeDialog("Select Object 1");
            if (shapeDialog1.ShowDialog() == DialogResult.OK)
            {
                object shape1 = shapeDialog1.SelectedShape;
                shapes.Add(shape1);


                ShapeDialog shapeDialog2 = new ShapeDialog("Select Object 2", ShapeDialog.shapeCollisions[shapeDialog1.GetSelectedShape()]);
                if (shapeDialog2.ShowDialog() == DialogResult.OK)
                {
                    object shape2 = shapeDialog2.SelectedShape;
                    shapes.Add(shape2);
                    bool doShapesCollide = false;
                    // Shape 1 as point.
                    if (shape1 is ODEVLIB.Collisions.Point point1)
                    {
                        if (shape2 is ODEVLIB.Collisions.Quadrilateral quadrilateral2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.PointQuadCol(point1, quadrilateral2);
                        }
                        else if (shape2 is ODEVLIB.Collisions.Circle circle2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.PointCircleCol(point1, circle2);
                        }
                        else if (shape2 is ODEVLIB.Collisions.Cylinder cylinder2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.PointCylinderCol(point1, cylinder2);
                        }
                        else if (shape2 is ODEVLIB.Collisions.RectangularPrism recPrism2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.PointRectangularCol(point1, recPrism2);
                        }
                        else if (shape2 is ODEVLIB.Collisions.Sphere sphere2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.PointSphereCol(point1, sphere2);
                        }
                    }
                    // Shape 1 as quadrilateral.
                    else if (shape1 is ODEVLIB.Collisions.Quadrilateral quadrilateral1)
                    {
                        if (shape2 is ODEVLIB.Collisions.Point point2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.PointQuadCol(point2, quadrilateral1);
                        }
                        else if (shape2 is ODEVLIB.Collisions.Circle circle2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.QuadCircleCol(quadrilateral1, circle2);
                        }
                        else if (shape2 is ODEVLIB.Collisions.Quadrilateral quadrilateral2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.QuadQuadCol(quadrilateral1, quadrilateral2);
                        }

                    }
                    // Shape 1 as Cylinder.
                    else if (shape1 is ODEVLIB.Collisions.Cylinder cylinder1)
                    {
                        if (shape2 is ODEVLIB.Collisions.Point point2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.PointCylinderCol(point2, cylinder1);
                        }
                        else if (shape2 is ODEVLIB.Collisions.Sphere sphere2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.SphereCylinderCol(sphere2, cylinder1);
                        }
                        else if (shape2 is ODEVLIB.Collisions.Cylinder cylinder2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.CylinderCylinderCol(cylinder1, cylinder2);
                        }
                        else if (shape2 is ODEVLIB.Collisions.Surface surface2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.SurfaceCylinderCol(surface2, cylinder1);
                        }
                    }
                    // Shape 1 as Surface.
                    else if (shape1 is ODEVLIB.Collisions.Surface surface1)
                    {
                        if (shape2 is ODEVLIB.Collisions.Cylinder cylinder2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.SurfaceCylinderCol(surface1, cylinder2);
                        }
                        else if (shape2 is ODEVLIB.Collisions.RectangularPrism recPrism2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.RectangularSurfaceCol(recPrism2, surface1);
                        }
                        else if (shape2 is ODEVLIB.Collisions.Sphere sphere2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.SurfaceSphereCol(surface1, sphere2);
                        }
                    }
                    // Shape 1 as Sphere.
                    else if (shape1 is ODEVLIB.Collisions.Sphere sphere1)
                    {
                        if (shape2 is ODEVLIB.Collisions.Sphere sphere2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.SphereSphereCol(sphere1, sphere2);
                        }
                        else if (shape2 is ODEVLIB.Collisions.Point point2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.PointSphereCol(point2, sphere1);
                        }
                        else if (shape2 is ODEVLIB.Collisions.Cylinder cylinder2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.SphereCylinderCol(sphere1, cylinder2);
                        }
                        else if (shape2 is ODEVLIB.Collisions.RectangularPrism recPrism2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.RectangularSphereCol(recPrism2, sphere1);
                        }
                        else if (shape2 is ODEVLIB.Collisions.Surface surface2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.SurfaceSphereCol(surface2, sphere1);
                        }
                    }
                    // Shape 1 as Circle.
                    else if (shape1 is ODEVLIB.Collisions.Circle circle1)
                    {
                        if (shape2 is ODEVLIB.Collisions.Point point2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.PointCircleCol(point2, circle1);
                        }
                        else if (shape2 is ODEVLIB.Collisions.Quadrilateral quadrilateral2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.QuadCircleCol(quadrilateral2, circle1);
                        }
                        else if (shape2 is ODEVLIB.Collisions.Circle circle2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.CircleCircleCol(circle1, circle2);
                        }
                    }
                    // Shape 1 as RectangularPrism.
                    else if (shape1 is ODEVLIB.Collisions.RectangularPrism recPrism1)
                    {
                        if (shape2 is ODEVLIB.Collisions.Point point2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.PointRectangularCol(point2, recPrism1);
                        }
                        else if (shape2 is ODEVLIB.Collisions.Sphere sphere2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.RectangularSphereCol(recPrism1, sphere2);
                        }
                        else if (shape2 is ODEVLIB.Collisions.RectangularPrism recPrism2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.RectangularRectangularCol(recPrism1, recPrism2);
                        }
                        else if (shape2 is ODEVLIB.Collisions.Surface surface2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.RectangularSurfaceCol(recPrism1, surface2);
                        }
                    }
                    panel.Invalidate();
                }

            }

        }

        // Panel paint event
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(panel.BackColor);

            // Scaling to make the shapes more visible
            int scaleFactor = 10; 

            // Quadrilateral Drawing
            foreach (var shape in shapes)
            {
                if (shape is ODEVLIB.Collisions.Quadrilateral quadrilateral)
                {
                    // Create a linear gradient brush
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        new Rectangle(quadrilateral.X * scaleFactor, quadrilateral.Y * scaleFactor, quadrilateral.Width * scaleFactor, quadrilateral.Height * scaleFactor),
                        Color.LightBlue, // Start color
                        Color.DarkBlue, // End color
                        LinearGradientMode.ForwardDiagonal)) // Gradient direction
                    {
                        // Use the brush to fill the rectangle
                        e.Graphics.FillRectangle(brush, quadrilateral.X * scaleFactor, quadrilateral.Y * scaleFactor, quadrilateral.Width * scaleFactor, quadrilateral.Height * scaleFactor);
                    }
                }
            }

            // Point Drawing
            foreach (var shape in shapes)
            {
                if (shape is ODEVLIB.Collisions.Point point)
                {
                    e.Graphics.FillEllipse(Brushes.Black, point.X * scaleFactor, point.Y * scaleFactor, 2 * scaleFactor, 2 * scaleFactor);
                }
            }

            // Circle Drawing
            foreach (var shape in shapes)
            {
                if (shape is ODEVLIB.Collisions.Circle circle)
                {
                    // Create a radial gradient brush
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        path.AddEllipse((circle.X - circle.Radius) * scaleFactor, (circle.Y - circle.Radius) * scaleFactor, circle.Radius * 2 * scaleFactor, circle.Radius * 2 * scaleFactor);
                        using (PathGradientBrush brush = new PathGradientBrush(path))
                        {
                            // Set the properties of the brush
                            brush.CenterColor = Color.Red;
                            brush.SurroundColors = new[] { Color.DarkRed };
                            brush.CenterPoint = new PointF(circle.X * scaleFactor + circle.Radius * scaleFactor / 2, circle.Y * scaleFactor + circle.Radius * scaleFactor / 2);

                            // Use the brush to fill the ellipse
                            e.Graphics.FillEllipse(brush,
                                (circle.X - circle.Radius) * scaleFactor,
                                (circle.Y - circle.Radius) * scaleFactor,
                                circle.Radius * 2 * scaleFactor,
                                circle.Radius * 2 * scaleFactor);
                        }
                    }
                }
            }

            // Cylinder Drawing
            foreach (var shape in shapes)
            {
                if (shape is ODEVLIB.Collisions.Cylinder cylinder)
                {
                    // Create a linear gradient brush
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        new Point(cylinder.X * scaleFactor, cylinder.Y * scaleFactor),
                        new Point(cylinder.X * scaleFactor + cylinder.Radius * scaleFactor, cylinder.Y * scaleFactor + cylinder.Height * scaleFactor),
                        Color.Green,
                        Color.LightGreen))
                    {
                        // Draw the top ellipse
                        e.Graphics.FillEllipse(brush,
                            (cylinder.X - cylinder.Radius) * scaleFactor,
                            (cylinder.Y - cylinder.Radius) * scaleFactor,
                            cylinder.Radius * 2 * scaleFactor,
                            cylinder.Radius * scaleFactor);

                        // Draw the bottom ellipse
                        e.Graphics.FillEllipse(brush,
                            (cylinder.X - cylinder.Radius) * scaleFactor,
                            (cylinder.Y + cylinder.Height - cylinder.Radius) * scaleFactor,
                            cylinder.Radius * 2 * scaleFactor,
                            cylinder.Radius * scaleFactor);

                        // Draw the two lines connecting the ellipses
                        e.Graphics.DrawLine(Pens.Green,
                            (cylinder.X - cylinder.Radius) * scaleFactor,
                            (cylinder.Y - cylinder.Radius) * scaleFactor + cylinder.Radius * scaleFactor / 2, // Adjusted Y-coordinate
                            (cylinder.X - cylinder.Radius) * scaleFactor,
                            (cylinder.Y + cylinder.Height - cylinder.Radius) * scaleFactor + cylinder.Radius * scaleFactor / 2); // Adjusted Y-coordinate

                        e.Graphics.DrawLine(Pens.Green,
                            (cylinder.X + cylinder.Radius) * scaleFactor,
                            (cylinder.Y - cylinder.Radius) * scaleFactor + cylinder.Radius * scaleFactor / 2, // Adjusted Y-coordinate
                            (cylinder.X + cylinder.Radius) * scaleFactor,
                            (cylinder.Y + cylinder.Height - cylinder.Radius) * scaleFactor + cylinder.Radius * scaleFactor / 2); // Adjusted Y-coordinate
                    }
                }
            }

            // Sphere Drawing
            foreach (var shape in shapes)
            {
                if (shape is ODEVLIB.Collisions.Sphere sphere)
                {
                    // Create a radial gradient brush
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        path.AddEllipse((sphere.X - sphere.Radius) * scaleFactor, (sphere.Y - sphere.Radius) * scaleFactor, sphere.Radius * 2 * scaleFactor, sphere.Radius * 2 * scaleFactor); using (PathGradientBrush brush = new PathGradientBrush(path))
                        {
                            // Set the properties of the brush
                            brush.CenterColor = Color.Yellow;
                            brush.SurroundColors = new[] { Color.Orange };
                            brush.CenterPoint = new PointF(sphere.X * scaleFactor + sphere.Radius * scaleFactor / 2, sphere.Y * scaleFactor + sphere.Radius * scaleFactor / 2);

                            // Use the brush to fill the ellipse
                            e.Graphics.FillEllipse(brush,
                                (sphere.X - sphere.Radius) * scaleFactor,
                                (sphere.Y - sphere.Radius) * scaleFactor,
                                sphere.Radius * 2 * scaleFactor,
                                sphere.Radius * 2 * scaleFactor);
                        }
                    }
                }
            }

            // Rectangular Prism Drawing
            foreach (var shape in shapes)
            {
                if (shape is ODEVLIB.Collisions.RectangularPrism recPrism)
                {
                    // Draw the front face
                    e.Graphics.FillRectangle(Brushes.Purple, recPrism.X * scaleFactor, recPrism.Y * scaleFactor, recPrism.Width * scaleFactor, recPrism.Height * scaleFactor);

                    int depthOffset = (int)(recPrism.Depth * scaleFactor * 0.5); 

                    // Draw the top face
                    Point[] topFace = new Point[]
                    {
            new Point(recPrism.X * scaleFactor, recPrism.Y * scaleFactor),
            new Point(recPrism.X * scaleFactor + depthOffset, recPrism.Y * scaleFactor - depthOffset),
            new Point(recPrism.X * scaleFactor + recPrism.Width * scaleFactor + depthOffset, recPrism.Y * scaleFactor - depthOffset),
            new Point(recPrism.X * scaleFactor + recPrism.Width * scaleFactor, recPrism.Y * scaleFactor)
                    };

                    e.Graphics.FillPolygon(Brushes.LightPink, topFace); 

                    // Draw the right face
                    Point[] rightFace = new Point[]
                    {
            new Point(recPrism.X * scaleFactor + recPrism.Width * scaleFactor, recPrism.Y * scaleFactor),
            new Point(recPrism.X * scaleFactor + recPrism.Width * scaleFactor + depthOffset, recPrism.Y * scaleFactor - depthOffset),
            new Point(recPrism.X * scaleFactor + recPrism.Width * scaleFactor + depthOffset, recPrism.Y * scaleFactor + recPrism.Height * scaleFactor - depthOffset),
            new Point(recPrism.X * scaleFactor + recPrism.Width * scaleFactor, recPrism.Y * scaleFactor + recPrism.Height * scaleFactor)
                    };
                    e.Graphics.FillPolygon(Brushes.Purple, rightFace); 
                }
            }

            // Surface Drawing
            foreach (var shape in shapes)
            {
                if (shape is ODEVLIB.Collisions.Surface surface)
                {
                    // Create a linear gradient brush with two colors
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        new Rectangle(surface.X * scaleFactor, surface.Y * scaleFactor, surface.Width * scaleFactor, surface.Height * scaleFactor),
                        Color.Orange, // Start color
                        Color.DarkOrange, // End color
                        LinearGradientMode.BackwardDiagonal)) // Gradient direction
                    {
                        // Define the offset for the "depth" of the 3D effect
                        int depth = 20; // Adjust this value to change the 3D effect

                        // Define the points of the parallelogram
                        Point[] parallelogram = new Point[]
                        {
                new Point((surface.X + depth) * scaleFactor, surface.Y * scaleFactor),
                new Point((surface.X + surface.Width + depth) * scaleFactor, surface.Y * scaleFactor),
                new Point((surface.X + surface.Width) * scaleFactor, (surface.Y + surface.Height) * scaleFactor),
                new Point(surface.X * scaleFactor, (surface.Y + surface.Height) * scaleFactor)
                        };

                        // Use the brush to fill the parallelogram
                        e.Graphics.FillPolygon(brush, parallelogram);
                    }
                }
            }

        }

        private bool isInside = false;
        private int velocityX = 1;
        private int velocityY = 1;
        private Random random = new Random();
        private bool collisionDetected = false;

        // Move and detect collision for the Quadrilateral
        private void MoveAndDetectCollision(ODEVLIB.Collisions.Quadrilateral movingQuadrilateral)
        {
            int scaleFactor = 10; // Adjust this value to change the scale of the drawing
            ODEVLIB.Collisions.Point point = shapes.OfType<ODEVLIB.Collisions.Point>().FirstOrDefault();
            if (point != null)
            {
                // If a point exists, return immediately without moving the quadrilateral
                return;
            }
            // Check for collisions with the panel's borders
            if (movingQuadrilateral.X + velocityX <= 0 || (movingQuadrilateral.X + movingQuadrilateral.Width + velocityX) * scaleFactor >= panel.ClientSize.Width)
            {
                velocityX = -velocityX;
            }
            if (movingQuadrilateral.Y + velocityY <= 0 || (movingQuadrilateral.Y + movingQuadrilateral.Height + velocityY) * scaleFactor >= panel.ClientSize.Height)
            {
                velocityY = -velocityY;
            }

            // Update the position of the quadrilateral
            movingQuadrilateral.X += velocityX;
            movingQuadrilateral.Y += velocityY;

            // Reset the collision label at the start of each check
            collisionLabel.Text = "";

            // Check for collisions with the other quadrilateral
            ODEVLIB.Collisions.Quadrilateral otherQuadrilateral = shapes.OfType<ODEVLIB.Collisions.Quadrilateral>().Skip(1).FirstOrDefault();
            if (otherQuadrilateral != null)
            {
                bool doShapesCollide = ODEVLIB.Collisions.QuadQuadCol(movingQuadrilateral, otherQuadrilateral);
                if (doShapesCollide)
                {
                    collisionLabel.Text = "Collision Detected with the other quadrilateral!";
                    velocityX = -velocityX;
                    velocityY = -velocityY;
                }
            }
            ODEVLIB.Collisions.Circle circle = shapes.OfType<ODEVLIB.Collisions.Circle>().FirstOrDefault();
            if (circle != null)
            {
                bool doShapesCollide = ODEVLIB.Collisions.QuadCircleCol(movingQuadrilateral, circle);
                if (doShapesCollide)
                {
                    collisionLabel.Text = "Collision Detected with the circle!";
                    velocityX = -velocityX;
                    velocityY = -velocityY;
                }
            }

            // Redraw the panel to show the updated position of the quadrilateral
            panel.Invalidate();
        }

        // Move and detect collision for the Circle
        private void MoveAndDetectCollision(ODEVLIB.Collisions.Circle movingCircle)
        {
            int scaleFactor = 10; // Adjust this value to change the scale of the drawing
            ODEVLIB.Collisions.Point point = shapes.OfType<ODEVLIB.Collisions.Point>().FirstOrDefault();
            ODEVLIB.Collisions.Quadrilateral quadrilateral = shapes.OfType<ODEVLIB.Collisions.Quadrilateral>().FirstOrDefault();
            if (point != null || quadrilateral != null)
            {
                // If a point or a quadrilateral exists, return immediately without moving the circle
                return;
            }
            if (quadrilateral != null)
            {
                bool doShapesCollide = ODEVLIB.Collisions.QuadCircleCol(quadrilateral, movingCircle);
                if (doShapesCollide)
                {
                    collisionLabel.Text = "Collision Detected with the quadrilateral!";

                    return;
                }
            }
            // Check for collisions with the panel's borders
            if (movingCircle.X + velocityX <= 0 || (movingCircle.X + movingCircle.Radius + velocityX) * scaleFactor >= panel.ClientSize.Width)
            {
                velocityX = -velocityX;
            }
            if (movingCircle.Y + velocityY <= 0 || (movingCircle.Y + movingCircle.Radius + velocityY) * scaleFactor >= panel.ClientSize.Height)
            {
                velocityY = -velocityY;
            }

            // Update the position of the circle
            movingCircle.X += velocityX;
            movingCircle.Y += velocityY;

            // Reset the collision label at the start of each check
            collisionLabel.Text = "";

            // Check for collisions with the other circle
            ODEVLIB.Collisions.Circle otherCircle = shapes.OfType<ODEVLIB.Collisions.Circle>().Skip(1).FirstOrDefault();
            if (otherCircle != null)
            {
                bool doShapesCollide = ODEVLIB.Collisions.CircleCircleCol(movingCircle, otherCircle);
                if (doShapesCollide)
                {
                    collisionLabel.Text = "Collision Detected with the other circle!";
                    velocityX = -velocityX;
                    velocityY = -velocityY;
                }
            }
            if (quadrilateral != null)
            {
                bool doShapesCollide = ODEVLIB.Collisions.QuadCircleCol(quadrilateral, movingCircle);
                if (doShapesCollide)
                {
                    collisionLabel.Text = "Collision Detected with the quadrilateral!";
                }
            }

            // Redraw the panel to show the updated position of the circle
            panel.Invalidate();
        }

        // Move and detect collision for the Cylinder
        private void MoveAndDetectCollision(ODEVLIB.Collisions.Cylinder movingCylinder)
        {
            ODEVLIB.Collisions.Point point = shapes.OfType<ODEVLIB.Collisions.Point>().FirstOrDefault();
            ODEVLIB.Collisions.Sphere sphere = shapes.OfType<ODEVLIB.Collisions.Sphere>().FirstOrDefault();
            ODEVLIB.Collisions.Surface surface = shapes.OfType<ODEVLIB.Collisions.Surface>().FirstOrDefault();
            ODEVLIB.Collisions.Cylinder otherCylinder = shapes.OfType<ODEVLIB.Collisions.Cylinder>().Skip(1).FirstOrDefault();

            if (point != null || sphere != null )
            {
                return;
            }

            // Check for collisions with the panel's borders
            if (movingCylinder.X + velocityX <= 0 || (movingCylinder.X + movingCylinder.Radius + velocityX) * 10 >= panel.ClientSize.Width)
            {
                velocityX = -velocityX;
            }
            if (movingCylinder.Y + velocityY <= 0 || (movingCylinder.Y + movingCylinder.Height + velocityY) * 10 >= panel.ClientSize.Height)
            {
                velocityY = -velocityY;
            }

            collisionLabel.Text = "";

            if (otherCylinder != null)
            {
                bool doShapesCollide = ODEVLIB.Collisions.CylinderCylinderCol(movingCylinder, otherCylinder);
                if (doShapesCollide)
                {
                    collisionLabel.Text = "Collision Detected with the cylinder!";
                    velocityX = -velocityX;
                    velocityY = -velocityY;
                    return;

                }
            }
            if ( surface != null)
            {
                bool doShapesCollide = ODEVLIB.Collisions.SurfaceCylinderCol(surface, movingCylinder);
                if (doShapesCollide)
                {
                    collisionLabel.Text = "Collision Detected with the surface!";
                    velocityX = -velocityX;
                    velocityY = -velocityY;

                    return;
                }
            }
            movingCylinder.X += velocityX;
            movingCylinder.Y += velocityY;


            panel.Invalidate();
        }

        // Move and detect collision for the Sphere
        private void MoveAndDetectCollision(ODEVLIB.Collisions.Sphere movingSphere)
        {
            ODEVLIB.Collisions.Sphere otherSphere = shapes.OfType<ODEVLIB.Collisions.Sphere>().Skip(1).FirstOrDefault();
            ODEVLIB.Collisions.Point point = shapes.OfType<ODEVLIB.Collisions.Point>().FirstOrDefault();
            ODEVLIB.Collisions.Cylinder cylinder = shapes.OfType<ODEVLIB.Collisions.Cylinder>().FirstOrDefault();
            ODEVLIB.Collisions.RectangularPrism recPrism = shapes.OfType<ODEVLIB.Collisions.RectangularPrism>().FirstOrDefault();
            ODEVLIB.Collisions.Surface surface = shapes.OfType<ODEVLIB.Collisions.Surface>().FirstOrDefault();

            if (point != null )
            {
                return;
            }
            collisionLabel.Text = "";


            // Check for collisions with the panel's borders
            if (movingSphere.X + velocityX <= 0 || (movingSphere.X + movingSphere.Radius + velocityX) * 10 >= panel.ClientSize.Width)
            {
                velocityX = -velocityX;
            }
            if (movingSphere.Y + velocityY <= 0 || (movingSphere.Y + movingSphere.Radius + velocityY) * 10 >= panel.ClientSize.Height)
            {
                velocityY = -velocityY;
            }
            movingSphere.X += velocityX;
            movingSphere.Y += velocityY;



            if (cylinder != null)
            {
                double distance = Math.Sqrt(Math.Pow(cylinder.X - movingSphere.X, 2) + Math.Pow(cylinder.Y - movingSphere.Y, 2));
                if (distance < cylinder.Radius + movingSphere.Radius)
                {
                    bool doShapesCollide = ODEVLIB.Collisions.SphereCylinderCol(movingSphere, cylinder);
                    if (doShapesCollide)
                    {
                        collisionLabel.Text = "Collision Detected with the cylinder!";
                        velocityX = -velocityX;
                        velocityY = -velocityY;
                        return;
                    }
                }
            }
            if (recPrism != null)
            {
                bool doShapesCollide = ODEVLIB.Collisions.RectangularSphereCol(recPrism, movingSphere);
                if (doShapesCollide)
                {
                    collisionLabel.Text = "Collision Detected with the rectangular prism!";
                    return;
                }
            }
            if (surface != null)
            {
                bool doShapesCollide = ODEVLIB.Collisions.SurfaceSphereCol(surface, movingSphere);
                if (doShapesCollide)
                {
                    collisionLabel.Text = "Collision Detected with the surface!";
                    return;
                }
            }
            if (otherSphere != null)
            {
                bool doShapesCollide = ODEVLIB.Collisions.SphereSphereCol(movingSphere, otherSphere);
                if (doShapesCollide)
                {
                    collisionLabel.Text = "Collision Detected with the other sphere!";
                    return;
                }
            }
             
            panel.Invalidate();
            
        }

        // Move and detect collision for the Rectangular Prism
        private void MoveAndDetectCollision(ODEVLIB.Collisions.RectangularPrism rectangularPrism)
        {
            ODEVLIB.Collisions.Point point = shapes.OfType<ODEVLIB.Collisions.Point>().FirstOrDefault();
            ODEVLIB.Collisions.Sphere sphere = shapes.OfType<ODEVLIB.Collisions.Sphere>().FirstOrDefault();
            ODEVLIB.Collisions.Surface surface = shapes.OfType<ODEVLIB.Collisions.Surface>().FirstOrDefault();
            ODEVLIB.Collisions.RectangularPrism otherRectangularPrism = shapes.OfType<ODEVLIB.Collisions.RectangularPrism>().Skip(1).FirstOrDefault();

            if (point != null || sphere != null)
            {
                return;
            }

            if (rectangularPrism.X + velocityX <= 0 || (rectangularPrism.X + rectangularPrism.Width + velocityX) * 10 >= panel.ClientSize.Width)
            {
                velocityX = -velocityX;
            }

            if (rectangularPrism.Y + velocityY <= 0 || (rectangularPrism.Y + rectangularPrism.Height + velocityY) * 10 >= panel.ClientSize.Height)
            {
                velocityY = -velocityY;
            }
            rectangularPrism.X += velocityX;
            rectangularPrism.Y += velocityY;


            collisionLabel.Text = "";

            if (otherRectangularPrism != null)
            {
                bool doShapesCollide = ODEVLIB.Collisions.RectangularRectangularCol(rectangularPrism, otherRectangularPrism);
                if (doShapesCollide)
                {
                    collisionLabel.Text = "Collision Detected with the other rectangular prism!";
                    velocityX = -velocityX;
                    velocityY = -velocityY;
                    return;
                }
            }
            if (surface != null)
            {
                bool doShapesCollide = ODEVLIB.Collisions.RectangularSurfaceCol(rectangularPrism, surface);
                if (doShapesCollide)
                {
                    collisionLabel.Text = "Collision Detected with the surface!";
                    velocityX = -velocityX;
                    velocityY = -velocityY;
                    return;
                }
            }
            panel.Invalidate();

        }

        // Move and detect collision for the Point and the Timer event
        private void Timer_Tick(object sender, EventArgs e)
        {
            ODEVLIB.Collisions.Point point = shapes.OfType<ODEVLIB.Collisions.Point>().FirstOrDefault();
            ODEVLIB.Collisions.Quadrilateral movingQuadrilateral = shapes.OfType<ODEVLIB.Collisions.Quadrilateral>().FirstOrDefault();

            if (movingQuadrilateral != null)
            {
                MoveAndDetectCollision(movingQuadrilateral);
            }
            
            ODEVLIB.Collisions.Circle movingCircle = shapes.OfType<ODEVLIB.Collisions.Circle>().FirstOrDefault();
            if (movingCircle != null)
            {
                MoveAndDetectCollision(movingCircle);
            }
            ODEVLIB.Collisions.Cylinder movingCylinder = shapes.OfType<ODEVLIB.Collisions.Cylinder>().FirstOrDefault();
            if (movingCylinder != null)
            {
                MoveAndDetectCollision(movingCylinder);
            }
            ODEVLIB.Collisions.Sphere movingSphere = shapes.OfType<ODEVLIB.Collisions.Sphere>().FirstOrDefault();
            if (movingSphere != null)
            {
                MoveAndDetectCollision(movingSphere);
            }
            ODEVLIB.Collisions.RectangularPrism movingRectangularPrism = shapes.OfType<ODEVLIB.Collisions.RectangularPrism>().FirstOrDefault();
            if (movingRectangularPrism != null)
            {
                MoveAndDetectCollision(movingRectangularPrism);
            }


            int scaleFactor = 10; 

            if (point != null)
            {
                if (point.X * scaleFactor + velocityX <= 0 || point.X * scaleFactor + velocityX >= panel.ClientSize.Width)
                {
                    velocityX = -velocityX;
                }
                if (point.Y * scaleFactor + velocityY <= 0 || point.Y * scaleFactor + velocityY >= panel.ClientSize.Height)
                {
                    velocityY = -velocityY;
                }
                point.X += velocityX;
                point.Y += velocityY;

                collisionLabel.Text = "";

                // Check for collisions with the quadrilateral
                ODEVLIB.Collisions.Quadrilateral quadrilateral = shapes.OfType<ODEVLIB.Collisions.Quadrilateral>().FirstOrDefault();
                if (quadrilateral != null)
                {
                    bool doShapesCollide = ODEVLIB.Collisions.PointQuadCol(point, quadrilateral);
                    if (doShapesCollide)
                    {
                        collisionLabel.Text = "Collision Detected with the quadrilateral!";
                        velocityX = -velocityX;
                        velocityY = -velocityY;
                    }
                }

                // Check for collisions with the cylinder
                ODEVLIB.Collisions.Cylinder cylinder = shapes.OfType<ODEVLIB.Collisions.Cylinder>().FirstOrDefault();
                if (cylinder != null)
                {
                    bool doShapesCollide = ODEVLIB.Collisions.PointCylinderCol(point, cylinder);
                    if (doShapesCollide)
                    {
                        collisionLabel.Text = "Collision Detected with the cylinder!";
                        velocityX = -velocityX;
                        velocityY = -velocityY;
                    }
                }

                // Check for collisions with the circle
                ODEVLIB.Collisions.Circle circle = shapes.OfType<ODEVLIB.Collisions.Circle>().FirstOrDefault();
                if (circle != null)
                {
                    bool doShapesCollide = ODEVLIB.Collisions.PointCircleCol(point, circle);
                    if (doShapesCollide)
                    {
                        collisionLabel.Text = "Collision Detected with the circle!";
                        velocityX = -velocityX;
                        velocityY = -velocityY;
                    }
                }

                // Check for collisions with the sphere
                ODEVLIB.Collisions.Sphere sphere = shapes.OfType<ODEVLIB.Collisions.Sphere>().FirstOrDefault();
                if (sphere != null)
                {
                    bool doShapesCollide = ODEVLIB.Collisions.PointSphereCol(point, sphere);
                    if (doShapesCollide)
                    {
                        collisionLabel.Text = "Collision Detected with the sphere!";
                        velocityX = -velocityX;
                        velocityY = -velocityY;
                    }
                }

                // Check for collisions with the rectangular prism
                ODEVLIB.Collisions.RectangularPrism recPrism = shapes.OfType<ODEVLIB.Collisions.RectangularPrism>().FirstOrDefault();
                if (recPrism != null)
                {
                    bool doShapesCollide = ODEVLIB.Collisions.PointRectangularCol(point, recPrism);
                    if (doShapesCollide)
                    {
                        collisionLabel.Text = "Collision Detected with the rectangular prism!";
                        velocityX = -velocityX;
                        velocityY = -velocityY;
                    }
                }
              

                panel.Invalidate();
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
