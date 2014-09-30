using System;
using System.Drawing;
using System.IO;

namespace GraphicsExample
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// image draw example
			Bitmap image = new Bitmap (200, 200);
			Graphics gr = Graphics.FromImage (image);
			gr.FillRectangle (Brushes.Orange, new RectangleF(0, 0, 100, 50));
			string path = System.IO.Path.Combine (
				Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
				"Example.png"
			);

			using (image) {
				image.Save (path, System.Drawing.Imaging.ImageFormat.Png);
			}

			Console.WriteLine ("Image created! Check yo desktop for Example.png");
		}
	}
}
