using System.ComponentModel.DataAnnotations;

namespace Dept_Labour_Immi.Models
{
    public class DOE
    {
        public int ID { get; set; }
        [Required]
        public string DOENo { get; set; }
        public DateTime Date { get; set; }
    }
}
