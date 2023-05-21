using Moq;
using SimpleBookingSystem_DAL.Abstraction;
using SimpleBookingSystem_DomainModels;

namespace SimpleBookingSystem_Tests.RepositoryTests
{
    public class UserRepositoryTests
    {
        private List<User> Users { get; set; }
        private readonly Mock<IUserRepository> _userRepository;
        public UserRepositoryTests()
        {
            Users = GetUsers();
            _userRepository = new Mock<IUserRepository>();

        }

        [Fact(DisplayName = "Should add a new user in the list")]
        public void ShouldAddANewUserInTheList_AddEntity()
        {
            var user = new User()
            {
                Name = "Test",
                LastName = "Test",
                Email = "test@test.com"
            };

            _userRepository.Setup(x => x.AddEntity(It.IsAny<User>())).Returns(4);
            var result = _userRepository.Object.AddEntity(user);

            Assert.Equal(4, result);
        }

        [Fact(DisplayName = "Should get all users")]
        public void ShouldGetAllUsers_GetEntities()
        {
            _userRepository.Setup(x => x.GetEntities()).Returns(Users.AsQueryable());
            var result = _userRepository.Object.GetEntities();

            Assert.Equal(Users, result);
        }

        [Fact(DisplayName = "Should get user")]
        public void ShouldGetUser_GetEntity()
        {
            var user = new User()
            {
                Id = 1,
                Name = "Test",
                LastName = "Test",
                Email = "test@test.com"
            };

            _userRepository.Setup(x => x.GetEntity(It.IsAny<int>())).Returns(user);
            var result = _userRepository.Object.GetEntity(user.Id);

            Assert.Equal(user, result);
        }

        private List<User> GetUsers()
        {
            return new List<User>()
            {
                new User()
                {
                   Id = 1,
                   Name = "Test",
                   LastName = "Test",
                   Email = "test@test.com"
                },
                new User()
                {
                   Id = 2,
                   Name = "Test",
                   LastName = "Test",
                   Email = "test@test.com"
                },
                new User()
                {
                   Id = 3,
                   Name = "Test",
                   LastName = "Test",
                   Email = "test@test.com"
                },
            };
        }
    }
}
