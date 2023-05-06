using System.ComponentModel.DataAnnotations;

namespace Notes.DBModels
{
    public class Note
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
