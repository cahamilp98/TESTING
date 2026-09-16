namespace RecruitCatHamilcp.Pages.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal TargetSalary { get; set; }
        public DateTime? StartDate { get; set; }
        public Industry IndustryWorking { get; set; }
        public int IndustryWorkingId { get; set; }
        public int JobTitleActualId { get; set; }
        public JobTitle JobTitleActual { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public string Address { get; set; }
        public int SocialSecurityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? HighSchoolGraduation { get; set; }
        public DateTime? BachelorsGraduation { get; set; }
        public bool? HigherDegreeGraduation { get; set; }
    }
}
