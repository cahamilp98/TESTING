using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatHamilcp.Pages.Models;

namespace RecruitCatHamilcp.Pages.CandidatePages;

public class IndexModel : PageModel
{
    private readonly RecruitCatHamilcpContext _context;

    public IndexModel(RecruitCatHamilcpContext context)
    {
        _context = context;
    }

    public IList<Candidate> Candidate { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Candidate = await _context.Candidate.ToListAsync();
    }
}
