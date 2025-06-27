using Domain.Models.DTOs;

namespace Common.Services
{
    public interface IDashboardService
    {
        Task<DashboardStatsResponse> GetDashboardStatsAsync();
    }
}
