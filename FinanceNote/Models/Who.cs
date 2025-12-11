using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceNote.Models
{
    [Table("Who")]
    public class Who
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
        [Display(Name = "現金")]
        public decimal Cash { get; set; }

        [Required]
        [Display(Name = "ICOCA")]
        public decimal Icoca { get; set; }
    }
}
