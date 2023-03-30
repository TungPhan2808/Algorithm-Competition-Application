namespace Equifinance.Mock.API.DTO
{
    public class ProblemDto
    {
        public int ProblemID { get; set; }
        public string? Topic { get; set; }
        public string? Description { get; set; }
        public string? Difficulty { get; set; }
        public int UserId { get; set; }
    }
}
