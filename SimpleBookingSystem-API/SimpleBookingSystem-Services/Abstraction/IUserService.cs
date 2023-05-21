using SimpleBookingSystem_DTO;

namespace SimpleBookingSystem_Services.Abstraction
{
    public interface IUserService
    {
        UserDTO GetUser(int userId);
    }
}
