using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatHamilcp.Pages.Models;
using RecruitCatHamilcp;

namespace RecruitCatHamilcp.Pages.IndustryPages;

public class DetailsModel : PageModel
{
    private readonly RecruitCatHamilcpContext _context;
    public DetailsModel(RecruitCatHamilcpContext context)
    {
        _context = context;
    }

    public Industry Industry { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? industryid)
    {
        if (industryid is null)
        {
            return NotFound();
        }

        var industry = await _context.Industry.FirstOrDefaultAsync(m => m.IndustryId == industryid);
        if (industry is null)
        {
            return NotFound();
        }
        else
        {
            Industry = industry;
        }

        return Page();
    }
}
