namespace Equifinance.Mock.API.Models
{
    public class Problem
    {
        public int ProblemID { get; set; }
        public string? Topic { get; set; }
        public string? Description { get; set; }
        public string? Difficulty { get; set; }
        public int UserID { get; set; }
        public User? User { get; set; }
        public ICollection<Submission>? Submissions { get; set; }
        public ICollection<TestCase>? Testcases { get; set; }
    }
}
