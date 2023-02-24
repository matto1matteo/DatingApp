//using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    // To override the name of the table creted with the ef framework
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }

        // Properties to enable non nullable contraints
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}