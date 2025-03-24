namespace JapaneseLearning.Models;

public record Authentication
{
    public Authentication(string token, DateTime expiresAt)
    {
        Token = token;
        ExpiresAt = expiresAt;
    }

    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
}