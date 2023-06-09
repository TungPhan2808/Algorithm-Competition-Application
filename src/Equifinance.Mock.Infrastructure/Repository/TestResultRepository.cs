﻿using Equifinance.Mock.Core.Interfaces.IRepository;
using Equifinance.Mock.Core.Models;
using Equifinance.Mock.Infrastructure.Data;

namespace Equifinance.Mock.Infrastructure.Repository
{
    public class TestResultRepository : GenericRepository<TestResult>, ITestResultRepository
    {
        public TestResultRepository(DataContext context) : base(context)
        {
        }
    }
}
