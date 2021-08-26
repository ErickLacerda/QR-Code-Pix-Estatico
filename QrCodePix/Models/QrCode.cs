using System;
using System.Drawing;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;
using ZXing.Rendering;

namespace QrCodePix.Models
{
    public class QrCode
    {
        public string GerarQRCodeLogo(string qrCode, string diretorio)
        {
            ZXing.BarcodeWriter barcodeWriter = new ZXing.BarcodeWriter();
            EncodingOptions encodingOptions = new EncodingOptions() { Width = 450, Height = 450, Margin = 0, PureBarcode = false };

            encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            barcodeWriter.Renderer = new BitmapRenderer { Foreground = Color.SeaGreen };
            barcodeWriter.Options = encodingOptions;
            barcodeWriter.Format = BarcodeFormat.QR_CODE;

            Bitmap bitmap = barcodeWriter.Write(qrCode);
            Bitmap logo = new Bitmap(diretorio + "\\imagens\\logo-pix-icone.png");
            Graphics g = Graphics.FromImage(bitmap);

            Rectangle rectangle = new Rectangle(160, 160, 130, 130);

            g.DrawImage(logo, rectangle);

            Image imageQRCode;

            imageQRCode = bitmap;

            Random r = new Random();

            string pathTemp = diretorio + "\\arquivos\\QRCode" + r.Next(000000, 999999) + ".png";
            imageQRCode.Save(pathTemp, System.Drawing.Imaging.ImageFormat.Png);

            return pathTemp;
        }
    }
}