using System.Text.Json.Serialization;

namespace DotnetDapper.Models
{
    public class CreateUserRequestDTO
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        [JsonIgnore]
        public bool Active { get; set; } = true;
        [JsonIgnore]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
