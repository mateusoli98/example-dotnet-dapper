namespace DotnetDapper.Models;

public class UserResponseDTO
{
    public long Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool Actiove { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
