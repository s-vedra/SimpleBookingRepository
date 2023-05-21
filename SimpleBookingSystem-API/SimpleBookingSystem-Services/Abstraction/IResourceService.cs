using SimpleBookingSystem_DTO;

namespace SimpleBookingSystem_Services.Abstraction
{
    public interface IResourceService
    {
        IEnumerable<ResourceDTO> GetResources();
    }
}
