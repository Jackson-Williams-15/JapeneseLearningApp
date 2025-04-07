namespace JapaneseLearning.Services;

using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using JapaneseLearning.Interfaces;
using JapaneseLearning.Models;
using JapaneseLearning.Data;
using JapaneseLearning.Helpers;
using Konscious.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

public class AccountService : IUserService
{
    private readonly LearningAppContext _context;
    private readonly IConfiguration _configuration;

    public AccountService(LearningAppContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<Users?> Authenticate(Credentials credentials)
    {
          var user = await _context.Users.Where(u => u.NormalizedUsername == credentials.Username.ToUpper()).FirstOrDefaultAsync();

        if (user?.PasswordHash == HashPassword(credentials.Password))
        {
            // add check if the account is confirmed later

            return user;
        }
        else
        {
            return null;
        }
    }

    public Task<Authentication?> ConfirmAccount(int userId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUser(int userId, Credentials credentials)
    {
        throw new NotImplementedException();
    }

    public async Task<Authentication?> GetAuthenticationInfo(Credentials credentials)
    {
        var user = await Authenticate(credentials);
        if (user is null)
        {
            return null;
        }

        return AuthenticationHelper.CreateAuthInfo(_configuration, DateTime.UtcNow.AddDays(1), user.Id);
    }

    public UserAccountInfo GetUserAccountInfo(int userId)
    {
         var userCredentials = _context.Users.Find(userId);

        if (userCredentials is null)
        {
            return null;
        }

        return new UserAccountInfo()
        {
            UserId = userCredentials.Id,
            Username = userCredentials.Username,
            PasswordHash = userCredentials.PasswordHash
        };
    }

    public async Task<Users> GetUserById(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            throw new KeyNotFoundException("User not found");
        return user;
    }

    public async Task<Users> GetUserByUsername(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
        if (user == null)
            throw new KeyNotFoundException("User not found");
        return user;
    }

    public string HashPassword(string password)
    {
        var argon2 = new Argon2i(Encoding.UTF8.GetBytes(password)) {
            Iterations = 4,
            MemorySize = 65536,
            DegreeOfParallelism = 2
        };
        byte[] passwordBytes = argon2.GetBytes(128);
        return Convert.ToBase64String(passwordBytes);
    }

    public async Task<Users> RegisterUser(Credentials credentials)
    {
         var queryUser = _context.Users.Where(u => u.NormalizedUsername == credentials.Username.ToUpper());
        if (queryUser.FirstOrDefault() is not null)
        {
            throw new Exception("A user with the same username already exists.");
        }

        var duplicateEmail = _context.Users.Where(u => u.NormalizedEmail == credentials.Email.ToUpper()).FirstOrDefault();
        if (duplicateEmail is not null)
        {
            throw new Exception("User with email already exists");
        }

        if (string.IsNullOrEmpty(credentials.Username) || string.IsNullOrEmpty(credentials.Password))
            throw new ValidationException("Username and password are required");

        if (credentials.Password.Length < 8 || !credentials.Password.Any(c => char.IsDigit(c) || char.IsPunctuation(c)))
            throw new ValidationException("Password must be at least 8 characters long, contain at least one digit, and at least one special character");
        
        _context.Users.Add(new Users()
        {
            Username = credentials.Username,
            Email = credentials.Email,
            PasswordHash = HashPassword(credentials.Password)
        });
        await _context.SaveChangesAsync();

        var createdUser = queryUser.First();

        // Implement sending email service and call here
        /* 
        
        */
        
        return createdUser;
        
    }

    public Task UpdateEmail(int userId, string newEmail)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePassword(int userId, string newPassword)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUsername(int userId, string newUsername)
    {
        throw new NotImplementedException();
    }
}