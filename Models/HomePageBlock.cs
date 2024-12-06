using System.ComponentModel.DataAnnotations;

namespace SkillProfiCRM.Models
{
    public class HomePageBlock
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Content { get; set; }
    }
}
