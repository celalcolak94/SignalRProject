using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace SignalRWebUI.Controllers
{
    public class QRCodeController : Controller
    {
        [HttpGet]
        public IActionResult CreateQrCode()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateQrCode(string value)
        {
            if (value != null)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    QRCodeGenerator createQRCode = new QRCodeGenerator();
                    QRCodeGenerator.QRCode squareCode = createQRCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
                    using (Bitmap image = squareCode.GetGraphic(10))
                    {
                        image.Save(memoryStream, ImageFormat.Png);
                        ViewBag.QrCodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
            }
            return View();
        }


        //public IActionResult ReadQrCode()
        //{
        //    return View();
        //}

        //public IActionResult ReadQrCode(string imageData)
        //{
        //    try
        //    {
        //        // Convert Base64 string to byte array
        //        byte[] bytes = Convert.FromBase64String(imageData);

        //        // Convert byte array to Bitmap
        //        using (MemoryStream ms = new MemoryStream(bytes))
        //        {
        //            Bitmap bitmap = (Bitmap)Bitmap.FromStream(ms);

        //            // Decode QR code
        //            var reader = new BarcodeReader();
        //            var result = reader.Decode(bitmap);

        //            if (result != null)
        //            {
        //                ViewBag.QRCodeText = result.Text;
        //            }
        //            else
        //            {
        //                ViewBag.ErrorMessage = "QR code not found.";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.ErrorMessage = $"Internal server error: {ex.Message}";
        //    }

        //    return View("Index");
        //}
    }
}

