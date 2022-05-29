using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace is_with_ef.Pages.Admin.Clients;

using identity_template_example.Pages;

[SecurityHeaders]
[Authorize]
public class NewModel : PageModel
{
    private readonly ClientRepository _repository;

    public NewModel(ClientRepository repository)
    {
        _repository = repository;
    }

    [BindProperty]
    public CreateClientModel InputModel { get; set; }
        
    public bool Created { get; set; }

    public void OnGet()
    {
        InputModel = new CreateClientModel
        { 
            Secret = Convert.ToBase64String(CryptoRandom.CreateRandomKey(16))
        };
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            await _repository.CreateAsync(InputModel);
            Created = true;
        }

        return Page();
    }
}