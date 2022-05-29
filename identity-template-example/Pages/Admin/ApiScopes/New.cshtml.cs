using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace is_with_ef.Pages.Admin.ApiScopes;

using identity_template_example.Pages;

[SecurityHeaders]
[Authorize]
public class NewModel : PageModel
{
    private readonly ApiScopeRepository _repository;

    public NewModel(ApiScopeRepository repository)
    {
        _repository = repository;
    }

    [BindProperty]
    public ApiScopeModel InputModel { get; set; }
        
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            await _repository.CreateAsync(InputModel);
            return RedirectToPage("/Admin/ApiScopes/Edit", new { id = InputModel.Name });
        }

        return Page();
    }
}