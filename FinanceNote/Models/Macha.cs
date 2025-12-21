using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceNote.Models
{
    [Table("Macha")]
    public class Macha
    {
        [Required(ErrorMessage = "{0}は必須です．")]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0}は必須です．")]
        [Display(Name = "日時")]
        public DateTime Time { get; set; }

        [Required(ErrorMessage = "{0}は必須です．")]
        [Display(Name = "内容")]
        public string? Event { get; set; }

        [Required(ErrorMessage = "{0}は必須です．")]
        [Display(Name = "お小遣い")]
        public decimal Cash { get; set; }
    }
}
