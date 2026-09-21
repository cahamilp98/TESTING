using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatHamilcp.Pages.Models;
using RecruitCatHamilcp;

namespace RecruitCatHamilcp.Pages.JobTitlePages;

public class DeleteModel : PageModel
{
    private readonly RecruitCatHamilcpContext _context;

    public DeleteModel(RecruitCatHamilcpContext context)
    {
        _context = context;
    }

    [BindProperty]
    public JobTitle JobTitle { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? jobtitleid)
    {
        if (jobtitleid is null)
        {
            return NotFound();
        }

        var jobtitle = await _context.JobTitle.FirstOrDefaultAsync(m => m.JobTitleId == jobtitleid);
        if (jobtitle is null)
        {
            return NotFound();
        }
        else
        {
            JobTitle = jobtitle;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? jobtitleid)
    {
        if (jobtitleid is null)
        {
            return NotFound();
        }

        var jobtitle = await _context.JobTitle.FindAsync(jobtitleid);
        if (jobtitle != null)
        {
            JobTitle = jobtitle;
            _context.JobTitle.Remove(JobTitle);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
