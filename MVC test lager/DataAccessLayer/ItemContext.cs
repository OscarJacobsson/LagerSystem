using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MVC_test_lager.DataAccessLayer
{
    public class ItemContext : DbContext {
        public ItemContext() : base ("DefaultConnection") {

    }
        public DbSet<Models.StockItem> Items { get; set; }
    }
}