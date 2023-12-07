namespace MyWebAppNbg.Models
{
    /**
    Product
     Id, Name, Price
Customer
    Id, Name, Email, RegistrationDate

OrderItem
    Id, Product, Quantity
Basket
    Id, CreationDate, Customer, List<OrderItem>
*/


    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateOnly? RegistrationDate { get; set; }
    }
 
    public class OrderItem
    {
        public int Id { get; set; }
        public Product? Product { get; set; }
        public int? Quantity { get; set; }
    }

    public class Basket
    {
        public int Id { get; set; }
        public DateOnly? CreationDate { get; set; }
        public Customer? Customer;
        public IEnumerable<OrderItem> OrderItems { get; set; }
            = new List<OrderItem>();
    }
      
}
