using System.ComponentModel.DataAnnotations;

namespace SkillProfiCRM.Models
{
    public class MenuButton
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Key { get; set; } // Ключ для идентификации кнопки

        [Required]
        public string Text { get; set; } // Текст кнопки
    }
}
