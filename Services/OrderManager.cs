using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class OrderManager : IOrderService
    {
        private readonly IRepositoryManager _manager;

        public OrderManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IQueryable<Order> Orders => _manager.Order.Orders;

        public int numberOfInProcess => _manager.Order.numberOfInProcess;

        public void Complate(int id)
        {
            _manager.Order.Complate(id);
            _manager.Save();
        }

        public Order? GetOneOrder(int id)
        {
           return _manager.Order.GetOneOrder(id);
        }

        public void SaveOrder(Order order)
        {
            _manager.Order.SaveOrder(order);
        }
    }
}