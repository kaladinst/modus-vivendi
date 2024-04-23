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
        public object SelectedShape { get; private set; }
        private List<TextBox> propertyTextBoxes = new List<TextBox>();
        private List<Label> propertyLabels = new List<Label>();
        private Dictionary<string, List<string>> shapeCollisions = new Dictionary<string, List<string>>
{
    { "Point", new List<string> { "Quadrilateral", "Circle", "Cylinder", "Sphere", "RectangularPrism" } },
    { "Quadrilateral", new List<string> { "Circle", "Quadrilateral" , "Point" } },
    { "Circle", new List<string> { "Point", "Quadrilateral", "Circle" } },
    { "Cylinder", new List<string> { "Point", "Sphere", "Surface", "Cylinder" } },
    { "Surface", new List<string> { "Cylinder", "Sphere", "RectangularPrism" } },
    { "Sphere", new List<string> { "Point", "Cylinder", "Surface", "Sphere", "RectangularPrism" } },
    { "RectangularPrism", new List<string> { "Point", "Surface", "Sphere", "RectangularPrism" } }
};
        public ShapeDialog()
        {
            InitializeComponent();
            shapeComboBox.Items.Clear();
            shapeComboBox.Items.Add("Point");
            shapeComboBox.Items.Add("Quadrilateral");
            shapeComboBox.Items.Add("Cylinder");
            shapeComboBox.Items.Add("Rectangle");
            shapeComboBox.Items.Add("Circle");
            shapeComboBox.Items.Add("RectangularPrism");
            shapeComboBox.Items.Add("Surface");
            shapeComboBox.Items.Add("Sphere");
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
        private void CreatePropertyTextBoxes()
        {
            List<string> properties;
            switch (shapeComboBox.SelectedItem.ToString())
            {
                case "Point":
                    properties = new List<string> { "X", "Y" };
                    break;
                case "Quadrilateral":
                    properties = new List<string> { "X", "Y", "Width", "Height" };
                    break;
                case "Cylinder":
                    properties = new List<string> { "Center X", "Center Y", "Radius", "Height" };
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
                if (column > 4)
                {
                    column = 0;
                    row++;
                }
            }
        }

        private void okBt_Click(object sender, EventArgs e)
        {
            try
            {
                switch (shapeComboBox.SelectedItem.ToString())
                {
                    case "Point":
                        if (int.TryParse(propertyTextBoxes[0].Text, out int x) && int.TryParse(propertyTextBoxes[1].Text, out int y))
                        {
                            SelectedShape = new ODEVLIB.Collisions.Point { X = x, Y = y };
                        }
                        else
                        {
                            throw new Exception("Invalid input for Point properties");
                        }
                        break;
                    case "Quadrilateral":
                        if (int.TryParse(propertyTextBoxes[0].Text, out int quadX) && int.TryParse(propertyTextBoxes[1].Text, out int quadY) &&
                            int.TryParse(propertyTextBoxes[2].Text, out int width) && int.TryParse(propertyTextBoxes[3].Text, out int height))
                        {
                            SelectedShape = new ODEVLIB.Collisions.Quadrilateral { X = quadX, Y = quadY, Width = width, Height = height };
                        }
                        else
                        {
                            throw new Exception("Invalid input for Quadrilateral properties");
                        }
                        break;
                    case "Cylinder":
                        if (int.TryParse(propertyTextBoxes[0].Text, out int cylX) && int.TryParse(propertyTextBoxes[1].Text, out int cylY) &&
                            int.TryParse(propertyTextBoxes[2].Text, out int cylZ) && int.TryParse(propertyTextBoxes[3].Text, out int radius) &&
                            int.TryParse(propertyTextBoxes[4].Text, out int cylHeight))
                        {
                            SelectedShape = new ODEVLIB.Collisions.Cylinder { X = cylX, Y = cylY, Z = cylZ, Radius = radius, Height = cylHeight };
                        }
                        else
                        {
                            throw new Exception("Invalid input for Cylinder properties");
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