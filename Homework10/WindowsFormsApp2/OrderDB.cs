using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;

namespace WindowsFormsApp2
{
    public class OrderDB : DbContext
    {
        
        public OrderDB() : base("OrderDataBase")
        {
        }
        public DbSet<Order> Order { get; set; }
    }
    public class myGetOrder
    {
        public static List<Order> GetAllOrders()
        {
            using (var db = new OrderDB())
            {
                return db.Order.ToList<Order>();
            }
        }
    }
}
