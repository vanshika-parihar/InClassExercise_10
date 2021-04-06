using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InClass
    {
        public class Orders
        {
            [Key]
            public int OrderId { get; set; }
            public float billamount { get; set; }
            public float price { get; set; }
            public List<Ordered_Products> OrdersPlaced { get; set; }
        }

        public class Products
        {
            public int ProductId { get; set; }
            public string name { get; set; }
            public float price { get; set; }
            public float weight { get; set; }
            public List<Ordered_Products> ProductsOrdered { get; set; }
        }

        public class Ordered_Products
        {
            public int Id { get; set; }
            public Orders OrdersPlaced { get; set; }
            public Products ProductsOrdered { get; set; }
            public int count { get; set; }
        }
    }

}
}
