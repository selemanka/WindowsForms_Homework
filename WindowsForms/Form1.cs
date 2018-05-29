using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms.Shapes;
using WindowsForms.TriangleBL;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        public List<Triangle> triangles = new List<Triangle>();
        Triangle triangle;
        Point firstPoint = Point.Empty;


        Point MouseDownLocation = Point.Empty;
        bool moving;

        public Form1()
        {
            InitializeComponent();
        }


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            triangles.Clear();
            this.Refresh();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog
            {
                Filter = "(*.xml)|*.xml",
                RestoreDirectory = true,
                CheckFileExists = true,
                CheckPathExists = true,
                Title = "Choose file"
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                triangles.Clear();
                triangle = TriangleBL.DeserializeList(openFileDialog1.FileName);

                this.Refresh();
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1 = new SaveFileDialog
            {
                RestoreDirectory = true,
                DefaultExt = "xml",
                CheckPathExists = true,
                Title = "Save your picture",
                ValidateNames = true
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TriangleBL.SerializedList(triangles, saveFileDialog1.FileName);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (var a in triangles)
            {
                a.Draw(e.Graphics);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                moving = true;
                MouseDownLocation = e.Location;

            }
            if (e.Button == MouseButtons.Right)
            {
                colorDialog1.ShowDialog();
                triangle.LineColor = colorDialog1.Color;
                this.Invalidate();
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Button == MouseButtons.Left)
            {
                var a = new Point((e.X - MouseDownLocation.X), (e.Y - MouseDownLocation.Y));
                triangles.Move(a);
                MouseDownLocation = e.Location;
                this.Invalidate();
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Button == MouseButtons.Left)
            {
                triangle = null;
                moving = false;
            }
            base.OnMouseUp(e);
        }

    }
}
