using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using webapp.Models;
using System.Configuration;

namespace webapp.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;

        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SqlConnection GetConnection()
        {
            ConfigurationManager cfg = new ConfigurationManager();
            var cString = _configuration.GetConnectionString("default");
            return new SqlConnection(cString);
        }
        public List<Product> GetProducts()
        {

            var products = new List<Product>();
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                var command = connection.CreateCommand();



                command.CommandText = "Select * from Products";

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    });
                }
                return products;
            }
        }
    }
}
