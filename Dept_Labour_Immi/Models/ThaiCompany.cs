using System.ComponentModel.DataAnnotations;

namespace Dept_Labour_Immi.Models
{
    public class ThaiCompany
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "ထိုင်းကုမ္ပဏီအမည်")]
        public string CompanyName { get; set; }
    }
}
