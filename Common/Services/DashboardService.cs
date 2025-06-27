using Common.Services;
using Domain.Models.DTOs;
using Domain.Models.Entities;
using Infraestructure.Repositories;

namespace Common.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IRepository _repository;

        public DashboardService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<DashboardStatsResponse> GetDashboardStatsAsync()
        {
            var products = await _repository.GetAsync<Productos>();
            var users = await _repository.GetAsync<Usuarios>();

            var totalProducts = products.Count();
            var totalStock = products.Sum(p => p.Stock);
            var lowStock = products.Count(p => p.Stock < 10); // Productos con menos de 10 unidades
            var activeUsers = users.Count(u => u.Activo);

            return new DashboardStatsResponse
            {
                TotalProducts = totalProducts,
                TotalStock = totalStock,
                LowStock = lowStock,
                ActiveUsers = activeUsers
            };
        }
    }
}
