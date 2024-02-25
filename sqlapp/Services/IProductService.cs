using sqlapp.Entities;

namespace sqlapp.Services;

public interface IProductService
{
    List<Product> GetProducts();
}