using DAL.Entities;

namespace DAL.Data.Seeds
{
    public static class ProductSeed
    {
        public static List<Product> Products =>
            [
                new Product
                {
                    Id = 1,
                    Name = "Coke",
                    Price = 2,
                },
                new Product
                {
                    Id = 2,
                    Name = "Pepsi",
                    Price = 3,
                },
                new Product
                {
                    Id = 3,
                    Name = "Purse",
                    Price = 100,
                },
                new Product
                {
                    Id = 4,
                    Name = "Watch",
                    Price = 500,
                },
                new Product
                {
                    Id = 5,
                    Name = "Phone",
                    Price = 400,
                },
                new Product
                {
                    Id = 6,
                    Name = "Controller",
                    Price = 80,
                },
                new Product
                {
                    Id = 7,
                    Name = "Bread",
                    Price = 3,
                },
            ];
    }
}
