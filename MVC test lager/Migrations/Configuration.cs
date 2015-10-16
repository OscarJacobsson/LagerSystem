namespace MVC_test_lager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MVC_test_lager.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_test_lager.DataAccessLayer.ItemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVC_test_lager.DataAccessLayer.ItemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
                context.Items.AddOrUpdate(
                  p => p.Name,
                  new StockItem { Name = "a", Price = 1.01m, Shelf = "a1", Description = "Produkt A" },
                  new StockItem { Name = "b", Price = 2.02m, Shelf = "a2", Description = "Produkt B" },
                  new StockItem { Name = "c", Price = 3.03m, Shelf = "a3", Description = "Produkt C" },
                  new StockItem { Name = "d", Price = 4.04m, Shelf = "a4", Description = "Produkt D" }
                );
            
        }
    }
}
