using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageInfoExif
{
    public static class ImageCommonExif
    {
        //static int BYTES = 1;
        //static int ASCII = 2;
        //static int SHORT = 3;
        //static int LONG = 4;
        //static int RATIONAL = 5;
        //static int Undefined = 7;
        //static int SLONG = 9;
        //static int SRATIONAL = 10;

        public static void ChechItemType1(Image image)
        {
            PropertyItem[] items = image.PropertyItems;

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Type == 1)
                {
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    Console.WriteLine("{0}  {1}", i, encoding.GetString(items[i].Value).Replace("\0",""));
                }
            }
        }

    }
}
