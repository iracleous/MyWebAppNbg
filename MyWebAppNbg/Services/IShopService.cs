using MyWebAppNbg.Models;

namespace MyWebAppNbg.Services
{
    public interface IShopService
    {
        //product services
        // CRUD

        public Product GetProduct(int id);
        public Product GetProduct(string productName);
        public List<Product> GetProducts();

        public Product CreateProduct(Product product);
        public Product UpdateProduct(Product product);
        public bool DeleteProduct(int id);


        //customer services



        //basket services


    }
}
