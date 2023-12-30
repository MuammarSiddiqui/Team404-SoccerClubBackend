namespace Team404_SoccerClubBackend.Config.File
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _hosting;
        public FileUpload(IWebHostEnvironment hosting)
        {
            _hosting = hosting;
        }
        public string Upload(IFormFile Request, string savepath)
        {
            try
            {
                Random random = new();
                var rnd = random.Next(1000, 10000);
                string? path = null;
                string ext = System.IO.Path.GetExtension(Request.FileName);
                var newFleName = savepath + rnd + "_" + DateTime.Now.ToString("MMddyyyyHHmmss") + ext;
                path = Path.Combine("", _hosting.ContentRootPath + "\\" + "Files\\" + savepath + "\\");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var newfilepath = Path.Combine("", _hosting.ContentRootPath + "\\" + "Files\\" + savepath + "\\" + newFleName);
                using (var stream = new FileStream(newfilepath, FileMode.Create))
                {
                    Request.CopyTo(stream);
                }
                return "Files\\" + savepath + "\\" + newFleName;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}