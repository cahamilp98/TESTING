using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatHamilcp.Pages.Models;

namespace RecruitCatHamilcp.Pages.CompanyPages;

public class DetailsModel : PageModel
{
    private readonly RecruitCatHamilcpContext _context;
    public DetailsModel(RecruitCatHamilcpContext context)
    {
        _context = context;
    }

    public Company Company { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var company = await _context.Company.FirstOrDefaultAsync(m => m.Id == id);
        if (company is null)
        {
            return NotFound();
        }
        else
        {
            Company = company;
        }

        return Page();
    }
}
