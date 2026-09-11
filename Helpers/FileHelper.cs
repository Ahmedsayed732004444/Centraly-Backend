namespace Centraly.Api.Helpers;

public class FileHelper
{
    public async static Task<string?> UploadeFileAsync(IFormFile file, string location, IWebHostEnvironment env, IHttpContextAccessor accessor)
    {
        if (file is null)
            return null;
        var path = Path.Combine(env.WebRootPath, location);

        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        var extention = Path.GetExtension(file.FileName);
        var fileName = Guid.NewGuid().ToString().Replace("-", string.Empty);

        var fullPath = Path.Combine(path, fileName + extention);

        using (FileStream stream = new FileStream(fullPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);

        }
        var origin = accessor.HttpContext?.Request;

        return $"{origin.Scheme}://{origin.Host}/{location}/{fileName}{extention}";
    }

    //DeleteFile عمليه سريعه جدا علي الكورس
    public static void DeleteFile(string oldPath, string location, IWebHostEnvironment env)
    {
        if (string.IsNullOrEmpty(oldPath))
            return;

        var fileName = Path.GetFileName(new Uri(oldPath).LocalPath);
        var path = Path.Combine(env.WebRootPath, location, fileName);

        if (File.Exists(path))
            File.Delete(path);
    }
}
