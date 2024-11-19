
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreApp.Pages
{
    public class DemoModel : PageModel
    {
        public string? FullName => HttpContext?.Session.GetString("name") ?? "NoName"; // Full name istendiğinde çalışır.

        public void OnGet()
        {

        }
        public void OnPost([FromForm] string name)
        {
            //FullName = name; Sessiondan getiricez.  Sessionda byte[] , int ve string veriler tutulur.
            HttpContext.Session.SetString("name",name);
        }
    }
}