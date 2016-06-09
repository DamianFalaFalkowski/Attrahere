using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Attrahere.Tools.DataIO
{
    public static class ExportToJPEG
    {
        public static void Export(WriteableBitmap wb)
        {
            GetJPGFromImageControl(ConvertWriteableBitmapToBitmapImage(wb));
        }

        private static BitmapImage ConvertWriteableBitmapToBitmapImage(WriteableBitmap wbm)
        {
            BitmapImage bmImage = new BitmapImage();
            using (MemoryStream stream = new MemoryStream())
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(wbm));
                encoder.Save(stream);
                bmImage.BeginInit();
                bmImage.CacheOption = BitmapCacheOption.OnLoad;
                bmImage.StreamSource = stream;
                bmImage.EndInit();
                bmImage.Freeze();
            }
            return bmImage;
        }

        private static void GetJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            //return memStream.GetBuffer();
            Save(memStream.GetBuffer());
        }

        static int i = 0;
        private static void Save(byte[] buffer)
        {
            i += 1;
            //File.WriteAllBytes(@"C:\AttrahereExport\fractal_" + 
            //    String.Format("{0:d}_{0:T}_{1}_{2}.jpeg", DateTime.Now, DateTime.Now.Millisecond,i), buffer);
            File.WriteAllBytes(@"C:\AttrahereExport\fractal" + i + ".jpeg", buffer);
        }
    }
}
