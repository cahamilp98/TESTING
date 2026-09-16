namespace RecruitCatHamilcp.Pages.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PositionName { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public DateTime? StartDate { get; set; }
        public string Location { get; set; }
        public List<Candidate> Candidates { get; set; }
        public int IndustryId { get; set; }
        public Industry Industry { get; set; }
        public long AmountOfTransactions { get; set; }
    }
}
