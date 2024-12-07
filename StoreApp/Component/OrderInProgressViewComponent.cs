using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Component
{
    public class OrderInProgress : ViewComponent
    {
        private readonly IServiceManager _manager;

        public OrderInProgress(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager.OrderService.numberOfInProcess.ToString();
        }
    }
}