namespace JapaneseLearning.Models;

public record UserAccountInfo
{
    public int UserId { get; set; }

    public string Username { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;
}