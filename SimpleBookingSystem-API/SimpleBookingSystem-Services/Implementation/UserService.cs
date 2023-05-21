using SimpleBookingSystem_DAL.Abstraction;
using SimpleBookingSystem_DTO;
using SimpleBookingSystem_Mappers;
using SimpleBookingSystem_Services.Abstraction;

namespace SimpleBookingSystem_Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserDTO GetUser(int userId)
        {
            return _userRepository.GetEntity(userId).ToDto();
        }
    }
}
