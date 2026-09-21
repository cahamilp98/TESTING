using Microsoft.EntityFrameworkCore;
using RecruitCatHamilcp.Pages.Models;

namespace RecruitCatHamilcp
{
    public class RecruitCatHamilcpContext : DbContext
    {
        public DbSet<RecruitCatHamilcp.Pages.Models.JobTitle> JobTitle { get; set; } = default!;
        public DbSet<RecruitCatHamilcp.Pages.Models.Industry> Industry { get; set; } = default!;
        public RecruitCatHamilcpContext(DbContextOptions<RecruitCatHamilcpContext> options)
            : base(options)
        {
        }

        public DbSet<Candidate> Candidate { get; set; } = default!;
        public DbSet<Company> Company { get; set; } = default!;
    }
}