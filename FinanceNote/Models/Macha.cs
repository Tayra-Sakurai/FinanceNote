using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceNote.Models
{
    [Table("Macha")]
    public class Macha
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "日時")]
        public DateTime Time { get; set; }

        [Required]
        [Display(Name = "内容")]
        public string? Title { get; set; }

        [Required]
        [Display(Name = "お小遣い")]
        public decimal Cash { get; set; }
    }
}
