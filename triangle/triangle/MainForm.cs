using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace triangle
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = TriangleImg();
            //tb_a.Text = "100";
            //tb_b.Text = "100";
            //tb_c.Text = "141.421356";
        }
        Image TriangleImg()
        {
            var image = new Bitmap(pictureBox1.Width, pictureBox1.Height, PixelFormat.Format32bppArgb);
            using (var g = Graphics.FromImage(image))
            {
                g.Clear(Color.Transparent);
                g.DrawLine(new Pen(Color.Black, 5), new Point(50, 50), new Point(50, 170));//катет a
                g.DrawLine(new Pen(Color.Black, 5), new Point(50, 170), new Point(270, 170));//катет b
                g.DrawLine(new Pen(Color.Black, 5), new Point(50, 50), new Point(270, 170));//гипотенуза c
                g.DrawString("A", new Font("Arial", 10), Brushes.Black, new PointF(30, 110));
                g.DrawString("B", new Font("Arial", 10), Brushes.Black, new PointF(160, 180));
                g.DrawString("C", new Font("Arial", 10), Brushes.Black, new PointF(160, 90));
            }
            return image;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SetValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetValues()
        {
            label1.Text = CalculateTheArea.SetResult(tb_a.Text, tb_b.Text, tb_c.Text);
        }
        
        private void tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox) sender;
            tb.Text = tb.Text.Replace('.', ',');
        }
        
        private void tb_c_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tb = (TextBox) sender;
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.'||e.KeyChar==',')
            {
                if (tb.Text.ToCharArray().Any(o => o == ','))
                {
                    e.Handled = true;
                }
            }
            if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        //private string CalcTwoСathetus(double a, double b)
        //{
        //    return Math.Sqrt((Math.Pow(a, 2)) + (Math.Pow(b, 2))).ToString();
        //}

        //private string CalcСathetusAndHypotenuse(double catet, double hypo)
        //{
        //    return Math.Sqrt((Math.Pow(hypo,2)-Math.Pow(catet,2))).ToString();
        //}

    }
}
