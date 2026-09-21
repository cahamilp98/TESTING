using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatHamilcp.Pages.Models;
using RecruitCatHamilcp;

namespace RecruitCatHamilcp.Pages.IndustryPages;

public class DeleteModel : PageModel
{
    private readonly RecruitCatHamilcpContext _context;

    public DeleteModel(RecruitCatHamilcpContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? industryid)
    {
        if (industryid is null)
        {
            return NotFound();
        }

        var industry = await _context.Industry.FindAsync(industryid);
        if (industry != null)
        {
            Industry = industry;
            _context.Industry.Remove(Industry);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
