using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatHamilcp.Pages.Models;
using RecruitCatHamilcp;

namespace RecruitCatHamilcp.Pages.JobTitlePages;

public class IndexModel : PageModel
{
    private readonly RecruitCatHamilcpContext _context;

    public IndexModel(RecruitCatHamilcpContext context)
    {
        _context = context;
    }

    public IList<JobTitle> JobTitle { get; set; } = default!;

    public async Task OnGetAsync()
    {
        JobTitle = await _context.JobTitle.ToListAsync();
    }
}
