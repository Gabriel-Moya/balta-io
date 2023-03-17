using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Category> Categories { get; set; } = new();

        public async Task OnGet()
        {
            await Task.Delay(5000);
        }
    }
}

public record Category(int Id, string Title, decimal Price);
