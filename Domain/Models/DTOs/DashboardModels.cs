namespace Domain.Models.DTOs
{
    public class DashboardStatsResponse
    {
        public int TotalProducts { get; set; }
        public int TotalStock { get; set; }
        public int LowStock { get; set; }
        public int ActiveUsers { get; set; }
    }
}
