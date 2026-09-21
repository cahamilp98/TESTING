using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatHamilcp.Pages.Models;
using RecruitCatHamilcp;

namespace RecruitCatHamilcp.Pages.IndustryPages;

public class EditModel : PageModel
{
    private readonly RecruitCatHamilcpContext _context;

    public EditModel(RecruitCatHamilcpContext context)
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
        Industry = industry;
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

        _context.Attach(Industry).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!IndustryExists(Industry.IndustryId))
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

    private bool IndustryExists(int industryid)
    {
        return _context.Industry.Any(e => e.IndustryId == industryid);
    }
}
