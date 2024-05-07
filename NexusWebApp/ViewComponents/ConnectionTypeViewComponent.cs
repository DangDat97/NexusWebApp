using NexusWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using NexusWebApp.Repository;

namespace NexusWebApp.ViewComponents
{
    public class ConnectionTypeViewComponent : ViewComponent
    {
        private readonly IConnectionTypeRepository _connectionTypes;

        public ConnectionTypeViewComponent(IConnectionTypeRepository connectionTypeRepository)
        {
            _connectionTypes = connectionTypeRepository;
        }

        public IViewComponentResult Invoke()
        {
            var ConnectionTypes = _connectionTypes.GetAll().OrderBy(x => x.Id);
            return View(ConnectionTypes);
        }


    }
}
