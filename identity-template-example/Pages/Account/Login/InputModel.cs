// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.ComponentModel.DataAnnotations;

namespace identity_template_example.Pages.Login;

public class InputModel
{
    [Required]
    public string Username { get; set; }
        
    [Required]
    public string Password { get; set; }
        
    public bool RememberMe { get; set; }
        
    public string ReturnUrl { get; set; }

    public string Button { get; set; }
}