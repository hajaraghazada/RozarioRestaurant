using Business.Abstract;
using Entities.Concrete;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EcommerceMVC.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var teamMembers = _teamService.GetTeams();
            if (teamMembers == null || !teamMembers.Any())
            {
                return View("Error"); 
            }

            return View(teamMembers); 
        }

        public IActionResult Details(int id)
        {
            var teamMember = _teamService.GetTeamMemberById(id);
            if (teamMember == null)
            {
                return NotFound();
            }

            return View(teamMember);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TeamDto teamDto)
        {
            if (ModelState.IsValid)
            {
                var teamMember = new Team
                {
                    Name = teamDto.Name,
                    ImageUrl = teamDto.ImageUrl
                };
                _teamService.AddTeamMember(teamMember);
                return RedirectToAction(nameof(Index));
            }

            return View(teamDto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var teamMember = _teamService.GetTeamMemberById(id);
            if (teamMember == null)
            {
                return NotFound();
            }

            return View(teamMember);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TeamDto teamDto)
        {
            if (id != teamDto.ID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var teamMember = new Team
                {
                    ID = teamDto.ID,
                    Name = teamDto.Name,
                    ImageUrl = teamDto.ImageUrl
                };
                _teamService.UpdateTeamMember(teamMember);
                return RedirectToAction(nameof(Index));
            }

            return View(teamDto);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var teamMember = _teamService.GetTeamMemberById(id);
            if (teamMember == null)
            {
                return NotFound();
            }

            return View(teamMember);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _teamService.DeleteTeamMember(id);
            return RedirectToAction(nameof(Index));
        }
    }
}