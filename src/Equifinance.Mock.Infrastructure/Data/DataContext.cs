﻿using Equifinance.Mock.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Equifinance.Mock.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Problem> Problems { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TestCase> Testcases { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
    }
}
