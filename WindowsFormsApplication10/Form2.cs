using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication10
{
	public partial class Form2 : Form
	{

		private int szer1 = 0;
		private int wys1 = 0;


		private int szer2 = 0;
		private int wys2 = 0;

		private int szer = 0;
		private int wys = 0;
		public Form2()
		{
			InitializeComponent();
		}

		private void Form2_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (openFileDialog2.ShowDialog() == DialogResult.OK)
			{
				pictureBox1.Load(openFileDialog2.FileName);
				szer1 = pictureBox1.Image.Width;
				wys1 = pictureBox1.Image.Height;
			   

			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (openFileDialog2.ShowDialog() == DialogResult.OK)
			{
				pictureBox2.Load(openFileDialog2.FileName);
				szer2 = pictureBox2.Image.Width;
				wys2 = pictureBox2.Image.Height;
				
				if (wys1 > wys2)
					wys = wys1;
				else
					wys = wys2;
				if(szer1>szer2)
					szer = szer1;
				else
					szer = szer2;
				pictureBox3.Image = new Bitmap(szer, wys);

			}
		}
		//funkcja resize
		public static Bitmap ResizeImage(Image image, int width, int height)
		{
			var destRect = new Rectangle(0, 0, width, height);
			var destImage = new Bitmap(width, height);

			destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

			using (var graphics = Graphics.FromImage(destImage))
			{
				graphics.CompositingMode = CompositingMode.SourceCopy;
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

				using (var wrapMode = new ImageAttributes())
				{
					wrapMode.SetWrapMode(WrapMode.TileFlipXY);
					graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
				}
			}

			return destImage;
		}

		//ZAMKNIJ
		private void button3_Click(object sender, EventArgs e)
		{
			Close();
		}
		
		//SUMA
		private void button4_Click(object sender, EventArgs e)
		{
			
			Cursor = Cursors.WaitCursor;
			Bitmap b1 = (Bitmap)pictureBox1.Image;
			Bitmap b2 = (Bitmap)pictureBox2.Image;
			Bitmap b3 = (Bitmap)pictureBox3.Image;
			Color k1, k2;
			int r, g, b;

			for (int i = 0; i < szer; i++)
			{
				for (int j = 0; j < wys; j++)
				{
					k1 = b1.GetPixel(i, j);
					k2 = b2.GetPixel(i, j);
					r = (k1.R + k2.R)/2;
					g = (k1.G + k2.G)/2;
					b = (k1.B + k2.B)/2;

					
					b3.SetPixel(i, j, Color.FromArgb(r,g,b));

				}
			}
			pictureBox3.Refresh();
			Cursor = Cursors.Default;
		}

		// button RESIZE
		private void button5_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			Bitmap b1 = (Bitmap)pictureBox1.Image;
			Bitmap b2 = (Bitmap)pictureBox2.Image;
			int ds, dw;
			if (wys1 > wys2)
				dw = wys2;
			else
				dw = wys1;
			if (szer1 > szer2)
				ds = szer2;
			else
				ds = szer1;
			pictureBox1.Image = ResizeImage(b1, ds,dw);
			pictureBox2.Image = ResizeImage(b2, ds,dw);
		   
			wys = dw;
			szer = ds;
			pictureBox3.Size = new Size(wys, szer);
			pictureBox1.Refresh();
			pictureBox2.Refresh();
			Cursor = Cursors.Default;

		}

		//ODEJMOWANIE
		private void button6_Click(object sender, EventArgs e)
		{

			Cursor = Cursors.WaitCursor;
			Bitmap b1 = (Bitmap)pictureBox1.Image;
			Bitmap b2 = (Bitmap)pictureBox2.Image;
			Bitmap b3 = (Bitmap)pictureBox3.Image;
			Color k1, k2;
			int r, g, b;

			for (int i = 0; i < szer; i++)
			{
				for (int j = 0; j < wys; j++)
				{
					k1 = b1.GetPixel(i, j);
					k2 = b2.GetPixel(i, j);
					r =Math.Abs (k1.R + k2.R -255);
					g = Math.Abs(k1.G + k2.G - 255) ;
					b = Math.Abs(k1.B + k2.B - 255) ;


					b3.SetPixel(i, j, Color.FromArgb(r, g, b));

				}
			}
			pictureBox3.Refresh();
			Cursor = Cursors.Default;
		}

		//ROZNICA

		private void button7_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			Bitmap b1 = (Bitmap)pictureBox1.Image;
			Bitmap b2 = (Bitmap)pictureBox2.Image;
			Bitmap b3 = (Bitmap)pictureBox3.Image;
			Color k1, k2;
			int r, g, b;

			for (int i = 0; i < szer; i++)
			{
				for (int j = 0; j < wys; j++)
				{
					k1 = b1.GetPixel(i, j);
					k2 = b2.GetPixel(i, j);
					r = Math.Abs(k1.R - k2.R) / 2;
					g = Math.Abs(k1.G - k2.G) / 2;
					b = Math.Abs(k1.B - k2.B) / 2;


					b3.SetPixel(i, j, Color.FromArgb(r, g, b));

				}
			}
			pictureBox3.Refresh();
			Cursor = Cursors.Default;
		}
		//MNOZENIE
		private void button8_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			Bitmap b1 = (Bitmap)pictureBox1.Image;
			Bitmap b2 = (Bitmap)pictureBox2.Image;
			Bitmap b3 = (Bitmap)pictureBox3.Image;
			Color k1, k2;
			int r, g, b;

			for (int i = 0; i < szer; i++)
			{
				for (int j = 0; j < wys; j++)
				{
					k1 = b1.GetPixel(i, j);
					k2 = b2.GetPixel(i, j);
					r = Math.Abs(k1.R * k2.R) / 255;
					g = Math.Abs(k1.G * k2.G) / 255;
					b = Math.Abs(k1.B * k2.B) / 255;

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

					b3.SetPixel(i, j, Color.FromArgb(r, g, b));

				}
			}
			pictureBox3.Refresh();
			Cursor = Cursors.Default;
		}

		//LSAGODNE
		private void button16_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			Bitmap b1 = (Bitmap)pictureBox1.Image;
			Bitmap b2 = (Bitmap)pictureBox2.Image;
			Bitmap b3 = (Bitmap)pictureBox3.Image;
			Color k1, k2;

			int r, g, b;
			double rr, gg, bb;
			double rr2, gg2, bb2;


			for (int i = 0; i < szer; i++)
			{
				for (int j = 0; j < wys; j++)
				{
					k1 = b1.GetPixel(i, j);
					rr = k1.R / 255.0;
					gg = k1.G / 255.0;
					bb = k1.B / 255.0;

					k2 = b2.GetPixel(i, j);
					rr2 = k2.R / 255.0;
					gg2 = k2.G / 255.0;
					bb2 = k2.B / 255.0;

					if (rr2 < 0.5)
						rr = 2 * rr * rr2 + Math.Pow(rr, 2) * (1- 2*rr2);
					else
						rr = Math.Sqrt(rr) *(2*rr2-1) + (2 * rr * (1 - rr2));
					if (gg2 < 0.5)
						gg = 2 * gg * gg2 + Math.Pow(gg, 2) * (1 - 2 * gg2);
					else
						gg = Math.Sqrt(gg) * (2 * gg2 - 1) + (2 * gg * (1 - gg2));
					if (bb2 < 0.5)
						bb = 2 * bb * bb2 + +Math.Pow(bb, 2) * (1 - 2 * bb2);
					else
						bb = Math.Sqrt(bb) * (2 * bb2 - 1) + (2 * bb * (1 - bb2));


					rr = rr * 255;
					gg = gg * 255;
					bb = bb * 255;
					r = (int)rr;
					g = (int)gg;
					b = (int)bb;

					b3.SetPixel(i, j, Color.FromArgb(r, g, b));
				}
			}
			pictureBox3.Refresh();
			Cursor = Cursors.Default;
		}


		//opacity
		private void button20_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			Bitmap b1 = (Bitmap)pictureBox1.Image;
			Bitmap b2 = (Bitmap)pictureBox2.Image;
			Bitmap b3 = (Bitmap)pictureBox3.Image;
			Color k1, k2;
			int r, g, b;
			double alpha = 0.3;

			for (int i = 0; i < szer; i++)
			{
				for (int j = 0; j < wys; j++)
				{
					k1 = b1.GetPixel(i, j);
					k2 = b2.GetPixel(i, j);
					r = (int)((1 - alpha) * k2.R + k1.R * alpha);
					g = (int)((1 - alpha) * k2.G + k1.G * alpha);
					b = (int)((1 - alpha) * k2.B + k1.B * alpha);
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

					b3.SetPixel(i, j, Color.FromArgb(r, g, b));

				}
			}
			pictureBox3.Refresh();
			Cursor = Cursors.Default;
		}

		//SCREEN MODE
		private void button9_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			Bitmap b1 = (Bitmap)pictureBox1.Image;
			Bitmap b2 = (Bitmap)pictureBox2.Image;
			Bitmap b3 = (Bitmap)pictureBox3.Image;
			Color k1, k2;

			int r, g, b;
			double rr, gg, bb;
			double rr2, gg2, bb2;


			for (int i = 0; i < szer; i++)
			{
				for (int j = 0; j < wys; j++)
				{
					k1 = b1.GetPixel(i, j);
					rr = k1.R / 255.0;
					gg = k1.G / 255.0;
					bb = k1.B / 255.0;

					k2 = b2.GetPixel(i, j);
					rr2 = k2.R / 255.0;
					gg2 = k2.G / 255.0;
					bb2 = k2.B / 255.0;

					rr = 1 - ((1-rr) * (1-rr2));
					gg = 1 - ((1-gg) * (1-gg2));
					bb = 1 - ((1-bb) * (1-bb2));




					rr = rr * 255;
					gg = gg * 255;
					bb = bb * 255;
					r = (int)rr;
					g = (int)gg;
					b = (int)bb;

					b3.SetPixel(i, j, Color.FromArgb(r, g, b));
				}
			}
			pictureBox3.Refresh();
			Cursor = Cursors.Default;
		}

		//NEGACJA
        private void button10_Click(object sender, EventArgs e)
        {
			Cursor = Cursors.WaitCursor;
			Bitmap b1 = (Bitmap)pictureBox1.Image;
			Bitmap b2 = (Bitmap)pictureBox2.Image;
			Bitmap b3 = (Bitmap)pictureBox3.Image;
			Color k1, k2;
			double rr, gg, bb;
			double rr2, gg2, bb2;
			int r, g, b;

			for (int i = 0; i < szer; i++)
			{
				for (int j = 0; j < wys; j++)
				{
					k1 = b1.GetPixel(i, j);
					rr = k1.R / 255.0;
					gg = k1.G / 255.0;
					bb = k1.B / 255.0;

					k2 = b2.GetPixel(i, j);
					rr2 = k2.R / 255.0;
					gg2 = k2.G / 255.0;
					bb2 = k2.B / 255.0;
					rr =1 - Math.Abs(1 -rr - rr2);
					gg = 1 - Math.Abs(1 -gg - gg2);
					bb2 = 1 - Math.Abs(1 -bb2 - bb2);

					rr = rr * 255;
					gg = gg * 255;
					bb = bb * 255;
					r = (int)rr;
					g = (int)gg;
					b = (int)bb;


					b3.SetPixel(i, j, Color.FromArgb(r, g, b));

				}
			}
			pictureBox3.Refresh();
			Cursor = Cursors.Default;
		}

		//DARKEN

        private void button11_Click(object sender, EventArgs e)
        {
			Cursor = Cursors.WaitCursor;
			Bitmap b1 = (Bitmap)pictureBox1.Image;
			Bitmap b2 = (Bitmap)pictureBox2.Image;
			Bitmap b3 = (Bitmap)pictureBox3.Image;
			Color k1, k2;
			int r, g, b;

			for (int i = 0; i < szer; i++)
			{
				for (int j = 0; j < wys; j++)
				{
					k1 = b1.GetPixel(i, j);
					k2 = b2.GetPixel(i, j);
					
					if(k1.R < k2.R)
						r = k1.R;
					else
						r = k2.R;
					if(k1.G < k2.G)
						g = k1.G;
					else
						g = k2.G;
					if(k1.B < k2.B)
						b = k1.B;
					else
						b = k2.B;


					b3.SetPixel(i, j, Color.FromArgb(r, g, b));

				}
			}
			pictureBox3.Refresh();
			Cursor = Cursors.Default;
		}

		//LIGHTEN
        private void button12_Click(object sender, EventArgs e)
        {
			Cursor = Cursors.WaitCursor;
			Bitmap b1 = (Bitmap)pictureBox1.Image;
			Bitmap b2 = (Bitmap)pictureBox2.Image;
			Bitmap b3 = (Bitmap)pictureBox3.Image;
			Color k1, k2;
			int r, g, b;

			for (int i = 0; i < szer; i++)
			{
				for (int j = 0; j < wys; j++)
				{
					k1 = b1.GetPixel(i, j);
					k2 = b2.GetPixel(i, j);

					if (k1.R > k2.R)
						r = k1.R;
					else
						r = k2.R;
					if (k1.G > k2.G)
						g = k1.G;
					else
						g = k2.G;
					if (k1.B > k2.B)
						b = k1.B;
					else
						b = k2.B;


					b3.SetPixel(i, j, Color.FromArgb(r, g, b));

				}
			}
			pictureBox3.Refresh();
			Cursor = Cursors.Default;
		}

		//EXCLUSION 
        private void button13_Click(object sender, EventArgs e)
        {

			Cursor = Cursors.WaitCursor;
			Bitmap b1 = (Bitmap)pictureBox1.Image;
			Bitmap b2 = (Bitmap)pictureBox2.Image;
			Bitmap b3 = (Bitmap)pictureBox3.Image;
			Color k1, k2;
			int r, g, b;

			for (int i = 0; i < szer; i++)
			{
				for (int j = 0; j < wys; j++)
				{
					k1 = b1.GetPixel(i, j);
					k2 = b2.GetPixel(i, j);
					r = Math.Abs(k1.R + k2.R - (k1.R * k2.R *2)) / 510;
					g = Math.Abs(k1.G + k2.G - (k1.G * k2.G * 2)) / 510;
					b = Math.Abs(k1.B + k2.B - (k1.B * k2.B * 2)) / 510;


					b3.SetPixel(i, j, Color.FromArgb(r, g, b));

				}
			}
			pictureBox3.Refresh();
			Cursor = Cursors.Default;
		}

		//NAKLADKA
        private void button14_Click(object sender, EventArgs e)
        {
			Cursor = Cursors.WaitCursor;

			Bitmap b1 = (Bitmap)pictureBox1.Image;
			Bitmap b2 = (Bitmap)pictureBox2.Image;
			Bitmap b3 = (Bitmap)pictureBox3.Image;
			Color k1, k2;

			int r, g, b;
			double rr, gg, bb;
			double rr2, gg2, bb2;


			for (int i = 0; i < szer; i++)
			{
				for (int j = 0; j < wys; j++)
				{
					k1 = b1.GetPixel(i, j);
					rr = k1.R / 255.0;
					gg = k1.G / 255.0;
					bb = k1.B / 255.0;

					k2 = b2.GetPixel(i, j);
					rr2 = k2.R / 255.0;
					gg2 = k2.G / 255.0;
					bb2 = k2.B / 255.0;

					if (rr < 0.5)
						rr = 2 * rr * rr2;
					else
						rr = 1 - (2 * (1 - rr) * (1 - rr2));
					if (gg < 0.5)
						gg = 2 * gg * gg2;
					else
						gg = 1 - (2 * (1 - gg) * (1 - gg2));
					if(bb < 0.5)
						bb = 2 * bb * bb2;
					else
						bb = 1 - (2 * (1 - bb) * (1 - bb2));


					rr = rr * 255;
					gg = gg * 255;
					bb = bb * 255;
					r = (int)rr;
					g = (int)gg;
					b = (int)bb;

					b3.SetPixel(i, j, Color.FromArgb(r, g, b));
				}
			}
			pictureBox3.Refresh();
			Cursor = Cursors.Default;
		}

		//OSTRE ŚWIATŁO
        private void button15_Click(object sender, EventArgs e)
        {

			Cursor = Cursors.WaitCursor;

			Bitmap b1 = (Bitmap)pictureBox1.Image;
			Bitmap b2 = (Bitmap)pictureBox2.Image;
			Bitmap b3 = (Bitmap)pictureBox3.Image;
			Color k1, k2;

			int r, g, b;
			double rr, gg, bb;
			double rr2, gg2, bb2;


			for (int i = 0; i < szer; i++)
			{
				for (int j = 0; j < wys; j++)
				{
					k1 = b1.GetPixel(i, j);
					rr = k1.R / 255.0;
					gg = k1.G / 255.0;
					bb = k1.B / 255.0;

					k2 = b2.GetPixel(i, j);
					rr2 = k2.R / 255.0;
					gg2 = k2.G / 255.0;
					bb2 = k2.B / 255.0;

					if (rr2 < 0.5)
						rr = 2 * rr * rr2;
					else
						rr = 1 - (2 * (1 - rr) * (1 - rr2));
					if (gg2 < 0.5)
						gg = 2 * gg * gg2;
					else
						gg = 1 - (2 * (1 - gg) * (1 - gg2));
					if (bb2 < 0.5)
						bb = 2 * bb * bb2;
					else
						bb = 1 - (2 * (1 - bb) * (1 - bb2));


					rr = rr * 255;
					gg = gg * 255;
					bb = bb * 255;
					r = (int)rr;
					g = (int)gg;
					b = (int)bb;

					b3.SetPixel(i, j, Color.FromArgb(r, g, b));
				}
			}
			pictureBox3.Refresh();
			Cursor = Cursors.Default;
		}

		//ROZCIENCZENIE
        private void button17_Click(object sender, EventArgs e)
        {

			Cursor = Cursors.WaitCursor;

			Bitmap b1 = (Bitmap)pictureBox1.Image;
			Bitmap b2 = (Bitmap)pictureBox2.Image;
			Bitmap b3 = (Bitmap)pictureBox3.Image;
			Color k1, k2;

			int r, g, b;
			double rr, gg, bb;
			double rr2, gg2, bb2;


			for (int i = 0; i < szer; i++)
			{
				for (int j = 0; j < wys; j++)
				{
					k1 = b1.GetPixel(i, j);
					rr = k1.R / 255.0;
					gg = k1.G / 255.0;
					bb = k1.B / 255.0;

					k2 = b2.GetPixel(i, j);
					rr2 = k2.R / 255.0;
					gg2 = k2.G / 255.0;
					bb2 = k2.B / 255.0;

					rr = (rr / (1 - rr2));
					gg =( gg / (1 - gg2));
					bb = (bb / (1 - bb2));


					rr = rr * 255;
					gg = gg * 255;
					bb = bb * 255;
					r = (int)rr;
					g = (int)gg;
					b = (int)bb;
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

					b3.SetPixel(i, j, Color.FromArgb(r, g, b));
				}
			}
			pictureBox3.Refresh();
			Cursor = Cursors.Default;
		}

		//WYPALENIE
        private void button18_Click(object sender, EventArgs e)
        {

			Cursor = Cursors.WaitCursor;

			Bitmap b1 = (Bitmap)pictureBox1.Image;
			Bitmap b2 = (Bitmap)pictureBox2.Image;
			Bitmap b3 = (Bitmap)pictureBox3.Image;
			Color k1, k2;

			int r, g, b;
			double rr, gg, bb;
			double rr2, gg2, bb2;


			for (int i = 0; i < szer; i++)
			{
				for (int j = 0; j < wys; j++)
				{
					k1 = b1.GetPixel(i, j);
					rr = k1.R / 255.0;
					gg = k1.G / 255.0;
					bb = k1.B / 255.0;

					k2 = b2.GetPixel(i, j);
					rr2 = k2.R / 255.0;
					gg2 = k2.G / 255.0;
					bb2 = k2.B / 255.0;

					rr = 1 - (1 - rr) / rr2;
					gg = 1 - (1 - gg) / gg2;
					bb = 1 - (1 - bb) / bb2;


					rr = rr * 255;
					gg = gg * 255;
					bb = bb * 255;
					r = (int)rr;
					g = (int)gg;
					b = (int)bb;
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

					b3.SetPixel(i, j, Color.FromArgb(r, g, b));
				}
			}
			pictureBox3.Refresh();
			Cursor = Cursors.Default;
		}
		//REFLECT
        private void button19_Click(object sender, EventArgs e)
        {


			Cursor = Cursors.WaitCursor;

			Bitmap b1 = (Bitmap)pictureBox1.Image;
			Bitmap b2 = (Bitmap)pictureBox2.Image;
			Bitmap b3 = (Bitmap)pictureBox3.Image;
			Color k1, k2;

			int r, g, b;
			double rr, gg, bb;
			double rr2, gg2, bb2;


			for (int i = 0; i < szer; i++)
			{
				for (int j = 0; j < wys; j++)
				{
					k1 = b1.GetPixel(i, j);
					rr = k1.R / 255.0;
					gg = k1.G / 255.0;
					bb = k1.B / 255.0;

					k2 = b2.GetPixel(i, j);
					rr2 = k2.R / 255.0;
					gg2 = k2.G / 255.0;
					bb2 = k2.B / 255.0;

					rr = Math.Pow(rr, 2) / (1 - rr2);
					gg = Math.Pow(gg, 2) / (1 - gg2);
					bb = Math.Pow(bb, 2) / (1 - bb2);


					rr = rr * 255;
					gg = gg * 255;
					bb = bb * 255;
					r = (int)rr;
					g = (int)gg;
					b = (int)bb;
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

					b3.SetPixel(i, j, Color.FromArgb(r, g, b));
				}
			}
			pictureBox3.Refresh();
			Cursor = Cursors.Default;
		}

		//ZAPISZ
        private void button21_Click(object sender, EventArgs e)
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
