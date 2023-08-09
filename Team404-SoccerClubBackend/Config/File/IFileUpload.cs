namespace Team404_SoccerClubBackend.Config.File
{
    public interface IFileUpload
    {
        string Upload(IFormFile Request, string savepath);
    }
}
