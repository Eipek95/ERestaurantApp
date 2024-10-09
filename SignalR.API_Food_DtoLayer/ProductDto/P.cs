namespace SignalR.API_Food_DtoLayer.ProductDto
{
    internal class P
    {

        public class Rootobject
        {
            public int id { get; set; }
            public string userId { get; set; }
            public Cartitem[] cartItems { get; set; }
        }

        public class Cartitem
        {
            public int id { get; set; }
            public Product product { get; set; }
            public int productId { get; set; }
            public int cartId { get; set; }
            public int quantity { get; set; }
        }

        public class Product
        {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public int price { get; set; }
            public string imageUrl { get; set; }
            public bool status { get; set; }
            public int categoryID { get; set; }
        }


    }
}
