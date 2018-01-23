using System;
using System.Linq;
using System.Collections.Generic;
using HCP_Demo.Models;

namespace HCP_Demo.Data
{
    public static class DbInitializer
    {
        /// <summary>
        /// Initial run process.
        /// </summary>
        /// <param name="context">CustomerContext</param>
        public static void Initialize(CustomerContext context)
        {
            context.Database.EnsureCreated();
            
            LoadCustomers(context);
            LoadProducts(context);
            LoadFavorites(context);
            
        }

        /// <summary>
        /// Loads the customer data.
        /// </summary>
        /// <param name="context">CustomerContext</param>
        private static void LoadCustomers(CustomerContext context)
        {
            // Verify if the customer data has already been loaded.
            if (context.Customers.Any())
                return;
            else
            {
                //Add customer data.
                var customers = new Customer[]
                {
                    new Customer{FirstName="Shawn",LastName="Jetton", Address1="168 South St", City="Hanover Township", State="PA", Zip=18706},
                    new Customer{FirstName="Jennifer",LastName="Jetton", Address1="168 South St", City="Hanover Township", State="PA", Zip=18706},
                    new Customer{FirstName="Phil",LastName="Brundage ", Address1="195 Broadway", City="New York", State="NY", Zip=10007},
                };

                // Loop thru each customer in the collection.
                foreach (Customer c in customers)
                    context.Customers.Add(c);

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Loads the product data.
        /// </summary>
        /// <param name="context">CustomerContext</param>
        private static void LoadProducts(CustomerContext context)
        {
            // Verify if the product data has already been loaded.
            if (context.Products.Any())
                return;
            else
            {
                // Add product data.
                var products = new Product[]
                {
                    new Product{ISBN="9780062225269", Title="The Pioneer Woman Cooks: Come and Get It!", List_Price=29.99m, ReleaseDate=DateTime.Now},
                    new Product{ISBN="9780062381736", Title="The Demon Crown", List_Price=28.99m, ReleaseDate=DateTime.Now.AddDays(-1)},
                    new Product{ISBN="9780062678416", Title="The Woman in the Window", List_Price=20.24m, ReleaseDate=DateTime.Now.AddHours(-12)},
                    new Product{ISBN="9780062444424", Title="Heart Spring Mountain", List_Price=20.79m, ReleaseDate=DateTime.Now.AddMonths(-1)},
                    new Product{ISBN="9780062491077", Title="The Lost Rainforest: Mez's Magic", List_Price=12.74m, ReleaseDate=DateTime.Now.AddYears(-1)},

                };

                // Loop thru each product in the collection.
                foreach (Product p in products)
                    context.Products.Add(p);

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Loads the favorites data.
        /// </summary>
        /// <param name="context">CustomerContext</param>
        private static void LoadFavorites(CustomerContext context)
        {
            // Verify if the favorite data has already been loaded.
            if (context.Favorites.Any())
                return;
            else
            {
                // Add favorites data.
                // Using a List<> just to show the difference.
                List<Favorite> favorites = new List<Favorite>();
                favorites.Add(new Favorite() { CustomerID = 1, ProductID = 1 });
                favorites.Add(new Favorite() { CustomerID = 1, ProductID = 4 });
                favorites.Add(new Favorite() { CustomerID = 1, ProductID = 5 });

                favorites.Add(new Favorite() { CustomerID = 2, ProductID = 1 });
                favorites.Add(new Favorite() { CustomerID = 2, ProductID = 2 });

                favorites.Add(new Favorite() { CustomerID = 3, ProductID = 1 });
                favorites.Add(new Favorite() { CustomerID = 3, ProductID = 2 });
                favorites.Add(new Favorite() { CustomerID = 3, ProductID = 3 });
                favorites.Add(new Favorite() { CustomerID = 3, ProductID = 4 });

                // Loop thru each favorite in the list.
                foreach (Favorite f in favorites)
                    context.Favorites.Add(f);

                context.SaveChanges();
            }
        }
    }
}