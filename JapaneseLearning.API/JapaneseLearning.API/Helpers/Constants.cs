namespace JapaneseLearning.Helpers;

public static class CustomClaimTypes {
    public const string UserId = "userId";
}
    public static class CustomContextItems
{

    public const string UserId = "userId";
}

public static class ConfigKey
{
    public const string JwtSecret = "JWT_SECRET";

    public const string ConnectionString = "CONNECTION_STRING";

    public const string EmailConnectionString = "EMAIL_CONNECTION_STRING";

    public const string StorageConnectionString = "STORAGE_CONNECTION_STRING";

    public const string AvatarContainerName = "AVATAR_CONTAINER_NAME";

    public const string BaseSpaUrl = "BASE_SPA_URL";

    public const string CorsAllowOrigin = "CORS_ALLOW_ORIGIN";
}