using Xunit;
using Moq;
using AssignmentManagement.Core;

namespace AssignmentManagement.Tests
{
    public class ConsoleUITests
    {
        [Fact]
        public void AddAssignment_ShouldReturnTrue()
        {
            var mockService = new Mock<IAssignmentService>();
            mockService.Setup(s => s.AddAssignment(It.IsAny<Assignment>())).Returns(true);

            var result = mockService.Object.AddAssignment(new Assignment("Test", "Description"));

            Assert.True(result);
        }

        [Fact]
        public void DeleteAssignment_ShouldReturnTrue()
        {
            var mockService = new Mock<IAssignmentService>();
            mockService.Setup(s => s.DeleteAssignment("Test")).Returns(true);

            var result = mockService.Object.DeleteAssignment("Test");

            Assert.True(result);
        }

        [Fact]
        public void FindAssignmentByTitle_ShouldReturnCorrectAssignment()
        {
            var mockService = new Mock<IAssignmentService>();
            var expected = new Assignment("Test", "Some Description");
            mockService.Setup(s => s.FindAssignmentByTitle("Test")).Returns(expected);

            var result = mockService.Object.FindAssignmentByTitle("Test");

            Assert.NotNull(result);
            Assert.Equal("Test", result.Title);
        }
    }
}
