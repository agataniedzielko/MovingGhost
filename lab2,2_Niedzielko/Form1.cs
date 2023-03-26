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

namespace lab2
{
    public partial class Form1 : Form
    {
        
        //Image image = Image.FromFile(@"C:\Users\anied\OneDrive\Pulpit\duchy.png");
        private List<string> paths = new List<string>(new String[] { @"C:\Users\anied\OneDrive\Pulpit\duch1.png", @"C:\Users\anied\OneDrive\Pulpit\duch2.png", @"C:\Users\anied\OneDrive\Pulpit\duch3.png" });
        private int curr = 0;
        Image[] images = new Image[3]; 
     
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        int y = 150;
        int x_tlo = 0;
        int y_tlo = 0;
        int x_d = 400;
        int y_d = 0;
        int x_d2 = 800;
        int y_d2 = 0;
        int krokx = 3;
        int kroky = 3;
        int krokx2 = 5;
        int kroky2 = 5;

        Bitmap b = new Bitmap(5000, 5000);
        
        private void timer1_Tick(object sender, EventArgs e)
        { 
            if (b == null)
            {
                b = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            }

            using (Graphics g = Graphics.FromImage(b))
            {
                g.FillRectangle(Brushes.White, 0, 0, ClientRectangle.Width, ClientRectangle.Height);
                for (int index = 0; index < 3; index++)
                {
                    images[index] = Image.FromFile(paths[index]);
                }
                Image tlo = Image.FromFile(@"C:\Users\anied\OneDrive\Pulpit\tlo.png");
                g.DrawImage(tlo, new Rectangle(x_tlo, y_tlo, tlo.Width, tlo.Height));

                Image duszek1 = Image.FromFile(@"C:\Users\anied\OneDrive\Pulpit\duszek1.png");
                g.DrawImage(duszek1, new Rectangle(x_d, y_d, 74, 90));

                Image duszek2 = Image.FromFile(@"C:\Users\anied\OneDrive\Pulpit\duszek2.png");
                g.DrawImage(duszek2, new Rectangle(x_d2, y_d2, 70, 87));


                g.DrawImage(images[curr], new Rectangle(150, y, 246, 248));
                g.Dispose();
                curr = ((curr + 1) % (paths.Count()));
                x_d+=krokx;
                if ((x_d <= 0) || ((x_d) >= (this.ClientRectangle.Width - duszek1.Width)))
                {
                    krokx = -krokx;
                }
                y_d += kroky;
                if ((y_d <= 0) || ((y_d) >= (this.ClientRectangle.Height - duszek1.Width)))
                {
                    kroky = -kroky;
                }

                x_d2 += krokx2;
                if ((x_d2 <= 0) || ((x_d2) >= (this.ClientRectangle.Width - duszek2.Width)))
                {
                    krokx2 = -krokx2;
                }
                y_d2 += kroky2;
                if ((y_d2 <= 0) || ((y_d2) >= (this.ClientRectangle.Height - duszek2.Width)))
                {
                    kroky2 = -kroky2;
                }

                //g.Clear(Color.Transparent);

                if ((x_tlo + tlo.Width) < ClientRectangle.Width)
                {
                    x_tlo = 0;
                }

                if (x_tlo  > 0 )
                {
                    x_tlo = -tlo.Width;
                }

                if (y > ClientRectangle.Height)
                {
                    y = ClientRectangle.Height - 200;
                }
            }

       

            using (Graphics gg = CreateGraphics())
            {
                gg.DrawImageUnscaled(b, 0, 0);
            }

        }
           private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Up)
            {
                if ( (y > -50) && (y < (ClientRectangle.Height )))
                {
                    y -=  15;
                }
               

            }
            if (e.KeyCode == Keys.Down)
            {
                if ((y > -50) && ((y + 190) < (ClientRectangle.Height)))
                {
                    y += 15;
                }
                
            }
            if (e.KeyCode == Keys.Right)
            {
                x_tlo-=10;
                x_d -= 10;
                x_d2 -= 10;

            }
            if (e.KeyCode == Keys.Left)
            {
                x_tlo += 10;
                x_d += 10;
                x_d2 += 10;

            }


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           

        }
    }

        
    
}
