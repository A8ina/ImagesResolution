using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


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

           
            destImage.Save("C:\\2017_03_17_3_2.jpg");
            return destImage;
        }
  
        private void Form1_Load(object sender, EventArgs e)
        {
        //we take the current date
            DateTime date = DateTime.Now;
            
            String today = Convert.ToDateTime(date).ToString("yyyy/MM/dd");
            //change the format in order to store the images with date's name
            String name = Convert.ToDateTime(date).ToString("yyyy_MM_dd_");
            Console.WriteLine(today);

            int i = 1;
            bool go = true;
           
            //we can resize the images according to the resolution we need

            Image newImage = Image.FromFile("C:\\2017_03_17_3.jpg");
            ResizeImage(newImage, 2000, 3000);
            
//supposing we know the pattern where the images are stored in that location eg. test1.jpg, test2.jpg
            //using (WebClient client = new WebClient())
            //{
            //while the path has images
            //    while (go == true)
            //    {
            //        try
            //        {
           
            //            client.DownloadFile("https://www.example.com/test"+i+".jpg", "C:\\" + name +i".jpg");

            //download and store in a network file
            //            //client.DownloadFile("https://www.example.com/test"+i+".jpg", @"\\xxx.xxx.xxx.xxx\\Shared Folders\\Users Files\\" + name+ i + ".jpg");
            //            i++;

            //        }
            //        catch (Exception ee)
            //        {
            //            go = false;

            //        }


            //    }
            //}



        }
    }
}
