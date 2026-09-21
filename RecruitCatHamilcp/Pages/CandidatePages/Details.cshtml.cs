using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatHamilcp.Pages.Models;

namespace RecruitCatHamilcp.Pages.CandidatePages;

public class DetailsModel : PageModel
{
    private readonly RecruitCatHamilcpContext _context;
    public DetailsModel(RecruitCatHamilcpContext context)
    {
        _context = context;
    }

    public Candidate Candidate { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var candidate = await _context.Candidate.FirstOrDefaultAsync(m => m.Id == id);
        if (candidate is null)
        {
            return NotFound();
        }
        else
        {
            Candidate = candidate;
        }

        return Page();
    }
}
