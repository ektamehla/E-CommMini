namespace Ecomm.Server.Models
{
    public class Product
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public string ? Description { get; set; }
        public int Price { get; set; }

        public string Category { get; set; }

        //public Product(int id, string name, string? description, int price, string category)
        //{
        //    Id = id;
        //    Name = name;
        //    Description = description;
        //    Price = price;
        //    Category = category;
        //}

        //public Product() { }

        public void updatePrice(int price, Product product)
        {
            product.Price = price;
        }

    }
}
