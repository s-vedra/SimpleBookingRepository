using Moq;
using SimpleBookingSystem_DomainModels;
using SimpleBookingSystem_DTO;
using SimpleBookingSystem_Mappers;
using SimpleBookingSystem_Services.Abstraction;

namespace SimpleBookingSystem_Tests.ServiceTests
{
    public class UserServiceTests
    {
        private readonly Mock<IUserService> _userService;
        public UserServiceTests()
        {
            _userService = new Mock<IUserService>();
        }
        [Fact(DisplayName = "Should get logged in user")]
        public void ShouldGetLoggedInUser_GetUser()
        {
            var user = new UserDTO()
            {
                Id = 1,
                Name = "test",
                LastName = "test",
                Email = "test@test.com"
            };

            _userService.Setup(x => x.GetUser(It.IsAny<int>())).Returns(user);

            var result = _userService.Object.GetUser(user.Id);
            Assert.NotNull(result);
        }
    }
}
