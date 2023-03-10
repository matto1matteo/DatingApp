//using System.ComponentModel.DataAnnotations;

using API.Extensions;

namespace API.Entities
{
    public class AppUser
    {
        // since entity framework prefer conventions over configurations, Id is the field for the primary key
        // If u want something different to be that primary key, u have to specify it via an attribute
        //
        // Example
        //
        // [Key]
        // public int TheId { get; set; }
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Photo> Photos { get; set; } = new();

        // many to many relationship for like functionality
        // This is the "conventional way" that may return some errors in some cases
        // public List<AppUser> LikedByUsers { get; set; }
        // public List<AppUser> LikedUsers { get; set; }
        public List<UserLike> LikedByUsers { get; set; } = new();
        public List<UserLike> LikedUsers { get; set; } = new();
        // for messages same as above
        public List<Message> MessagesSent { get; set; }
        public List<Message> MessagesReceived { get; set; }
    }
}