namespace JapaneseLearning.Helpers;
using JapaneseLearning.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
public static class AuthenticationHelper
{

    public static Authentication CreateAuthInfo(IConfiguration configuration, DateTime expires, int userId)
    {
        // Get the secret key from the config
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetJwtSecretFromConfig()));
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        List<Claim> claims = new()
        {
            new Claim(CustomClaimTypes.UserId, userId.ToString())
        };

        var tokenOptions = new JwtSecurityToken(signingCredentials: signingCredentials, expires: expires, claims: claims);

        string token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return new Authentication(token, tokenOptions.ValidTo);
    }

    private static string GetJwtSecretFromConfig(this IConfiguration configuration)
    {
        return configuration[ConfigKey.JwtSecret] ?? string.Empty;
    }
}