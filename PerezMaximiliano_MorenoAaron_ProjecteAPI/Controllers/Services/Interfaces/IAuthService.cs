namespace PerezMaximiliano_MorenoAaron_ProjecteAPI.Controllers.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string email, string password);
    }
}
