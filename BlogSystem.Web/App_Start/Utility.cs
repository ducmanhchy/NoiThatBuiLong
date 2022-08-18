using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using System;
using System.IO;
using System.Web;

namespace BlogSystem.Web.App_Start
{
    public static class Utility
    {
        public static void removeFile(string file)
        {
            if (File.Exists(file))
            {
                File.Delete(file);
            }
        }
    }

    public class ImageUpload
    {
        // set default size here
        public int Width { get; set; }

        public int Height { get; set; }

        // folder for the upload, you can put this in the web.config
        private readonly string UploadPath = "~/UploadedFiles/";

        public ImageResult RenameUploadFile(HttpPostedFileBase file, Int32 counter = 0)
        {
            var FileName = Path.GetFileNameWithoutExtension(file.FileName);
            string FileExtension = Path.GetExtension(file.FileName);
            string prepend = DateTime.Now.ToString("yyyyMMdd");
            string finalFileName = FileName + "_" + prepend + "_" + ((counter).ToString()) + FileExtension;
            if (File.Exists (HttpContext.Current.Request.MapPath(UploadPath + finalFileName)))
            {
                //file exists => add country try again
                return RenameUploadFile(file, ++counter);
            }
            //file doesn't exist, upload item but validate first
            return UploadFile(file, finalFileName);
        }

        private ImageResult UploadFile(HttpPostedFileBase file, string fileName)
        {
            ImageResult imageResult = new ImageResult { Success = true, ErrorMessage = null };

            var path = Path.Combine(HttpContext.Current.Request.MapPath(UploadPath), fileName);
            string extension = Path.GetExtension(file.FileName);

            //make sure the file is valid
            if (!ValidateExtension(extension))
            {
                imageResult.Success = false;
                imageResult.ErrorMessage = "Invalid Extension";
                return imageResult;
            }

            try
            {
                file.SaveAs(path);
                Image imgOriginal = Image.FromFile(path);

                //pass in whatever value you want
                Image imgActual = Scale(imgOriginal);
                imgOriginal.Dispose();
                imgActual.Save(path);
                imgActual.Dispose();

                imageResult.ImageName = fileName;

                return imageResult;
            }
            catch (Exception ex)
            {
                imageResult.Success = false;
                imageResult.ErrorMessage = ex.Message;
                return imageResult;
            }
        }

        private bool ValidateExtension(string extension)
        {
            extension = extension.ToLower();
            switch (extension)
            {
                case ".jpg":
                    return true;
                case ".png":
                    return true;
                case ".gif":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }

        private Image Scale(Image imgPhoto)
        {
            float sourceWidth = imgPhoto.Width;
            float sourceHeight = imgPhoto.Height;
            float destHeight = 0;
            float destWidth = 0;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            if (Width == 0 && Height == 0)
            {
                destWidth = sourceWidth;
                destHeight = sourceHeight;
            }
            else if (Width != 0 && Height != 0)
            {
                destWidth = Width;
                destHeight = Height;
            }
            else if (Height != 0)
            {
                destWidth = (float)(Height * sourceWidth) / sourceHeight;
                destHeight = Height;
            }
            else
            {
                destWidth = Width;
                destHeight = (float)(sourceHeight * Width / sourceWidth);
            }

            Bitmap bmPhoto = new Bitmap((int)destWidth, (int)destHeight, PixelFormat.Format32bppPArgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, (int)destWidth, (int)destHeight),
                new Rectangle(sourceX, sourceY, (int)sourceWidth, (int)sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }
    }
    public class ImageResult
    {
        public bool Success { get; set; }
        public string ImageName { get; set; }
        public string ErrorMessage { get; set; }
    }
}