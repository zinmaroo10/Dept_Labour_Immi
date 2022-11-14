using System.ComponentModel.DataAnnotations;
namespace Dept_Labour_Immi.Models
{
    public class Agency
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string AgencyName { get; set; }
        public string? Address { get; set; }
        public string? RegNo { get; set; }
        public string? Phone { get; set; }

        public int? BODID { get; set; }
        public BOD bOD { get; set; }

        public int? ThaiCompanyID { get; set; }
        public ThaiCompany thaiCompany { get; set; }

        public List<Blacklist> blacklists { get; set; }


    }
}
