using chain_of_responsibility.ChainOfResponsibilityPattern;
using chain_of_responsibility.DAL;
using chain_of_responsibility.Models;
using Microsoft.AspNetCore.Mvc;

namespace chain_of_responsibility.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Context _context;

        public DefaultController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomerViewModel p)
        {
            Employee treasurer = new Treasurer(_context);
            Employee managerAsistant = new ManagerAssistant(_context);
            Employee manager = new Menager(_context);
            Employee areaDirector = new AreaDirector(_context);

            treasurer.SetNextApprover(managerAsistant);
            managerAsistant.SetNextApprover(manager);
            manager.SetNextApprover(areaDirector);

            treasurer.ProcessRequest(p);

            return View();
        }

    }
}
