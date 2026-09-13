using System;
using System.Drawing;
using System.IO;

namespace Altivo.Services
{
    public class InspirationImageService
    {
        private const string FileName = "inspiration-image.bin";

        private static string GetImagePath()
        {
            var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Altivo");
            return Path.Combine(folder, FileName);
        }

        public bool HasSavedImage()
        {
            return File.Exists(GetImagePath());
        }

        public Image Load()
        {
            try
            {
                var path = GetImagePath();
                if (!File.Exists(path))
                {
                    return null;
                }

                using (var image = Image.FromFile(path))
                {
                    return new Bitmap(image);
                }
            }
            catch
            {
                return null;
            }
        }

        public Image Save(string sourcePath)
        {
            try
            {
                var path = GetImagePath();
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.Copy(sourcePath, path, true);

                using (var image = Image.FromFile(path))
                {
                    return new Bitmap(image);
                }
            }
            catch
            {
                return null;
            }
        }

        public void Reset()
        {
            var path = GetImagePath();
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
