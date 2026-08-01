using Core.Model;

namespace Core.Dto.User;

public class UserResponse
{
    public required string UserId { get; set; }
    public string? Email { get; set; }
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ProfileImageUrl { get; set; }
    public List<DateOnly> UserStreaks { get; set; } = [];
    public DeckOption DeckOption { get; set; }
    public List<UserAiProvider> AiProviders { get; set; } = [];

    // The Implicit Converter
    public static implicit operator UserResponse(Model.User user)
    {
        return new UserResponse
        {
            AiProviders = user.AiProviders,
            DeckOption = user.DeckOption,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            ProfileImageUrl = user.ProfileImageUrl,
            UserId = user.Id,
            UserName = user.UserName,
            UserStreaks = user.UserStreaks,
        };
    }
}