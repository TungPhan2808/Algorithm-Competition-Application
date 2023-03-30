namespace Equifinance.Mock.API.Models
{
    public class TestResult
    {
        public int TestResultID { get; set; }
        public string? Result { get; set; }
        public string? ActualOutput { get; set; }
        public int ExecutionTime { get; set; }
        public int Memory { get; set; }
        public int TestCaseID { get; set; }
        public TestCase? TestCase { get; set; }
        public int SubmissionID { get; set; }
        public Submission? Submission { get; set; }
    }
}
