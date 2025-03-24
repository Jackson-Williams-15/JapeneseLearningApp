using JapaneseLearning.Models;
namespace JapaneseLearning.Interfaces;

public interface IUserService {
    Task<Users> GetUserById(int id);
    Task<Users> GetUserByUsername(string username);
    string HashPassword(string password);
    Task<Users> RegisterUser(Credentials credentials);
    Task DeleteUser(int userId, Credentials credentials);
    Task UpdatePassword(int userId, string newPassword);

    Task UpdateUsername(int userId, string newUsername);
    Task<Authentication?> GetAuthenticationInfo(Credentials credentials); 
    UserAccountInfo GetUserAccountInfo(int userId);
    Task UpdateEmail(int userId, string newEmail);
    Task<Authentication?> ConfirmAccount(int userId);
    Task<Users?> Authenticate(Credentials credentials);
}