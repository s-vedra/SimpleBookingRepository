using SimpleBookingSystem_DomainModels;
using SimpleBookingSystem_DTO;

namespace SimpleBookingSystem_Mappers
{
    public static class UserMapper
    {
        public static UserDTO ToDto(this User resource)
        {
            return new UserDTO()
            {
                Id = resource.Id,
                Email = resource.Email,
                Name = resource.Name,
                LastName = resource.LastName
            };
        }

        public static User ToDomain(this UserDTO resource)
        {
            return new User()
            {
                Id = resource.Id,
                Email = resource.Email,
                Name = resource.Name,
                LastName = resource.LastName
            };
        }
    }
}
