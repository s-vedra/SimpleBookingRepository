using SimpleBookingSystem_DomainModels;
using SimpleBookingSystem_DTO;

namespace SimpleBookingSystem_Mappers
{
    public static class ResourceMapper
    {
        public static ResourceDTO ToDto(this Resource resource)
        {
            return new ResourceDTO()
            {
                Id = resource.Id,
                Title = resource.Title,
                Quantity = resource.Quantity
            };
        }

        public static Resource ToDomain(this ResourceDTO resource)
        {
            return new Resource()
            {
                Id = resource.Id,
                Title = resource.Title,
                Quantity = resource.Quantity
            };
        }
    }
}
