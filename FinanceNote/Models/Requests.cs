using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceNote.Models
{
    [Table("Requests")]
    public class Requests
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "申請者")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "日付")]
        public DateTime? Date { get; set; }

        [Required]
        [Display( Name = "小遣い金額")]
        public decimal Balance { get; set; }
    }
}
