using SimpleBookingSystem_DAL.Abstraction;
using SimpleBookingSystem_DTO;
using SimpleBookingSystem_Exceptions;
using SimpleBookingSystem_Mappers;
using SimpleBookingSystem_Services.Abstraction;

namespace SimpleBookingSystem_Services.Implementation
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepository;
        public ResourceService(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public IEnumerable<ResourceDTO> GetResources()
        {
            var resources = _resourceRepository.GetEntities();
            if (!resources.Any())
                throw new CoreException("No resources found");
            else
                return resources.Select(x => x.ToDto());
        }
    }
}
