using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatHamilcp.Pages.Models;

namespace RecruitCatHamilcp.Pages.CandidatePages;

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
    public Candidate Candidate { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Candidate.Add(Candidate);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
