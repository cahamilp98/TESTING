using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatHamilcp.Pages.Models;
using RecruitCatHamilcp;

namespace RecruitCatHamilcp.Pages.JobTitlePages;

public class EditModel : PageModel
{
    private readonly RecruitCatHamilcpContext _context;

    public EditModel(RecruitCatHamilcpContext context)
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
        JobTitle = jobtitle;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(JobTitle).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!JobTitleExists(JobTitle.JobTitleId))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool JobTitleExists(int jobtitleid)
    {
        return _context.JobTitle.Any(e => e.JobTitleId == jobtitleid);
    }
}
