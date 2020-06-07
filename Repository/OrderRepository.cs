using Lab1ASP.NetCore.BerrasData;
using Lab1ASP.NetCore.Models;
using Lab1ASP.NetCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1ASP.NetCore.Repository
{
    public class OrderRepository : IOrder
    {
        public BerrasDBContext DB;
        public OrderRepository(BerrasDBContext _DB)
        {

            DB = _DB;
        }
        public ICollection<Order> GetOrders()
        {
            return DB.Orders.ToList();
        }
    }
}
