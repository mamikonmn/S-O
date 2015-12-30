using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace ImageInfoExif
{
    public class Program
    {


        static void Main(string[] args)
        {

            string jpg = @"C:\Users\Social Objects\Desktop\pimgpsh_fullsize_distr.jpg";// pimgpsh_fullsize_distr.jpg";    //pimgpsh_fullsize_distr.jpg";
            Image image = Image.FromFile(jpg);
            
    
            
        }
        private static UInt16[] ByteArrayToUInt16tArray(byte[] bytes)
        {

            var ints = bytes.TakeWhile((b, i) => i % 2 == 0).Select((b, i) => BitConverter.ToUInt16(bytes, i));

            if (bytes.Length % 2 == 1)
            {
                ints = ints.Union(new[] { BitConverter.ToUInt16(new byte[] { bytes[bytes.Length - 1], 0 }, 0) });
            }
            return ints.ToArray();
        }

        //private  static short[] ByteArrayToShortArray( byte[] bytes)
        //{

        //    var ints = bytes.TakeWhile((b, i) => i % 2 == 0).Select((b, i) => BitConverter.ToInt16(bytes, i));

        //    if (bytes.Length % 2 == 1)
        //    {
        //        ints = ints.Union(new[] { BitConverter.ToInt16(new byte[] { bytes[bytes.Length - 1], 0 }, 0) });
        //    }
        //    return ints.ToArray();
        //}

        private static UInt32[] ByteArrayToUInt32Array(byte[] bytes)
        {

            var ints = bytes.TakeWhile((b, i) => i % 4 == 0).Select((b, i) => BitConverter.ToUInt32(bytes, i));

            if (bytes.Length % 4 == 1)
            {
                ints = ints.Union(new[] { BitConverter.ToUInt32(new byte[] { bytes[bytes.Length - 1], 0 }, 0) });
            }
            return ints.ToArray();
        }
        private static int[] ByteArrayToLongArray(byte[] bytes)
        {

            var ints = bytes.TakeWhile((b, i) => i % 8 == 0).Select((b, i) => BitConverter.ToInt32(bytes, i));

            if (bytes.Length % 8 == 1)
            {
                ints = ints.Union(new[] { BitConverter.ToInt32(new byte[] { bytes[bytes.Length - 1], 0 }, 0) });
            }
            return ints.ToArray();
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

        private static Object ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);
            return obj;
        }
        public static string DynamicF6(object obj)
        {
            if (obj is int || obj is short || obj is  long || obj is uint || obj is ushort || obj is ulong)
            {
                return   ((ulong)obj).ToString();
            }

            if (obj is int[] )//|| obj is short[] || obj is long[] ||obj is  string[] || obj is char[])
            {
                return string.Join(",", (int[])obj);
            }
            if (obj is long[])//|| obj is short[] || obj is long[] ||obj is  string[] || obj is char[])
            {
                return string.Join(",", (long[])obj);
            }
            if (obj is short[])//|| obj is short[] || obj is long[] ||obj is  string[] || obj is char[])
            {
                return string.Join(",", (short[])obj);
            }
            if (obj is char[])//|| obj is short[] || obj is long[] ||obj is  string[] || obj is char[])
            {
                return  new string((char[])obj);
            }
            if (obj is string[])
            {
                return string.Join(",", (string[])obj);
            }
            if (obj is string )
            {
                return (string)obj;
            }
            if (obj is char)
            {
               return ((char)obj).ToString();
            }
            if (obj is float || obj is double)
            {
                return ((double)obj).ToString();
            }
            return null; 
        }
        // functia stana image veradarcni string  anun  - value 
        public static void GetNameValue(Image image)
        {
            PropertyItem[] propItems = image.PropertyItems;
         
            for (int i = 0; i < propItems.Length; i++)
            {


                //if (propItems[i].Type == 1)
                //{
                //    ASCIIEncoding encoding = new ASCIIEncoding();
                //    PropertyItem item;
                //    try
                //    {
                //        if (propItems[i].Id == 20507 || propItems[i].Id == 34675 || propItems[i].Id == 0)
                //            continue;
                //        item = image.GetPropertyItem(propItems[i].Id);
                //    }
                //    catch (Exception)
                //    {
                //        return;
                //    }
                //    Console.WriteLine("{0}   0x{1}   {2}",propItems[i].Id,propItems[i].Id.ToString("X"), encoding.GetString(item.Value.Where(ie => ie != 0).ToArray()));
                //}

                //if (propItems[i].Type == 2)
                //{
                //    ASCIIEncoding encoding = new ASCIIEncoding();
                //    PropertyItem item;
                //    try
                //    {
                //        //if (propItems[i].Id == 20507 || propItems[i].Id == 34675 || propItems[i].Id == 0)
                //        //    continue;
                //        item = image.GetPropertyItem(propItems[i].Id);
                //    }
                //    catch (Exception)
                //    {
                //        return;
                //    }
                //    Console.WriteLine("{0}   0x{1}   {2}", propItems[i].Id, propItems[i].Id.ToString("X"), encoding.GetString(item.Value.Where(ie => ie != 0).ToArray()));
                //}

                //if (propItems[i].Type == 3)
                //{
                //    ASCIIEncoding encoding = new ASCIIEncoding();
                //    PropertyItem item;
                //    try
                //    {
                //        //if (propItems[i].Id == 20507 || propItems[i].Id == 34675 || propItems[i].Id == 0)
                //        //    continue;
                //        item = image.GetPropertyItem(propItems[i].Id);
                //    }
                //    catch (Exception)
                //    {
                //        return;
                //    }
                //    UInt16[] array = ByteArrayToUInt16tArray(propItems[i].Value);
                //    var arrayToStr = string.Join(",", array);
                //    Console.WriteLine("{0}   0x{1}   {2}", propItems[i].Id, propItems[i].Id.ToString("X"), arrayToStr);
                //}

                //if (propItems[i].Type == 4)
                //{
                //    ASCIIEncoding encoding = new ASCIIEncoding();
                //    PropertyItem item;
                //    try
                //    {
                //        //if (propItems[i].Id == 20507 || propItems[i].Id == 34675 || propItems[i].Id == 0)
                //        //    continue;
                //        item = image.GetPropertyItem(propItems[i].Id);
                //    }
                //    catch (Exception)
                //    {
                //        return;
                //    }
                //    UInt32[] array = ByteArrayToUInt32Array(propItems[i].Value);
                //    var arrayToStr = string.Join(",", array);
                //    Console.WriteLine("{0}   0x{1}   {2}", propItems[i].Id, propItems[i].Id.ToString("X"), arrayToStr);
                //}

                //if (propItems[i].Type == 5)
                //{


                //}

                //if (propItems[i].Type == 6)
                //{
                //    object o = ByteArrayToObject(propItems[i].Value);
                //    string result = DynamicF6(o);

                //    Console.WriteLine("{0}   0x{1}   {2}", propItems[i].Id,
                //        propItems[i].Id.ToString("X"), result);
                //}

                //if (propItems[i].Type == 7)
                //{
                //    ASCIIEncoding encoding = new ASCIIEncoding();
                //    PropertyItem item;
                //    try
                //    {

                //        item = image.GetPropertyItem(propItems[i].Id);
                //        int[] array = ByteArrayToIntArray(propItems[i].Value);
                //        var arrayToStr = string.Join(",", array);


                //        string strings = new ASCIIEncoding().GetString(propItems[i].Value.Where(id => id != 0).ToArray());
                //        Console.WriteLine("{0}   0x{1}   {2}", propItems[i].Id,
                //            propItems[i].Id.ToString("X"), String.Join(",", strings));
                //    }
                //    catch (Exception)
                //    {

                //    }
                //}

                //if (propItems[i].Type == 10)
                //{
                //    ASCIIEncoding encoding = new ASCIIEncoding();
                //    PropertyItem item;
                //    try
                //    {
                //        //if (propItems[i].Id == 20507 || propItems[i].Id == 34675 || propItems[i].Id == 0)
                //        //    continue;
                //        //item = image.GetPropertyItem(propItems[i].Id);
                //        //int[] array = ByteArrayToIntArray(propItems[i].Value);
                //        //var arrayToStr = string.Join(",", array);
                //        string strings = new ASCIIEncoding().GetString(propItems[i].
                //            Value.Where(id => id != 0).ToArray());
                //        Console.WriteLine("{0}   0x{1}   {2}", propItems[i].Id,
                //            propItems[i].Id.ToString("X"), strings);
                //    }
                //    catch (Exception)
                //    {

                //    }
                //}


            }

        }

        public static object ReadBytes(byte[] bytes, Type objectType)
        {
            if (objectType == typeof(bool)) return bytes[0] == (byte)1 ? true : false;
            else if (objectType == typeof(byte)) return bytes[0];
            else if (objectType == typeof(int)) return BitConverter.ToInt32(bytes, 0);
            else if (objectType == typeof(long)) return BitConverter.ToInt64(bytes, 0);
            else if (objectType == typeof(double)) return BitConverter.ToDouble(bytes, 0);
            else if (objectType == typeof(sbyte)) return (sbyte)bytes[0];
            else if (objectType == typeof(short)) return BitConverter.ToInt16(bytes, 0);
            else if (objectType == typeof(ushort)) return BitConverter.ToUInt16(bytes, 0);
            else if (objectType == typeof(uint)) return BitConverter.ToUInt32(bytes, 0);
            else if (objectType == typeof(ulong)) return BitConverter.ToUInt64(bytes, 0);
            else if (objectType == typeof(float)) return BitConverter.ToSingle(bytes, 0);
            else if (objectType == typeof(char)) return BitConverter.ToChar(bytes, 0);
            else if (objectType == typeof(IntPtr))
                throw new Exception("IntPtr type is not supported.");

            throw new Exception("Could not retrieve bytes from the object type " + objectType.FullName + ".");
        }


    }
}
