using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Media.Imaging;

namespace ImageInfoExif
{
    public static class ImageInfo
    {
        private static FileInfo _fileinfo;
        private static Image _image;

        //get exif data by JSON
        public static string GetJsonExif(string filePath)
        {
            DataStruct data;
            if (!GetPath(filePath))
                return null;

            data = Initializer(filePath);

            return JsonSerialize(data);
        }
        private static bool GetPath(string path)
        {
            _fileinfo = new FileInfo(path);

            if (_fileinfo.Exists)
            {
                _image = Image.FromFile(path);
                return true;
            }
            return false;
        }
        private static DataStruct Initializer(string filePath)
        {
            DataStruct dataStruct = new DataStruct()
            {
                Name = _fileinfo.Name,
                TotalSize = GetSize(),
                Format = GetFormat(filePath),
                DataCreated = GetPropValue(PropertyTags.PropertyTagExifDTOrig),
                DateDigit = GetPropValue(PropertyTags.PropertyTagExifDTDigitized),
                DataModified = GetModifDate(),
                CameraManufacturer = GetPropValue(PropertyTags.PropertyTagEquipMake),
                CameraModel = GetPropValue(PropertyTags.PropertyTagEquipModel),
                SoftwareUsed = GetPropValue(PropertyTags.PropertyTagSoftwareUsed),
                Dimension = GetDimension(),
                Title = GetPropValue(PropertyTags.PropertyTagTitle),
                Tag= GetPropValue(PropertyTags.PropertyTag),
                Subject= GetPropValue(PropertyTags.PropertyTagSubject),
                Comment = GetPropValue(PropertyTags.PropertyTagComment),
            //    ImageAddress = GetGeocode(),
                GPSLatitude = GetLatitude(_image),
                GPSLongitude = GetLongitude(_image),
              //  A

            };

            return dataStruct;
        }

        public static Image ResizeImage(string soursFilePath, int width, int height)
        {
            if (!File.Exists(soursFilePath))
                return null;

            Image imgToResize = Image.FromFile(soursFilePath);
            return new Bitmap(imgToResize, new Size(width, height));
        }

        public static Bitmap RotateImage(Image image, float angle)
        {
            if (image == null)
                return null;

            const double pi2 = Math.PI / 2.0;


            double oldWidth = (double)image.Width;
            double oldHeight = (double)image.Height;

            // Convert degrees to radians
            double theta = ((double)angle) * Math.PI / 180.0;
            double locked_theta = theta;

            // Ensure theta is now [0, 2pi)
            while (locked_theta < 0.0)
                locked_theta += 2 * Math.PI;

            double newWidth, newHeight;
            int nWidth, nHeight; // The newWidth/newHeight expressed as ints

            double adjacentTop, oppositeTop;
            double adjacentBottom, oppositeBottom;

            if ((locked_theta >= 0.0 && locked_theta < pi2) ||
                (locked_theta >= Math.PI && locked_theta < (Math.PI + pi2)))
            {
                adjacentTop = Math.Abs(Math.Cos(locked_theta)) * oldWidth;
                oppositeTop = Math.Abs(Math.Sin(locked_theta)) * oldWidth;

                adjacentBottom = Math.Abs(Math.Cos(locked_theta)) * oldHeight;
                oppositeBottom = Math.Abs(Math.Sin(locked_theta)) * oldHeight;
            }
            else
            {
                adjacentTop = Math.Abs(Math.Sin(locked_theta)) * oldHeight;
                oppositeTop = Math.Abs(Math.Cos(locked_theta)) * oldHeight;

                adjacentBottom = Math.Abs(Math.Sin(locked_theta)) * oldWidth;
                oppositeBottom = Math.Abs(Math.Cos(locked_theta)) * oldWidth;
            }

            newWidth = adjacentTop + oppositeBottom;
            newHeight = adjacentBottom + oppositeTop;

            nWidth = (int)Math.Ceiling(newWidth);
            nHeight = (int)Math.Ceiling(newHeight);

            Bitmap rotatedBmp = new Bitmap(nWidth, nHeight);

            using (Graphics g = Graphics.FromImage(rotatedBmp))
            {

                Point[] points;

                if (locked_theta >= 0.0 && locked_theta < pi2)
                {
                    points = new Point[] {
                                             new Point( (int) oppositeBottom, 0 ),
                                             new Point( nWidth, (int) oppositeTop ),
                                             new Point( 0, (int) adjacentBottom )
                                         };

                }
                else if (locked_theta >= pi2 && locked_theta < Math.PI)
                {
                    points = new Point[] {
                                             new Point( nWidth, (int) oppositeTop ),
                                             new Point( (int) adjacentTop, nHeight ),
                                             new Point( (int) oppositeBottom, 0 )
                                         };
                }
                else if (locked_theta >= Math.PI && locked_theta < (Math.PI + pi2))
                {
                    points = new Point[] {
                                             new Point( (int) adjacentTop, nHeight ),
                                             new Point( 0, (int) adjacentBottom ),
                                             new Point( nWidth, (int) oppositeTop )
                                         };
                }
                else
                {
                    points = new Point[] {
                                             new Point( 0, (int) adjacentBottom ),
                                             new Point( (int) oppositeBottom, 0 ),
                                             new Point( (int) adjacentTop, nHeight )
                                         };
                }

                g.DrawImage(image, points);
            }

            return rotatedBmp;
        }

        private static string GetModifDate()
        {
            return _fileinfo.LastWriteTime.ToString();
        }

        private static string GetFormat(string path)
        {
            BitmapSource img = BitmapFrame.Create(new System.Uri(path));
            BitmapMetadata metadata = (BitmapMetadata)img.Metadata;
            return metadata.Format;
        }

        private static string GetLocation(string path)
        {
            BitmapSource img = BitmapFrame.Create(new System.Uri(path));
            BitmapMetadata metadata = (BitmapMetadata)img.Metadata;
            return metadata.Location;
        }

        private static string GetPropValue(string s)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            PropertyItem item;
            int index = FromHex(s);
            try
            {
                item = _image.GetPropertyItem(index);
            }
            catch (Exception)
            {
                return null;
            }
            return encoding.GetString(item.Value.Where(i => i != 0).ToArray());
        }
        private static int FromHex(string value)
        {
            // strip the leading 0x
            if (value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                value = value.Substring(2);
            }
            return Int32.Parse(value, NumberStyles.HexNumber);
        }

        private static string GetDimension()
        {
            return string.Format(_image.Width + "x" + _image.Height);
        }

        // get image latitude  
        private static double? GetLatitude(Image targetImg)
        {
            try
            {
                PropertyItem propItemRef = targetImg.GetPropertyItem(1);
                PropertyItem propItemLat = targetImg.GetPropertyItem(2);
                return ExifGpsToFloat(propItemRef, propItemLat);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        //get image longitude 
        private static double? GetLongitude(Image targetImg)
        {
            try
            {
                PropertyItem propItemRef = targetImg.GetPropertyItem(3);
                PropertyItem propItemLong = targetImg.GetPropertyItem(4);
                return ExifGpsToFloat(propItemRef, propItemLong);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        // get GPS metadata latitude and longitude from property Item  
        // degree/minut/second format to double  
        private static double ExifGpsToFloat(PropertyItem propItemRef, PropertyItem propItem)
        {
            uint degreesNumerator = BitConverter.ToUInt32(propItem.Value, 0);
            uint degreesDenominator = BitConverter.ToUInt32(propItem.Value, 4);
            double degrees = degreesNumerator / (double)degreesDenominator;

            uint minutesNumerator = BitConverter.ToUInt32(propItem.Value, 8);
            uint minutesDenominator = BitConverter.ToUInt32(propItem.Value, 12);
            double minutes = minutesNumerator / (double)minutesDenominator;

            uint secondsNumerator = BitConverter.ToUInt32(propItem.Value, 16);
            uint secondsDenominator = BitConverter.ToUInt32(propItem.Value, 20);
            double seconds = secondsNumerator / (double)secondsDenominator;

            double coorditate = degrees + (minutes / 60f) + (seconds / 3600);
            string gpsRef = System.Text.Encoding.ASCII.GetString(new byte[1] { propItemRef.Value[0] }); //N, S, E, or W
            if (gpsRef == "S" || gpsRef == "W")
                coorditate = 0 - coorditate;
            return coorditate;
        }

        private static string GetSize()
        {
            long x = _fileinfo.Length;
            string y = null;
            if (x / 1024 == 0)
            {
                y = x + " bytes";
            }
            else if (x / (1024 * 1024) == 0)
            {
                y = string.Format("{0:n1} KB", x / 1024f);
            }
            else if (x / (1024 * 1024 * 1024) == 0)
            {
                y = string.Format("{0:n1} MB", x / 1024f);
            }
            return y;
        }

        //get current address from latitude and longitude using google map API
        public static string GetGeocode(double lng, double lat)
        {
           // double? lng = GetLongitude(_image);
          //  = GetLatitude(_image);
            if (lng == null || lat == null)
                return null;

            string result;
            string req = String.Format("https://maps.googleapis.com/maps/api/geocode/json?latlng={0},{1}&location_type=ROOFTOP&result_type=street_address&key=AIzaSyBvvLaIniCtFDPuDNgbbP-8hJkFE6qxCFo", lat, lng);
            WebRequest request = WebRequest.Create(req);
            WebResponse response = request.GetResponse();
            using (Stream dataStream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    dynamic obj = JsonConvert.DeserializeObject(reader.ReadToEnd());
                    result = (string)obj.results[0].formatted_address;
                }
            }

            return result;
        }


        //serialize Datastruct to json object
        public static string JsonSerialize(DataStruct dataStruct)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string result = ser.Serialize(dataStruct);
            return result;
        }

        //serialize json object to  DataStruct  
        public static DataStruct JsonDeserialize(string json)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            DataStruct result = ser.Deserialize<DataStruct>(json);
            return result;
        }

        // Resize the image to the specified width and height.
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
    }
}
