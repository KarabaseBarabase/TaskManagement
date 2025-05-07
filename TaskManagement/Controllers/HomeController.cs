using System.Reflection;
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
            List<Mission> missions = _repository.Missions.ToList();
            var staff = missions
                .Select(m => m.AssignedTo)
                .Distinct()
                .ToArray();

            var random = new Random();
            var colors = new Dictionary<string, string>();
            foreach (var mission in missions)
            {
                if (!colors.ContainsKey(mission.Name))
                {
                    colors[mission.Name] = $"hsl({random.Next(0, 360)}, 70%, 80%)";
                }
            }

            var startDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            var endDate = startDate.AddDays(6);
            int startHour = 8;
            int endHour = 19;

            var model = new WeeklyManagerViewModel
            {
                Missions = missions,
                Staff = staff,
                TaskColors = colors,
                StartDate = startDate,
                EndDate = endDate,
                StartHour = startHour,
                EndHour = endHour
            };

            return View(model);
            //return View(_missions);
        }
	}
}

