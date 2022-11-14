namespace Dept_Labour_Immi.Models
{
    public class BOD
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string? NRC { get; set; }
        public string? Phone { get; set; }
        //public int? AgencyID { get; set; }
        //public Agency agency { get; set; }

        public List<Agency> agencies { get; set; }
    }
}
