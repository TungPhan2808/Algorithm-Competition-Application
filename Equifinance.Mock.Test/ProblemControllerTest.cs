using Equifinance.Mock.API.Controllers;
using Equifinance.Mock.API.DTO;
using Equifinance.Mock.Core.DTO.Request;
using Equifinance.Mock.Core.Exceptions;
using Equifinance.Mock.Core.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Equifinance.Mock.Test
{
    public class ProblemControllerTest
    {
        private readonly Mock<IProblemService> _mockProblemService;
        private readonly ProblemController _controller;

        public ProblemControllerTest()
        {
            _mockProblemService = new Mock<IProblemService>();
            _controller = new ProblemController(_mockProblemService.Object);
        }
        [Fact]
        public async Task GetProblemsTest()
        {
            //arrange
            var expectedData = new List<ProblemDto>
            {
                new ProblemDto { ProblemID = 4, Topic = "Implement a Binary Search Tree", Description = "Write a function that creates a Binary Search Tree and supports basic operations like insert, delete and search.", Difficulty = "Medium", UserId = 2},
                new ProblemDto { ProblemID = 5, Topic = "Two Sum", Description = "Given an array of integers, return indices of the two numbers such that they add up to a specific target.", Difficulty = "Easy", UserId = 3}
            };
            _mockProblemService.Setup(n => n.GetAllUserProblemAsync()).ReturnsAsync(expectedData);
            //act
            var result = _controller.GetProblems();
            //assert
            Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result as OkObjectResult;
            Assert.IsType<List<ProblemDto>>(list.Value);

            var listProblem = list.Value as List<ProblemDto>;
            Assert.Equal(expectedData, listProblem);
        }

        [Theory]
        [InlineData(4, 9)]
        public async Task GetProblemByIdTest(int validId, int invalidId)
        {
            //arrange
            ProblemDto problem = new ProblemDto { ProblemID = 4, Topic = "Implement a Binary Search Tree", Description = "Write a function that creates a Binary Search Tree and supports basic operations like insert, delete and search.", Difficulty = "Medium", UserId = 2 };
            _mockProblemService.Setup(n => n.GetProblemByIdAsync(validId)).ReturnsAsync(problem);
            //act
            var okResult = _controller.GetProblemById(validId);
            //assert
            var validProblem = Assert.IsType<OkObjectResult>(okResult.Result);
            var item = Assert.IsType<ProblemDto>(validProblem.Value);
            Assert.Equal(validId, item.ProblemID);

            //arrange
            _mockProblemService.Setup(n => n.GetProblemByIdAsync(invalidId)).ReturnsAsync((ProblemDto)null);
            //act
            //assert
            Assert.ThrowsAsync<EntityNotFoundException>(async () => await _controller.GetProblemById(invalidId));
        }

        [Theory]
        [InlineData(3, 9)]
        public async Task CreateProblemTest(int validUserId, int invalidUserId)
        {
            //arrange
            var newProblemItem = new ProblemRequest()
            {
                Description = "Description",
                Topic = "Topic",
                Difficulty = "Difficulty",
            };
            var resultItem = new ProblemDto()
            {
                UserId = validUserId,
                Description = "Description",
                Topic = "Topic",
                Difficulty = "Difficulty",
            };
            _mockProblemService.Setup(n => n.CreateProblemAsync(validUserId, newProblemItem)).ReturnsAsync(resultItem);
            //act
            var result = await _controller.CreateProblem(validUserId, newProblemItem);
            //assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(actionResult.ActionName, "GetProblemById");

            //arrange
            _mockProblemService.Setup(n => n.CreateProblemAsync(invalidUserId, newProblemItem)).ThrowsAsync(new EntityNotFoundException($"No problem found with ID {invalidUserId}."));
            //assert
            Assert.ThrowsAsync<EntityNotFoundException>(() => _controller.CreateProblem(invalidUserId, newProblemItem));
        }

        [Theory]
        [InlineData(3)]
        public async Task UpdateProblemTest(int userId)
        {
            //arrange
            var updateProblemItem = new ProblemRequest()
            {
                Description = "Description1",
                Topic = "Topic1",
                Difficulty = "Difficulty1",
            };
            //act
            var response = await _controller.UpdateProblem(userId, updateProblemItem);
            //assert
            Assert.IsType<NoContentResult>(response);
        }
    }
}