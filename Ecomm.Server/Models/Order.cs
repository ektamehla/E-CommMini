namespace Ecomm.Server.Models
{
    public class Order
    {
        public int Id { get;set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public decimal Amount => Products.Sum(p => p.Price);
        public User? OrderedBy { get; set; }
        public DateTime Date { get; set; }


        public Order() { }
        public Order(int id, User orderedBy)
        {
            Id = id;
            //Products = new List<Product>();
            OrderedBy = orderedBy;
            Date = DateTime.Now;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(Product product) 
        {
            Products.Remove(product);
        }
    }
}
