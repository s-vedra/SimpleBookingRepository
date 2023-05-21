using SimpleBookingSystem_DomainModels;
using SimpleBookingSystem_DTO;
using SimpleBookingSystem_Mappers;

namespace SimpleBookingSystem_Tests.MappingTests
{
    public class UserMapperTest
    {
        [Fact(DisplayName = "Should map from Dto user object to domain")]
        public void ShouldMapFromDtoUserObjectToDomain_ToDomain()
        {
            var userDto = new UserDTO()
            {
                Email = "test@test.com",
                Name = "test",
                LastName = "test"
            };

            var user = userDto.ToDomain();

            Assert.IsType<User>(user);
        }

        [Fact(DisplayName = "Should map from domain user object to dto")]
        public void ShouldMapFromDomainUserObjectToDto_ToDto()
        {
            var user = new User()
            {
                Email = "test@test.com",
                Name = "test",
                LastName = "test"
            };

            var userDto = user.ToDto();

            Assert.IsType<UserDTO>(userDto);
        }
    }
}
