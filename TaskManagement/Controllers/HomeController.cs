using Microsoft.AspNetCore.Mvc;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
	public class HomeController : Controller
	{
		private IManagerRepository _repository;
		public HomeController(IManagerRepository repository)
		{
			_repository = repository;
		}
		public IActionResult Index()
		{
            List<Mission> _missions = _repository.Missions.ToList();
            return View(_missions);
        }
	}
}

