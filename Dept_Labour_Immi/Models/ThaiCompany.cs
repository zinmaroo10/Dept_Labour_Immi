namespace Dept_Labour_Immi.Models
{
    public class ThaiCompany
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }

        public List<Agency> agencies { get; set; }
    }
}
