using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorApp.Pages
{
    public class CategoriesModel : PageModel
    {
        public List<CategoryList> CategoryList { get; set; } = new();

        public void OnGet()
        {
            for (int i = 0; i <= 100; i++)
            {
                CategoryList.Add(new CategoryList(i, $"Categoria {i}", i * 18.95M));
            }
        }
    }
}

public record CategoryList(int Id, string Title, decimal Price);
