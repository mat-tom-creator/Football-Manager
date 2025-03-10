namespace FootballManager.Core.Interfaces
{
    public interface IUserAuthenticationService
    {
        bool Authenticate(string username, string password);
        bool CreateUser(string username, string password);
    }
}