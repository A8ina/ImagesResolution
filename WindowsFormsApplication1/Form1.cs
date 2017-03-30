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
            DateTime date = DateTime.Now;
            String today = Convert.ToDateTime(date).ToString("yyyy/MM/dd");
            String name = Convert.ToDateTime(date).ToString("yyyy_MM_dd_");
            Console.WriteLine(today);

            int i = 1;
            bool go = true;
           
            //test git

            Image newImage = Image.FromFile("C:\\2017_03_17_3.jpg");
            ResizeImage(newImage, 2000, 3000);

            //using (WebClient client = new WebClient())
            //{
            //    while (go == true)
            //    {
            //        try
            //        {
            //            client.DownloadFile("https://digital.philenews.com/data/issues/newspapers/phileleftheros/" + today + "/files/pages/tablet/" + i + ".jpg", "C:\\" + name + i + ".jpg");

            //            //client.DownloadFile("https://digital.philenews.com/data/issues/newspapers/phileleftheros/" + today + "/files/pages/tablet/" + i + ".jpg", @"\\192.168.0.100\\Shared Folders\\Users Files\\CyprusNewspapers\\Output\\Phileleutheros\\" + name+ i + ".jpg");
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
