using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatHamilcp.Pages.Models;
using RecruitCatHamilcp;

namespace RecruitCatHamilcp.Pages.IndustryPages;

public class IndexModel : PageModel
{
    private readonly RecruitCatHamilcpContext _context;

    public IndexModel(RecruitCatHamilcpContext context)
    {
        _context = context;
    }

    public IList<Industry> Industry { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Industry = await _context.Industry.ToListAsync();
    }
}
