using System.ComponentModel.DataAnnotations;

namespace BWBlazorShared
{
    public class Idea
    {
        public int Id { get; set; }

        [Required]
        public string? Note { get; set; }
    }
}
