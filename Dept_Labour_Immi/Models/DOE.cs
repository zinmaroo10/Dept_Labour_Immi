using System.ComponentModel.DataAnnotations;

namespace Dept_Labour_Immi.Models
{
    public class DOE
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "စာအမှတ်")]
        public string DOENo { get; set; }
        [Display(Name = "ရက်စွဲ")]
        public DateTime Date { get; set; }
    }
}
