using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Component
{
    public class UserSummary : ViewComponent
    {
         private readonly IServiceManager _manager;

        public UserSummary(IServiceManager manager)
        {
            _manager = manager;
        }
        public string Invoke()
        {
            return _manager.AuthService.GetAllUsers.Count().ToString();
        }
    }
}