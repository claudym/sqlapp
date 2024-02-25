using System.Data.SqlClient;
using sqlapp.Entities;

namespace sqlapp.Services;

public class ProductService(IConfiguration configuration) : IProductService
{
    private SqlConnection GetConnection()
    {
        return new SqlConnection(configuration.GetConnectionString("SqlConnection"));
    }

    public List<Product> GetProducts()
    {
        var conn = GetConnection();
        var productList = new List<Product>();
        var statement = "SELECT ProductID, ProductName, Quantity FROM Product";
        
        conn.Open();
        var cmd = new SqlCommand(statement, conn);
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                var product = new Product()
                {
                    ProductId = reader.GetInt32(0),
                    ProductName = reader.GetString(1),
                    Quantity = reader.GetInt32(2)
                };
                
                productList.Add(product);
            }
        }

        conn.Close();
        return productList;
    }
}