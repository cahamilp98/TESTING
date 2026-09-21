using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatHamilcp.Pages.Models;

namespace RecruitCatHamilcp.Pages.CompanyPages;

public class IndexModel : PageModel
{
    private readonly RecruitCatHamilcpContext _context;

    public IndexModel(RecruitCatHamilcpContext context)
    {
        _context = context;
    }

    public IList<Company> Company { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Company = await _context.Company.ToListAsync();
    }
}
