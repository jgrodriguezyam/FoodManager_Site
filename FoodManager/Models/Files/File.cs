using System.Text.RegularExpressions;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Settings;

namespace FoodManager.Models.Files
{
    public class File
    {
        private string _href = AppSettings.FilesFolder + "Unknown.png";
        private string _source = AppSettings.FilesFolder + "Unknown.png";

        public string Type
        {
            get
            {
                if (IsImage) return "Imagen";
                if (IsPdf) return "PDF";
                if (IsTxt) return "TXT";
                if (IsVideo) return "Video";
                return "Desconocido";
            }
        }

        public string Source
        {
            get { return _source; }
        }

        public bool IsImage
        {
            get { return Regex.IsMatch(_href, @"\.(?:jpg|jpeg|gif|bmp|png)$", RegexOptions.IgnoreCase); }
        }

        public bool IsPdf
        {
            get { return Regex.IsMatch(_href, @"(.pdf)$", RegexOptions.IgnoreCase); }
        }

        public bool IsTxt
        {
            get { return Regex.IsMatch(_href, @"(.txt)$", RegexOptions.IgnoreCase); }
        }

        public bool IsVideo
        {
            get { return Regex.IsMatch(_href, @"(.mp4)$", RegexOptions.IgnoreCase); }
        }

        protected string Href
        {
            get { return _href; }
        }

        protected void ResolvePath(string path)
        {

            if (path.IsNotNullOrEmpty())
            {
                if (IsImage) _source = path;
                _href = path;
            }

            if (IsPdf) _source = AppSettings.FilesFolder + "PDF.png";
            if (IsTxt) _source = AppSettings.FilesFolder + "TXT.png";
            if (IsVideo) _source = AppSettings.FilesFolder + "Video.png";
        }
    }
}