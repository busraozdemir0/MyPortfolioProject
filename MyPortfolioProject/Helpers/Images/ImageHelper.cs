using MyPortfolioProject.Models;

namespace MyPortfolioProject.Helpers.Images
{
    public class ImageHelper : IImageHelper
    {
        private readonly string _wwwroot;
        private readonly IWebHostEnvironment _environment;
        private const string imgFolder = "images";
        public ImageHelper(IWebHostEnvironment environment)
        {
            _environment = environment;
            _wwwroot = environment.WebRootPath;
        }
        public async Task<ImageUploadedModel> Upload(string name, IFormFile imageFile)
        {
            if (!Directory.Exists($"{_wwwroot}/{imgFolder}")) // Eger belirtilen dizin yoksa
                Directory.CreateDirectory($"{_wwwroot}/{imgFolder}"); // Bu dizini olustur

            string oldFileName = Path.GetFileNameWithoutExtension(imageFile.FileName); // Uzantisi olmadan resim adi
            string fileExtension = Path.GetExtension(imageFile.FileName); // Resmin uzantisi

            name = ReplaceInvalidChars(name); // Resim ismindeki ozel ve turkce karakterleri degistirecek olan fonksiyon

            DateTime dateTime = DateTime.Now;

            string newFileName = $"{name}_{dateTime.Millisecond}{fileExtension}"; // Ayni resim adlari olmamasi icin suanki tarihin mili saniye bilgisiyle isim olusturuldu

            var path = Path.Combine($"{_wwwroot}/{imgFolder}", newFileName);

            await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write,
                                                                            FileShare.None, 1024 * 1024, useAsync: false);
            await imageFile.CopyToAsync(stream);
            await stream.FlushAsync();

            string message = $"{newFileName} isimli resim başarıyla eklendi.";

            return new ImageUploadedModel()
            {
                FullName = $"{newFileName}"
            };
        }
        public void Delete(string imageName)
        {
            var fileToDelete = Path.Combine($"{_wwwroot}/{imgFolder}/{imageName}");
            if (File.Exists(fileToDelete)) // Silinecek resim gercekten var mi
                File.Delete(fileToDelete);
        }

        // Turkce veya ozel karakterleri degistirecek olan fonksiyon
        public static string ReplaceInvalidChars(string fileName)
        {
            return fileName.Replace("İ", "I")
                 .Replace("ı", "i")
                 .Replace("Ğ", "G")
                 .Replace("ğ", "g")
                 .Replace("Ü", "U")
                 .Replace("ü", "u")
                 .Replace("ş", "s")
                 .Replace("Ş", "S")
                 .Replace("Ö", "O")
                 .Replace("ö", "o")
                 .Replace("Ç", "C")
                 .Replace("ç", "c")
                 .Replace("é", "")
                 .Replace("!", "")
                 .Replace("'", "")
                 .Replace("^", "")
                 .Replace("+", "")
                 .Replace("%", "")
                 .Replace("/", "")
                 .Replace("(", "")
                 .Replace(")", "")
                 .Replace("=", "")
                 .Replace("?", "")
                 .Replace("_", "")
                 .Replace("*", "")
                 .Replace("æ", "")
                 .Replace("ß", "")
                 .Replace("@", "")
                 .Replace("€", "")
                 .Replace("<", "")
                 .Replace(">", "")
                 .Replace("#", "")
                 .Replace("$", "")
                 .Replace("½", "")
                 .Replace("{", "")
                 .Replace("[", "")
                 .Replace("]", "")
                 .Replace("}", "")
                 .Replace(@"\", "")
                 .Replace("|", "")
                 .Replace("~", "")
                 .Replace("¨", "")
                 .Replace(",", "")
                 .Replace(";", "")
                 .Replace("`", "")
                 .Replace(".", "")
                 .Replace(":", "")
                 .Replace(" ", "");
        }
    }
}

    


