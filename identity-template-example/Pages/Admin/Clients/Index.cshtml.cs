using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace is_with_ef.Pages.Admin.Clients;

using identity_template_example.Pages;

[SecurityHeaders]
[Authorize]
public class IndexModel : PageModel
{
    private readonly ClientRepository _repository;

    public IndexModel(ClientRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<ClientSummaryModel> Clients { get; private set; }
    public string Filter { get; set; }

    public async Task OnGetAsync(string filter)
    {
        Filter = filter;
        Clients = await _repository.GetAllAsync(filter);
    }
}