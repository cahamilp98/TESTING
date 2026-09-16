namespace RecruitCatHamilcp.Pages.Models
{
    public class JobTitle
    {
        public int JobTitleId { get; set; }
        public List<Candidate> Candidates { get; set; }
        public string Title { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public bool? Degree { get; set; }
    }
}
