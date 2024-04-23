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
using System.Text;
using System.Windows.Forms;
using ODEVLIB;

namespace CollisionControl
{
    public partial class Form1 : Form
    {
        private List<object> shapes = new List<object>();
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startBt_Click(object sender, EventArgs e)
        {
            // Create the first ShapeDialog.
            ShapeDialog shapeDialog1 = new ShapeDialog();
            if (shapeDialog1.ShowDialog() == DialogResult.OK)
            {
                object shape1 = shapeDialog1.SelectedShape;
                shapes.Add(shape1);

                // Create the second ShapeDialog.
                ShapeDialog shapeDialog2 = new ShapeDialog();
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
                            doShapesCollide = ODEVLIB.Collisions.SurfaceCylinderCol( surface2, cylinder1);
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
                            doShapesCollide = ODEVLIB.Collisions.RectangularSurfaceCol( recPrism2, surface1);
                        }
                        else if (shape2 is ODEVLIB.Collisions.Sphere sphere2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.SurfaceSphereCol( surface1, sphere2);
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
                            doShapesCollide = ODEVLIB.Collisions.RectangularSphereCol( recPrism2, sphere1);
                        }
                        else if (shape2 is ODEVLIB.Collisions.Surface surface2)
                        {
                            doShapesCollide = ODEVLIB.Collisions.SurfaceSphereCol( surface2, sphere1);
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
                            doShapesCollide = ODEVLIB.Collisions.RectangularSurfaceCol( recPrism1, surface2);
                        }
                    }   
                    // Add more else if blocks for the other shape types...

                    if (doShapesCollide)
                    {
                        MessageBox.Show("The shapes collide!");
                    }
                    else
                    {
                        MessageBox.Show("The shapes do not collide.");
                    }
                }
            }

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
