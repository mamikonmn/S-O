using System;
using System.Runtime.Serialization;

namespace ImageInfoExif
{
    [Serializable]
    public struct DataStruct
    {
        //Discription

        public string Name { get; set; } //+
      
        public string TotalSize { get; set; } //+
        public string Dimension { get; set; }  //+
       
        public string Title { get; set; } //+
     
        public string DataCreated { get; set; }  //+

        public string DataModified { get; set; }

        public string DateDigit { get; set; }  // ?
      
        public string SoftwareUsed { get; set; }//+
        public string Tag { get; set; }//+
      
        public string Comment { get; set; } //+
       
        public string CameraManufacturer { get; set; } //+
     
        public string Subject { get; set; }//+
     
        public string CameraModel { get; set; }//+
     
        public string Format { get; set; } // +
       
        public double?  GPSLongitude { get; set; }
        
        public double? GPSLatitude { get; set; }

         public  string Aperture { get; set; }
         public   string PropertyTagExifISOSpeed { get; set; }
         public  string PropertyTagExifShutterSpeed { get; set; }
         public  string PropertyTagOrientation { get; set; }
         public  string PropertyTagExifFlash { get; set; }
         public  string ImageAddress { get; set; }

        //Brightbnes
        // PropertyTagExifAperture

        // PropertyTagExifShutterSpeed

        // PropertyTagExifFlash

        // PropertyTagOrientation
    }
}
