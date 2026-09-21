using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatHamilcp.Pages.Models;
using RecruitCatHamilcp;

namespace RecruitCatHamilcp.Pages.IndustryPages;

public class CreateModel : PageModel
{
    private readonly RecruitCatHamilcpContext _context;

    public CreateModel(RecruitCatHamilcpContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Industry Industry { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Industry.Add(Industry);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
