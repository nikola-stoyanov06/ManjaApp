using ManjaApp.Data.Entities;

namespace ManjaApp.Web.Utils
{
    public static class FileUpload
    {
        public static async Task<string> UploadAsync(IFormFile pictureUpload, string root)
        {
            var extension = Path.GetExtension(pictureUpload.FileName);
            var name = Guid.NewGuid().ToString();
            var newName = $"{name}{extension}";
            var filePath = Path.Combine(root, "uploads",
                newName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await pictureUpload.CopyToAsync(stream);
            }
            return newName;
        }
    }
}
