using Microsoft.AspNetCore.Mvc.RazorPages;
using sqlapp.Entities;
using sqlapp.Services;

namespace sqlapp.Pages;

public class IndexModel(IProductService productService) : PageModel
{
    public List<Product> Products;

    public void OnGet()
    {
        Products = productService.GetProducts();
    }
}