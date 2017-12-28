using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myPaintApp
{
    public partial class Form1 : Form
    {
        Bitmap bmp = new Bitmap(1024, 768); //creates a bitmap with a common screen resolution.
        Pen p = new Pen(Color.Black, 5); //Pen object initaly set to black with a width of 5 pixles
        bool drawing = false; // flag for when the user draws

        public Form1()
        {
            InitializeComponent();
            
        }

        //when the mouse button is pressed drawing = true
        //when the mouse button is released drawing = false
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (drawing) { drawing = false; }
            else { drawing = true; }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //if drawing = true, draw an ellipse
            if (drawing)
            {
                Graphics g = Graphics.FromImage(bmp);
                g.DrawEllipse(p, e.X, e.Y, 3, 1);
                pictureBox1.Image = bmp;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            p.Color = Color.Red;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            p.Color = Color.Blue;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            p.Color = Color.Yellow;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            p.Color = Color.Purple;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            p.Color = Color.Orange;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            p.Color = Color.Green;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new saveFileDialog object
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //filter out .jpg and .bmp filetypes
            saveFileDialog1.Filter = "Jpeg Image|*.jpg|Bitmap Image *.bmp|";
            //sets the title of the dialog box
            saveFileDialog1.Title = "Save an Image File";
            //open save file dialog box
            saveFileDialog1.ShowDialog();

            //if there is a filename
            if (saveFileDialog1.FileName !="")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this.pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 2:
                        this.pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                }
            }


        }
    }
}
