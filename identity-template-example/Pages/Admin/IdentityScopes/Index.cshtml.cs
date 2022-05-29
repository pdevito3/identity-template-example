using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace is_with_ef.Pages.Admin.IdentityScopes;

using identity_template_example.Pages;

[SecurityHeaders]
[Authorize]
public class IndexModel : PageModel
{
    private readonly IdentityScopeRepository _repository;

    public IndexModel(IdentityScopeRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<IdentityScopeSummaryModel> Scopes { get; private set; }
    public string Filter { get; set; }

    public async Task OnGetAsync(string filter)
    {
        Filter = filter;
        Scopes = await _repository.GetAllAsync(filter);
    }
}