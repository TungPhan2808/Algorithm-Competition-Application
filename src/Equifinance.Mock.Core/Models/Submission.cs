namespace Equifinance.Mock.API.Models
{
    public class Submission
    {
        public int SubmissionID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Language { get; set; }
        public string? SubmittedCode { get; set; }
        public int UserID { get; set; }
        public User? User { get; set; }
        public int ProblemID { get; set; }
        public Problem? Problem { get; set; }
        public ICollection<TestResult>? TestResults { get; set; }
    }
}
