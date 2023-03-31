namespace Equifinance.Mock.Core.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string? Role { get; set; }
        public int NumberOfProblemSolved { get; set; }
        public ICollection<Problem>? Problems { get; set; }
        public ICollection<Submission>? Submissions { get; set; }
    }
}
