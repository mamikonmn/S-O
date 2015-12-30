using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageInfoExif
{
    public class PropertyTags
    {
       // private Image _image;
        private PropertyTags()
        {

        }

        //  PropertyTagTitle "9C9B"
        public static string PropertyTagGpsVer { get { return "0x0000"; } private set { } }
        public static string PropertyTagGpsLatitudeRef { get { return "0x0001"; } private set { } }
        public static string PropertyTagGpsLatitude { get { return "0x0002"; } private set { } }
        public static string PropertyTagGpsLongitudeRef { get { return "0x0003"; } private set { } }
        public static string PropertyTagGpsLongitude { get { return "0x0004"; } private set { } }
        public static string PropertyTagGpsAltitudeRef { get { return "0x0005"; } private set { } }
        public static string PropertyTagGpsAltitude { get { return "0x0006"; } private set { } }
        public static string PropertyTagGpsGpsTime { get { return "0x0007"; } private set { } }
        public static string PropertyTagGpsGpsSatellites { get { return "0x0008"; } private set { } }
        public static string PropertyTagGpsGpsStatus { get { return "0x0009"; } private set { } }
        public static string PropertyTagGpsGpsMeasureMode { get { return "0x000A"; } private set { } }
        public static string PropertyTagGpsGpsDop { get { return "0x000B"; } private set { } }
        public static string PropertyTagGpsSpeedRef { get { return "0x000C"; } private set { } }
        public static string PropertyTagGpsSpeed { get { return "0x000D"; } private set { } }
        public static string PropertyTagGpsTrackRef { get { return "0x000E"; } private set { } }
        public static string PropertyTagGpsTrack { get { return "0x000F"; } private set { } }
        public static string PropertyTagGpsImgDirRef { get { return "0x0010"; } private set { } }
        public static string PropertyTagGpsImgDir { get { return "0x0011"; } private set { } }
        public static string PropertyTagGpsMapDatum { get { return "0x0012"; } private set { } }
        public static string PropertyTagGpsDestLatRef { get { return "0x0013"; } private set { } }
        public static string PropertyTagGpsDestLat { get { return "0x0014"; } private set { } }
        public static string PropertyTagGpsDestLongRef { get { return "0x0015"; } private set { } }
        public static string PropertyTagGpsDestLong { get { return "0x0016"; } private set { } }
        public static string PropertyTagGpsDestBearRef { get { return "0x0017"; } private set { } }
        public static string PropertyTagGpsDestBear { get { return "0x0018"; } private set { } }
        public static string PropertyTagGpsDestDistRef { get { return "0x0019"; } private set { } }
        public static string PropertyTagGpsDestDist { get { return "0x001A"; } private set { } }
        public static string PropertyTagNewSubfileType { get { return "0x00FE"; } private set { } }
        public static string PropertyTagSubfileType { get { return "0x00FF"; } private set { } }
        public static string PropertyTagImageWidth { get { return "0x0100"; } private set { } }
        public static string PropertyTagImageHeight { get { return "0x0101"; } private set { } }
        public static string PropertyTagBitsPerSample { get { return "0x0102"; } private set { } }
        public static string PropertyTagCompression { get { return "0x0103"; } private set { } }
        public static string PropertyTagPhotometricInterp { get { return "0x0106"; } private set { } }
        public static string PropertyTagThreshHolding { get { return "0x0107"; } private set { } }
        public static string PropertyTagCellWidth { get { return "0x0108"; } private set { } }
        public static string PropertyTagCellHeight { get { return "0x0109"; } private set { } }
        public static string PropertyTagFillOrder { get { return "0x010A"; } private set { } }
        public static string PropertyTagDocumentName { get { return "0x010D"; } private set { } }
        public static string PropertyTagImageDescription { get { return "0x010E"; } private set { } }
        public static string PropertyTagEquipMake { get { return "0x010F"; } private set { } }
        public static string PropertyTagEquipModel { get { return "0x0110"; } private set { } }
        public static string PropertyTagStripOffsets { get { return "0x0111"; } private set { } }
        public static string PropertyTagOrientation { get { return "0x0112"; } private set { } }
        public static string PropertyTagSamplesPerPixel { get { return "0x0115"; } private set { } }
        public static string PropertyTagRowsPerStrip { get { return "0x0116"; } private set { } }
        public static string PropertyTagStripBytesCount { get { return "0x0117"; } private set { } }
        public static string PropertyTagMinSampleValue { get { return "0x0118"; } private set { } }
        public static string PropertyTagMaxSampleValue { get { return "0x0119"; } private set { } }
        public static string PropertyTagXResolution { get { return "0x011A"; } private set { } }
        public static string PropertyTagYResolution { get { return "0x011B"; } private set { } }
        public static string PropertyTagPlanarConfig { get { return "0x011C"; } private set { } }
        public static string PropertyTagPageName { get { return "0x011D"; } private set { } }
        public static string PropertyTagXPosition { get { return "0x011E"; } private set { } }
        public static string PropertyTagYPosition { get { return "0x011F"; } private set { } }
        public static string PropertyTagFreeOffset { get { return "0x0120"; } private set { } }
        public static string PropertyTagFreeByteCounts { get { return "0x0121"; } private set { } }
        public static string PropertyTagGrayResponseUnit { get { return "0x0122"; } private set { } }
        public static string PropertyTagGrayResponseCurve { get { return "0x0123"; } private set { } }
        public static string PropertyTagT4Option { get { return "0x0124"; } private set { } }
        public static string PropertyTagT6Option { get { return "0x0125"; } private set { } }
        public static string PropertyTagResolutionUnit { get { return "0x0128"; } private set { } }
        public static string PropertyTagPageNumber { get { return "0x0129"; } private set { } }
        public static string PropertyTagTransferFunction { get { return "0x012D"; } private set { } }
        public static string PropertyTagSoftwareUsed { get { return "0x0131"; } private set { } }
        public static string PropertyTagDateTime { get { return "0x0132"; } private set { } }
        public static string PropertyTagArtist { get { return "0x013B"; } private set { } }
        public static string PropertyTagHostComputer { get { return "0x013C"; } private set { } }
        public static string PropertyTagPredictor { get { return "0x013D"; } private set { } }
        public static string PropertyTagWhitePoint { get { return "0x013E"; } private set { } }
        public static string PropertyTagPrimaryChromaticities { get { return "0x013F"; } private set { } }
        public static string PropertyTagColorMap { get { return "0x0140"; } private set { } }
        public static string PropertyTagHalftoneHints { get { return "0x0141"; } private set { } }
        public static string PropertyTagTileWidth { get { return "0x0142"; } private set { } }
        public static string PropertyTagTileLength { get { return "0x0143"; } private set { } }
        public static string PropertyTagTileOffset { get { return "0x0144"; } private set { } }
        public static string PropertyTagTileByteCounts { get { return "0x0145"; } private set { } }
        public static string PropertyTagInkSet { get { return "0x014C"; } private set { } }
        public static string PropertyTagInkNames { get { return "0x014D"; } private set { } }
        public static string PropertyTagNumberOfInks { get { return "0x014E"; } private set { } }
        public static string PropertyTagDotRange { get { return "0x0150"; } private set { } }
        public static string PropertyTagTargetPrinter { get { return "0x0151"; } private set { } }
        public static string PropertyTagExtraSamples { get { return "0x0152"; } private set { } }
        public static string PropertyTagSampleFormat { get { return "0x0153"; } private set { } }
        public static string PropertyTagSMinSampleValue { get { return "0x0154"; } private set { } }
        public static string PropertyTagSMaxSampleValue { get { return "0x0155"; } private set { } }
        public static string PropertyTagTransferRange { get { return "0x0156"; } private set { } }
        public static string PropertyTagJPEGProc { get { return "0x0200"; } private set { } }
        public static string PropertyTagJPEGInterFormat { get { return "0x0201"; } private set { } }
        public static string PropertyTagJPEGInterLength { get { return "0x0202"; } private set { } }
        public static string PropertyTagJPEGRestartInterval { get { return "0x0203"; } private set { } }
        public static string PropertyTagJPEGLosslessPredictors { get { return "0x0205"; } private set { } }
        public static string PropertyTagJPEGPointTransforms { get { return "0x0206"; } private set { } }
        public static string PropertyTagJPEGQTables { get { return "0x0207"; } private set { } }
        public static string PropertyTagJPEGDCTables { get { return "0x0208"; } private set { } }
        public static string PropertyTagJPEGACTables { get { return "0x0209"; } private set { } }
        public static string PropertyTagYCbCrCoefficients { get { return "0x0211"; } private set { } }
        public static string PropertyTagYCbCrSubsampling { get { return "0x0212"; } private set { } }
        public static string PropertyTagYCbCrPositioning { get { return "0x0213"; } private set { } }
        public static string PropertyTagREFBlackWhite { get { return "0x0214"; } private set { } }
        public static string PropertyTagGamma { get { return "0x0301"; } private set { } }
        public static string PropertyTagICCProfileDescriptor { get { return "0x0302"; } private set { } }
        public static string PropertyTagSRGBRenderingIntent { get { return "0x0303"; } private set { } }
        public static string PropertyTagImageTitle { get { return "0x0320"; } private set { } }
        public static string PropertyTagResolutionXUnit { get { return "0x5001"; } private set { } }
        public static string PropertyTagResolutionYUnit { get { return "0x5002"; } private set { } }
        public static string PropertyTagResolutionXLengthUnit { get { return "0x5003"; } private set { } }
        public static string PropertyTagResolutionYLengthUnit { get { return "0x5004"; } private set { } }
        public static string PropertyTagPrintFlags { get { return "0x5005"; } private set { } }
        public static string PropertyTagPrintFlagsVersion { get { return "0x5006"; } private set { } }
        public static string PropertyTagPrintFlagsCrop { get { return "0x5007"; } private set { } }
        public static string PropertyTagPrintFlagsBleedWidth { get { return "0x5008"; } private set { } }
        public static string PropertyTagPrintFlagsBleedWidthScale { get { return "0x5009"; } private set { } }
        public static string PropertyTagHalftoneLPI { get { return "0x500A"; } private set { } }
        public static string PropertyTagHalftoneLPIUnit { get { return "0x500B"; } private set { } }
        public static string PropertyTagHalftoneDegree { get { return "0x500C"; } private set { } }
        public static string PropertyTagHalftoneShape { get { return "0x500D"; } private set { } }
        public static string PropertyTagHalftoneMisc { get { return "0x500E"; } private set { } }
        public static string PropertyTagHalftoneScreen { get { return "0x500F"; } private set { } }
        public static string PropertyTagJPEGQuality { get { return "0x5010"; } private set { } }
        public static string PropertyTagGridSize { get { return "0x5011"; } private set { } }
        public static string PropertyTagThumbnailFormat { get { return "0x5012"; } private set { } }
        public static string PropertyTagThumbnailWidth { get { return "0x5013"; } private set { } }
        public static string PropertyTagThumbnailHeight { get { return "0x5014"; } private set { } }
        public static string PropertyTagThumbnailColorDepth { get { return "0x5015"; } private set { } }
        public static string PropertyTagThumbnailPlanes { get { return "0x5016"; } private set { } }
        public static string PropertyTagThumbnailRawBytes { get { return "0x5017"; } private set { } }
        public static string PropertyTagThumbnailSize { get { return "0x5018"; } private set { } }
        public static string PropertyTagThumbnailCompressedSize { get { return "0x5019"; } private set { } }
        public static string PropertyTagColorTransferFunction { get { return "0x501A"; } private set { } }
        public static string PropertyTagThumbnailData { get { return "0x501B"; } private set { } }
        public static string PropertyTagThumbnailImageWidth { get { return "0x5020"; } private set { } }
        public static string PropertyTagThumbnailImageHeight { get { return "0x5021"; } private set { } }
        public static string PropertyTagThumbnailBitsPerSample { get { return "0x5022"; } private set { } }
        public static string PropertyTagThumbnailCompression { get { return "0x5023"; } private set { } }
        public static string PropertyTagThumbnailPhotometricInterp { get { return "0x5024"; } private set { } }
        public static string PropertyTagThumbnailImageDescription { get { return "0x5025"; } private set { } }
        public static string PropertyTagThumbnailEquipMake { get { return "0x5026"; } private set { } }
        public static string PropertyTagThumbnailEquipModel { get { return "0x5027"; } private set { } }
        public static string PropertyTagThumbnailStripOffsets { get { return "0x5028"; } private set { } }
        public static string PropertyTagThumbnailOrientation { get { return "0x5029"; } private set { } }
        public static string PropertyTagThumbnailSamplesPerPixel { get { return "0x502A"; } private set { } }
        public static string PropertyTagThumbnailRowsPerStrip { get { return "0x502B"; } private set { } }
        public static string PropertyTagThumbnailStripBytesCount { get { return "0x502C"; } private set { } }
        public static string PropertyTagThumbnailResolutionX { get { return "0x502D"; } private set { } }
        public static string PropertyTagThumbnailResolutionY { get { return "0x502E"; } private set { } }
        public static string PropertyTagThumbnailPlanarConfig { get { return "0x502F"; } private set { } }
        public static string PropertyTagThumbnailResolutionUnit { get { return "0x5030"; } private set { } }
        public static string PropertyTagThumbnailTransferFunction { get { return "0x5031"; } private set { } }
        public static string PropertyTagThumbnailSoftwareUsed { get { return "0x5032"; } private set { } }
        public static string PropertyTagThumbnailDateTime { get { return "0x5033"; } private set { } }
        public static string PropertyTagThumbnailArtist { get { return "0x5034"; } private set { } }
        public static string PropertyTagThumbnailWhitePoint { get { return "0x5035"; } private set { } }
        public static string PropertyTagThumbnailPrimaryChromaticities { get { return "0x5036"; } private set { } }
        public static string PropertyTagThumbnailYCbCrCoefficients { get { return "0x5037"; } private set { } }
        public static string PropertyTagThumbnailYCbCrSubsampling { get { return "0x5038"; } private set { } }
        public static string PropertyTagThumbnailYCbCrPositioning { get { return "0x5039"; } private set { } }
        public static string PropertyTagThumbnailRefBlackWhite { get { return "0x503A"; } private set { } }
        public static string PropertyTagThumbnailCopyRight { get { return "0x503B"; } private set { } }
        public static string PropertyTagLuminanceTable { get { return "0x5090"; } private set { } }
        public static string PropertyTagChrominanceTable { get { return "0x5091"; } private set { } }
        public static string PropertyTagFrameDelay { get { return "0x5100"; } private set { } }
        public static string PropertyTagLoopCount { get { return "0x5101"; } private set { } }
        public static string PropertyTagGlobalPalette { get { return "0x5102"; } private set { } }
        public static string PropertyTagIndexBackground { get { return "0x5103"; } private set { } }
        public static string PropertyTagIndexTransparent { get { return "0x5104"; } private set { } }
        public static string PropertyTagPixelUnit { get { return "0x5110"; } private set { } }
        public static string PropertyTagPixelPerUnitX { get { return "0x5111"; } private set { } }
        public static string PropertyTagPixelPerUnitY { get { return "0x5112"; } private set { } }
        public static string PropertyTagPaletteHistogram { get { return "0x5113"; } private set { } }
        public static string PropertyTagCopyright { get { return "0x8298"; } private set { } }
        public static string PropertyTagExifExposureTime { get { return "0x829A"; } private set { } }
        public static string PropertyTagExifFNumber { get { return "0x829D"; } private set { } }
        public static string PropertyTagExifIFD { get { return "0x8769"; } private set { } }
        public static string PropertyTagICCProfile { get { return "0x8773"; } private set { } }
        public static string PropertyTagExifExposureProg { get { return "0x8822"; } private set { } }
        public static string PropertyTagExifSpectralSense { get { return "0x8824"; } private set { } }
        public static string PropertyTagGpsIFD { get { return "0x8825"; } private set { } }
        public static string PropertyTagExifISOSpeed { get { return "0x8827"; } private set { } }
        public static string PropertyTagExifOECF { get { return "0x8828"; } private set { } }
        public static string PropertyTagExifVer { get { return "0x9000"; } private set { } }
        public static string PropertyTagExifDTOrig { get { return "0x9003"; } private set { } }
        public static string PropertyTagExifDTDigitized { get { return "0x9004"; } private set { } }
        public static string PropertyTagExifCompConfig { get { return "0x9101"; } private set { } }
        public static string PropertyTagExifCompBPP { get { return "0x9102"; } private set { } }
        public static string PropertyTagExifShutterSpeed { get { return "0x9201"; } private set { } }
        public static string PropertyTagExifAperture { get { return "0x9202"; } private set { } }
        public static string PropertyTagExifBrightness { get { return "0x9203"; } private set { } }
        public static string PropertyTagExifExposureBias { get { return "0x9204"; } private set { } }
        public static string PropertyTagExifMaxAperture { get { return "0x9205"; } private set { } }
        public static string PropertyTagExifSubjectDist { get { return "0x9206"; } private set { } }
        public static string PropertyTagExifMeteringMode { get { return "0x9207"; } private set { } }
        public static string PropertyTagExifLightSource { get { return "0x9208"; } private set { } }
        public static string PropertyTagExifFlash { get { return "0x9209"; } private set { } }
        public static string PropertyTagExifFocalLength { get { return "0x920A"; } private set { } }
        public static string PropertyTagExifMakerNote { get { return "0x927C"; } private set { } }
        public static string PropertyTagExifUserComment { get { return "0x9286"; } private set { } }
        public static string PropertyTagExifDTSubsec { get { return "0x9290"; } private set { } }
        public static string PropertyTagExifDTOrigSS { get { return "0x9291"; } private set { } }
        public static string PropertyTagExifDTDigSS { get { return "0x9292"; } private set { } }
        public static string PropertyTagExifFPXVer { get { return "0xA000"; } private set { } }
        public static string PropertyTagExifColorSpace { get { return "0xA001"; } private set { } }
        public static string PropertyTagExifPixXDim { get { return "0xA002"; } private set { } }
        public static string PropertyTagExifPixYDim { get { return "0xA003"; } private set { } }
        public static string PropertyTagExifRelatedWav { get { return "0xA004"; } private set { } }
        public static string PropertyTagExifInterop { get { return "0xA005"; } private set { } }
        public static string PropertyTagExifFlashEnergy { get { return "0xA20B"; } private set { } }
        public static string PropertyTagExifSpatialFR { get { return "0xA20C"; } private set { } }
        public static string PropertyTagExifFocalXRes { get { return "0xA20E"; } private set { } }
        public static string PropertyTagExifFocalYRes { get { return "0xA20F"; } private set { } }
        public static string PropertyTagExifFocalResUnit { get { return "0xA210"; } private set { } }
        public static string PropertyTagExifSubjectLoc { get { return "0xA214"; } private set { } }
        public static string PropertyTagExifExposureIndex { get { return "0xA215"; } private set { } }
        public static string PropertyTagExifSensingMethod { get { return "0xA217"; } private set { } }
        public static string PropertyTagExifFileSource { get { return "0xA300"; } private set { } }
        public static string PropertyTagExifSceneType { get { return "0xA301"; } private set { } }
        public static string PropertyTagExifCfaPattern { get { return "0xA302"; } private set { } }
        public static string PropertyTagTitle { get { return "0x9C9B"; } private set { } }

        public static string PropertyTag { get { return "0x9C9E"; } private set { } }
        public static string PropertyTagSubject { get { return "0x9C9F"; } private set { } }
        public static string PropertyTagComment { get { return "0x9C9C"; } private set { } }

    }
}
