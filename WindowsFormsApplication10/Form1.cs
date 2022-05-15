using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication10
{
    public partial class Form1 : Form
    {
        private int szer = 0;
        private int wys = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        //odczyt oibrazka

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                szer = pictureBox1.Image.Width;
                wys = pictureBox1.Image.Height;
                pictureBox2.Image = new Bitmap(szer, wys);

            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        //R-B
        private void button3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Bitmap b1 =(Bitmap) pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k1,k2;

            for(int i= 0; i <szer; i++)
            {
                for(int j= 0; j <wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    k2 = Color.FromArgb(k1.B, k1.G, k1.R);
                    b2.SetPixel(i, j, k2);

                }
            }
            pictureBox2.Refresh();
            Cursor = Cursors.Default;
        }

        //R-G
        private void button4_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k1, k2;

            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    k2 = Color.FromArgb(k1.G, k1.R, k1.B);
                    b2.SetPixel(i, j, k2);

                }
            }
            pictureBox2.Refresh();
            Cursor = Cursors.Default;
        }

        //G-B
        private void button5_Click(object sender, EventArgs e)
        {
             Cursor = Cursors.WaitCursor;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k1, k2;

            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    k2 = Color.FromArgb(k1.R, k1.B, k1.G);
                    b2.SetPixel(i, j, k2);

                }
            }
            pictureBox2.Refresh();
            Cursor = Cursors.Default;
        }

        //Z PRAWEJ STRONY NA LEWA STRONE OBRAZEK

        private void button6_Click(object sender, EventArgs e)
        {

            Cursor = Cursors.WaitCursor;
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
          

            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                
                    b1.SetPixel(i, j, b2.GetPixel(i,j));

                }
            }
            pictureBox1.Refresh();
            Cursor = Cursors.Default;
     

        }

        //GRAYSCALE

        private void button7_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k1;
            int amplituda;

            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    amplituda = (k1.R + k1.G + k1.B) / 3;

                    k1 = Color.FromArgb(amplituda, amplituda, amplituda);
                    b2.SetPixel(i, j, k1);

                }
            }
            pictureBox2.Refresh();
            Cursor = Cursors.Default;
        }

        //CZARNOBIALE

        private void button8_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k1;
            int amplituda;
            int prog = (int) numericUpDown1.Value;

            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    amplituda = (k1.R + k1.G + k1.B) / 3;

                    if(amplituda> prog)
                    {
                        k1 = Color.FromArgb(255, 255, 255);
                    }
                    else
                    {
                        k1 = Color.FromArgb(0, 0, 0);
                    }
                    
                    b2.SetPixel(i, j, k1);

                }
            }
            pictureBox2.Refresh();
            Cursor = Cursors.Default;

        }

        //ZMIEKCZANIE

        private void button9_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k1;
            int r, g, b;
            for(int i = 1; i < szer-1; i++)
            {
                for(int j = 1; j < wys-1; j++)
                {
                    r = 0;
                    g = 0;
                    b = 0;
                    for(int k = -1; k <= 1; k++)
                    {
                        for(int l = -1; l <= 1; l++)
                        {
                            k1 = b1.GetPixel(i+k,j+l);
                            r += k1.R;
                            g += k1.G;
                            b += k1.B;
                        }
                    }
                    r = r / 9;
                    g = g / 9;
                    b = b / 9;
                    b2.SetPixel(i, j, Color.FromArgb(r,g,b));
                    
                }
            }
            pictureBox2.Refresh();
            Cursor = Cursors.Default;
            
        }


        //KONTUR    

        private void button11_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            int kontur = (int)numericUpDown2.Value;
            Color k1, k2, k3;
            int s1, s2, s3;

            for (int i = 0; i < szer -1; i++)
            {
      
                for (int j = 0; j < wys -1; j++)
                {

                    k1 = b1.GetPixel(i, j);
                    k2 = b1.GetPixel(i+1, j);
                    k3 = b1.GetPixel(i, j+1);

                    s1 = (k1.R + k1.G + k1.B) / 3;
                    s2 = (k2.R + k2.G + k2.B) / 3;
                    s3 = (k1.R + k3.G + k3.B) / 3;

                    if (Math.Abs(s1 - s2) > kontur || Math.Abs(s1 - s3) > kontur)
                    {
                       
                        b2.SetPixel(i, j, Color.Black);
                    }
                    else
                        b2.SetPixel(i, j, Color.White);



                }
            }
            pictureBox2.Refresh();
            Cursor = Cursors.Default;
        }

        //MASKI

        private void button12_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            int[,] maska = new int[3,3];
            maska[0, 0] = Int32.Parse(textBox1.Text);
            maska[0, 1] = Int32.Parse(textBox2.Text);
            maska[0, 2] = Int32.Parse(textBox3.Text);
            maska[1, 0] = Int32.Parse(textBox4.Text);
            maska[1, 1] = Int32.Parse(textBox5.Text);
            maska[1, 2] = Int32.Parse(textBox6.Text);
            maska[2, 0] = Int32.Parse(textBox7.Text);
            maska[2, 1] = Int32.Parse(textBox8.Text);
            maska[2, 2] = Int32.Parse(textBox9.Text);
            int suma = 0;

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    suma+=maska[i,j];
                }
            }

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k1;
            int r, g, b;
            for (int i = 1; i < szer - 1; i++)
            {
                for (int j = 1; j < wys - 1; j++)
                {
                    r = g = b = 0;
                    
                    for (int k = -1; k <= 1; k++)
                    {
                        for (int l = -1; l <= 1; l++)
                        {
                            k1 = b1.GetPixel(i + k, j + l);
                            r += k1.R * maska[k+1,l+1];
                            g += k1.G * maska[k+1,l+1];
                            b += k1.B * maska[k + 1, l+1];
                        }
                    }
                    if(suma !=0)
                    {

                    
                        r = r / suma;
                        g = g / suma;
                        b = b / suma;
                    }
                    if (r < 0)
                        r = 0;
                    if (r > 255)
                        r = 255;

                    if (g < 0)
                        g = 0;
                    if (g > 255)
                        g = 255;

                    if (b < 0)
                        b = 0;
                    if (b > 255)
                        b = 255;

                    b2.SetPixel(i, j, Color.FromArgb(r, g, b));

                }
            }
            pictureBox2.Refresh();
            Cursor = Cursors.Default;
        }


        //MASKA MIN
        private void button13_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k1;
            int r, g, b;
            int[] listr = new int[9];
            int[] listg = new int[9];
            int[] listb = new int[9];

            int count = 0;

          
            for (int i = 1; i < szer - 1; i++)
            {
                for (int j = 1; j < wys - 1; j++)
                {
                    count = 0;
                    for (int k = -1; k <= 1; k++)
                    {
                        for (int l = -1; l <= 1; l++)
                        {
                            k1 = b1.GetPixel(i + k, j + l);
                            listr[count] = k1.R;
                            listg[count] = k1.G;
                            listb[count] = k1.B;
                            count++;


                        }
                    }

                    Array.Sort(listr);
                    Array.Sort(listg);
                    Array.Sort(listb);
                    r = (int)listr[0];
                    g = (int)listg[0];
                    b = (int)listb[0];

                    b2.SetPixel(i, j, Color.FromArgb(r,g,b));

                }
            }
            pictureBox2.Refresh();
            Cursor = Cursors.Default;
        }

        //MASKA MAX
        private void button14_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k1;
            int r, g, b;
            int count = 0;
            int[] listr = new int[9];
            int[] listg = new int[9];
            int[] listb = new int[9];

            for (int i = 1; i < szer - 1; i++)
            {
                for (int j = 1; j < wys - 1; j++)
                {
                    count = 0;

                    for (int k = -1; k <= 1; k++)
                    {
                        for (int l = -1; l <= 1; l++)
                        {

                            k1 = b1.GetPixel(i + k, j + l);
                            listr[count] = k1.R;
                            listg[count] = k1.G;
                            listb[count] = k1.B;
                            count++;


                        }
                    }

                    Array.Sort(listr);
                    Array.Sort(listg);
                    Array.Sort(listb);
                    r = (int)listr[8];
                    g = (int)listg[8];
                    b = (int)listb[8];

                    b2.SetPixel(i, j, Color.FromArgb(r, g, b));

                }
            }
            pictureBox2.Refresh();
            Cursor = Cursors.Default;
        }
        //MASKA ME
        private void button15_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k1;
            int r, g, b;
            int count = 0;
            int[] listr = new int[9];
            int[] listg = new int[9];
            int[] listb = new int[9];
            int[] list = new int[9];
            int middle;
            for (int i = 1; i < szer - 1; i++)
            {
                for (int j = 1; j < wys - 1; j++)
                {
                    count = 0;
                    
                    for (int k = -1; k <= 1; k++)
                    {
                        for (int l = -1; l <= 1; l++)
                        {

                            k1 = b1.GetPixel(i + k, j + l);
                            listr[count] = k1.R;
                            listg[count] = k1.G;
                            listb[count] = k1.B;
                            count++;
                            


                        }
                    }
                    Array.Sort(listr);
                    Array.Sort(listg);
                    Array.Sort(listb);
                    middle = list.Length / 2;
                    if (listr.Length % 2 == 1)
                    {
                        r = listr[middle];
                    }
                    else
                    {
                        r = (int)((listr[middle - 1] + listr[middle]) / 2.0);
                    }
                    if (listg.Length % 2 == 1)
                    {
                        g = listg[middle];
                    }
                    else
                    {
                        g = (int)((listg[middle - 1] + listg[middle]) / 2.0);
                    }
                    if (listb.Length % 2 == 1)
                    {
                        b = listb[middle];
                    }
                    else
                    {
                        b = (int)((listb[middle - 1] + listb[middle]) / 2.0);
                    }

                    b2.SetPixel(i, j, Color.FromArgb(r, g, b));

                }
            }
            pictureBox2.Refresh();
            Cursor = Cursors.Default;
        }

        //TRANSFORMACJA LINIOWA
        private void button16_Click(object sender, EventArgs e)
        {

            Cursor = Cursors.WaitCursor;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k1;
         
            int r, g, b;
            int value = (int)numericUpDown3.Value;
           
       

            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    r = k1.R;
                    g = k1.G;
                    b = k1.B;
                    r = (int)r + value / 2;
                    g = (int)g + value / 2;
                    b = (int)b + value / 2;

                    if (r < 0)
                        r = 0;
                    if (r > 255)
                        r = 255;

                    if (g < 0)
                        g = 0;
                    if (g > 255)
                        g = 255;

                    if (b < 0)
                        b = 0;
                    if (b > 255)
                        b = 255;

                    b2.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            pictureBox2.Refresh();
            Cursor = Cursors.Default;
        }

        //POTEGOWA

        private void button17_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k1;
           
            int r, g, b;
            double rr, gg, bb;
            double value = (double)numericUpDown4.Value / 100.0;


            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    rr = k1.R/255.0;
                    gg = k1.G/255.0;
                    bb = k1.B/255.0;
                    
                    rr = Math.Pow(rr, value) ;
                    gg = Math.Pow(gg, value) ;
                    bb = Math.Pow(bb, value) ;
                   



                    rr = rr * 255;
                    gg = gg * 255;
                    bb = bb * 255;
                    r = (int)rr;
                    g= (int)gg;
                    b= (int)bb;

                    b2.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            pictureBox2.Refresh();
            Cursor = Cursors.Default;
        }
        //DRUGIE OKNO MIESZANIE
        private void button18_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        // KONTRAST1
        private void button19_Click(object sender, EventArgs e)
        {

            Cursor = Cursors.WaitCursor;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k1;

            double rr, gg, bb;
            int r, g, b;
            
            int value = (int)numericUpDown5.Value;
            Console.WriteLine(value);



            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    r = k1.R;
                    g = k1.G;
                    b = k1.B;



                    if (value > 0)
                    {
                        r = (127 / (127 - value)) * (r - value);
                        g = (127 / (127 - value)) * (g - value);
                        b = (127 / (127 - value)) * (b - value);
                    }else
                    {
                        rr = k1.R;
                        gg = k1.G;
                        bb = k1.B;
                        Console.WriteLine(rr + " " + gg + " " + bb);
                        rr = ((127 + value) / 127) * rr - value;
                        gg = ((127 + value)/127) * gg - value;
                        bb = ((127 + value) / 127) * bb - value;
                        Console.WriteLine(rr + " " + gg + " " + bb);
                        r = (int)rr;
                        g = (int)gg;
                        b = (int)bb;
                    }


                    if (r < 0)
                        r = 0;
                    if (r > 255)
                        r = 255;

                    if (g < 0)
                        g = 0;
                    if (g > 255)
                        g = 255;

                    if (b < 0)
                        b = 0;
                    if (b > 255)
                        b = 255;




                    b2.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            pictureBox2.Refresh();
            Cursor = Cursors.Default;
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {

        }

       //KONTRAST2
        private void button20_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Color k1;

            int r, g, b;
            double rr, gg, bb;
            double value = (double)numericUpDown6.Value;


            for (int i = 0; i < szer; i++)
            {
                for (int j = 0; j < wys; j++)
                {
                    k1 = b1.GetPixel(i, j);
                    rr = k1.R;
                    gg = k1.G ;
                    bb = k1.B ;

                    if(value > 0)
                    {
                        if(rr < 127)
                            rr = ((127 - value) / 127) * rr;
                        else
                            rr = ((127 - value) / 127) * rr + 2* value;
                        if(gg < 127)
                            gg = ((127 - value) / 127) * gg;
                        else
                            gg = ((127 - value) / 127) * gg + 2 * value;
                        if(bb < 127)
                            bb = ((127 - value) / 127) * bb;
                        else
                            bb = ((127 - value) / 127) * bb + 2 * value;

                    }
                    else
                    {
                        if (rr < 127 + value)
                            rr = (127 / (127 + value)) * rr;
                        else if (rr > 127 - value)
                            rr = (127 * rr + 255 * value) / (127 + value);
                        else
                            rr = 127;

                        if (gg < 127 + value)
                            gg = (127 / (127 + value)) * gg;
                        else if (gg > 127 - value)
                            gg = (127 * gg + 255 * value) / (127 + value);
                        else
                            gg = 127;

                        if (bb < 127 + value)
                            bb = (127 / (127 + value)) * bb;
                        else if (bb > 127 - value)
                            bb = (127 * bb + 255 * value) / (127 + value);
                        else
                            bb = 127;
                    }

                    r = (int)rr;
                    g = (int)gg;
                    b = (int)bb;

                    b2.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            pictureBox2.Refresh();
            Cursor = Cursors.Default;
        }
        //ZAPISZ
        private void button10_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                using (Bitmap bmp = new Bitmap(szer, wys))
                {
                    pictureBox2.DrawToBitmap(bmp, new Rectangle(0, 0, szer, wys));
                    bmp.Save(saveFileDialog1.FileName);
                }
            }
        }
    }
}
