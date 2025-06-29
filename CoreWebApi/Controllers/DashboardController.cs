using Microsoft.AspNetCore.Mvc;
using Common.Services;
using Common;
using Domain.Models.Entities;
using MediatR;

namespace CoreWebApi.Controllers
{
    public class DashboardController : BaseController<Usuarios> // Using Usuarios as placeholder, overriding functionality
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IMediator mediator, IDashboardService dashboardService) : base(mediator)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("stats")]
        public async Task<IActionResult> GetDashboardStats()
        {
            var stats = await _dashboardService.GetDashboardStatsAsync();
            return Ok(stats);
        }
    }
}
