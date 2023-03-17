using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorApp.Pages
{
    public class CategoriesModel : PageModel
    {
        public List<CategoryList> CategoryList { get; set; } = new();

        public void OnGet(
            int skip = 0,
            int take = 25)
        {
            var temp = new List<CategoryList>();
            for (int i = 0; i <= 1787; i++)
            {
                temp.Add(new CategoryList(i, $"Categoria {i}", i * 18.95M));
            }

            CategoryList = temp
                .Skip(skip)
                .Take(take)
                .ToList();
        }
    }
}

public record CategoryList(int Id, string Title, decimal Price);
