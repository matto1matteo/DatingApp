//using System.ComponentModel.DataAnnotations;

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
    }
}