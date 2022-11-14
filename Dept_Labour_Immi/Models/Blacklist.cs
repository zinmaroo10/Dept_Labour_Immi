namespace Dept_Labour_Immi.Models
{
    public class Blacklist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Reason { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? Todate { get; set; }
        public string? Remark { get; set; }
        public bool IsActive { get; set; }
        public string penalty { get; set; }
        //foreign key 

        //public List<Agency> agencies { get; set; } update comment

        //public int PenaltyID { get; set; }  //can use if there come more peanlties

        public int? AgencyID { get; set; }
        public Agency? agency { get; set; }
    }
}
