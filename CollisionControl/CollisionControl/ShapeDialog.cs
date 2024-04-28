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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ODEVLIB;

namespace CollisionControl
{
    public partial class ShapeDialog : Form
    {
        public string GetSelectedShape()
        {
            return shapeComboBox.SelectedItem.ToString();
        }
        public object SelectedShape { get; private set; }
        private List<TextBox> propertyTextBoxes = new List<TextBox>();
        private List<Label> propertyLabels = new List<Label>();
        public static   Dictionary<string, List<string>>  shapeCollisions = new Dictionary<string, List<string>>
{
    { "Point", new List<string> { "Quadrilateral", "Circle", "Cylinder", "Sphere", "RectangularPrism" } },
    { "Quadrilateral", new List<string> { "Circle", "Quadrilateral" , "Point" } },
    { "Circle", new List<string> { "Point", "Quadrilateral", "Circle" } },
    { "Cylinder", new List<string> { "Point", "Sphere", "Surface", "Cylinder" } },
    { "Surface", new List<string> { "Cylinder", "Sphere", "RectangularPrism" } },
    { "Sphere", new List<string> { "Point", "Cylinder", "Surface", "Sphere", "RectangularPrism" } },
    { "RectangularPrism", new List<string> { "Point", "Surface", "Sphere", "RectangularPrism" } }
};
        public ShapeDialog(string title , List<string> shapes = null)
        {
            InitializeComponent();
            this.Text = title;
            this.Text = "Select Shape";
            this.label4.Text = title;
            shapeComboBox.Items.Clear();
            if (shapes == null)
            {
                shapeComboBox.Items.Add("Point");
                shapeComboBox.Items.Add("Quadrilateral");
                shapeComboBox.Items.Add("Cylinder");
                shapeComboBox.Items.Add("Circle");
                shapeComboBox.Items.Add("RectangularPrism");
                shapeComboBox.Items.Add("Surface");
                shapeComboBox.Items.Add("Sphere");
            }
            else
            {
                foreach (string shape in shapes)
                {
                    shapeComboBox.Items.Add(shape);
                }
            }
            shapeComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            shapeComboBox.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (TextBox textBox in propertyTextBoxes)
            {
                this.Controls.Remove(textBox);
            }
            foreach (Label label in propertyLabels)
            {
                this.Controls.Remove(label);
            }
            propertyLabels.Clear();
            propertyTextBoxes.Clear();
            CreatePropertyTextBoxes();


        }
        // Create textboxes for shape properties
        private void CreatePropertyTextBoxes()
        {
            List<string> properties;
            switch (shapeComboBox.SelectedItem.ToString())
            {
                case "Point":
                    properties = new List<string> { "X", "Y", "Z" }; // Add "Z"
                    break;
                case "Quadrilateral":
                    properties = new List<string> { "X", "Y", "Width", "Height"  };
                    break;
                case "Cylinder":
                    properties = new List<string> { "Center X", "Center Y", "Radius" , "Height" };
                    break;
                case "Circle":
                    properties = new List<string> { "Center X", "Center Y", "Radius" };
                    break;
                case "RectangularPrism":
                    properties = new List<string> { "Center X", "Center Y", "Center Z", "Width", "Height", "Depth" };
                    break;
                case "Surface":
                    properties = new List<string> { "Center X", "Center Y", "Center Z", "Width", "Height" };
                    break;
                case "Sphere":
                    properties = new List<string> { "Center X", "Center Y", "Center Z", "Radius" };
                    break;

                default:
                    throw new Exception("Invalid shape type");
            }

            int row = 0;
            int column = 0;
            int controlHeight = 20;
            for (int i = 0; i < properties.Count; i++)
            {
                Label label = new Label();
                label.Text = properties[i];
                label.Top = shapeComboBox.Bottom + 10 + row * (controlHeight + 5);
                label.Left = 10 + column * 100;
                this.Controls.Add(label);
                propertyLabels.Add(label);

                TextBox textBox = new TextBox();
                textBox.Top = label.Bottom;
                textBox.Left = label.Left;
                this.Controls.Add(textBox);
                propertyTextBoxes.Add(textBox);

                column++;
                if (column > 5)
                {
                    column = 0;
                    row++;
                }
            }
        }

        // OK button event handler
        private void okBt_Click(object sender, EventArgs e)
        {
            try
            {
                switch (shapeComboBox.SelectedItem.ToString())
                {
                    case "Point":
                        if (int.TryParse(propertyTextBoxes[0].Text, out int pointX) &&
                            int.TryParse(propertyTextBoxes[1].Text, out int pointY) &&
                            int.TryParse(propertyTextBoxes[2].Text, out int pointZ)) // Add this line
                        {
                            SelectedShape = new ODEVLIB.Collisions.Point { X = pointX, Y = pointY, Z = pointZ }; // Modify this line
                        }
                        else
                        {
                            throw new Exception("Invalid input for Point properties");
                        }
                        break;
                    case "Quadrilateral":
                        if (int.TryParse(propertyTextBoxes[0].Text, out int quadX) && int.TryParse(propertyTextBoxes[1].Text, out int quadY) &&
                            int.TryParse(propertyTextBoxes[2].Text, out int quadWidth) && int.TryParse(propertyTextBoxes[3].Text, out int quadHeight))
                        {
                            SelectedShape = new ODEVLIB.Collisions.Quadrilateral { X = quadX, Y = quadY, Width = quadWidth, Height = quadHeight };
                        }
                        else
                        {
                            throw new Exception("Invalid input for Quadrilateral properties");
                        }
                        break;
                    case "Cylinder":
                        if (int.TryParse(propertyTextBoxes[0].Text, out int cylX) && int.TryParse(propertyTextBoxes[1].Text, out int cylY) &&
                            int.TryParse(propertyTextBoxes[2].Text, out int cylRadius) && int.TryParse(propertyTextBoxes[3].Text, out int cylHeight)) // Add this line
                        {
                            SelectedShape = new ODEVLIB.Collisions.Cylinder { X = cylX, Y = cylY, Radius = cylRadius, Height = cylHeight }; // Modify this line
                        }
                        else
                        {
                            throw new Exception("Invalid input for Cylinder properties");
                        }
                        break;

                    case "Circle":
                        if (int.TryParse(propertyTextBoxes[0].Text, out int circleX) && int.TryParse(propertyTextBoxes[1].Text, out int circleY) &&
                            int.TryParse(propertyTextBoxes[2].Text, out int circleRadius))
                        {
                            SelectedShape = new ODEVLIB.Collisions.Circle { X = circleX, Y = circleY, Radius = circleRadius };
                        }
                        else
                        {
                            throw new Exception("Invalid input for Circle properties");
                        }
                        break;
                    case "RectangularPrism":
                        if (int.TryParse(propertyTextBoxes[0].Text, out int rectPrismX) && int.TryParse(propertyTextBoxes[1].Text, out int rectPrismY) &&
                            int.TryParse(propertyTextBoxes[2].Text, out int rectPrismZ) && int.TryParse(propertyTextBoxes[3].Text, out int rectPrismWidth) &&
                            int.TryParse(propertyTextBoxes[4].Text, out int rectPrismHeight) && int.TryParse(propertyTextBoxes[5].Text, out int rectPrismDepth))
                        {
                            SelectedShape = new ODEVLIB.Collisions.RectangularPrism { X = rectPrismX, Y = rectPrismY, Z = rectPrismZ, Width = rectPrismWidth, Height = rectPrismHeight, Depth = rectPrismDepth };
                        }
                        else
                        {
                            throw new Exception("Invalid input for RectangularPrism properties");
                        }
                        break;
                    case "Surface":
                        if (int.TryParse(propertyTextBoxes[0].Text, out int surfaceX) && int.TryParse(propertyTextBoxes[1].Text, out int surfaceY) &&
                            int.TryParse(propertyTextBoxes[2].Text, out int surfaceZ) && int.TryParse(propertyTextBoxes[3].Text, out int surfaceWidth) &&
                            int.TryParse(propertyTextBoxes[4].Text, out int surfaceHeight))
                        {
                            SelectedShape = new ODEVLIB.Collisions.Surface { X = surfaceX, Y = surfaceY, Z = surfaceZ, Width = surfaceWidth, Height = surfaceHeight };
                        }
                        else
                        {
                            throw new Exception("Invalid input for Surface properties");
                        }
                        break;
                    case "Sphere":
                        if (int.TryParse(propertyTextBoxes[0].Text, out int sphereX) && int.TryParse(propertyTextBoxes[1].Text, out int sphereY) &&
                            int.TryParse(propertyTextBoxes[2].Text, out int sphereZ) && int.TryParse(propertyTextBoxes[3].Text, out int sphereRadius))
                        {
                            SelectedShape = new ODEVLIB.Collisions.Sphere { X = sphereX, Y = sphereY, Z = sphereZ, Radius = sphereRadius };
                        }
                        else
                        {
                            throw new Exception("Invalid input for Sphere properties");
                        }
                        break;

                    default:
                        throw new Exception("Invalid shape type");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelBt_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}