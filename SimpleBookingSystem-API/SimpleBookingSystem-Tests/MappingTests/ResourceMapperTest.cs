using SimpleBookingSystem_DomainModels;
using SimpleBookingSystem_DTO;
using SimpleBookingSystem_Mappers;

namespace SimpleBookingSystem_Tests.MappingTests
{
    public class ResourceMapperTest
    {
        [Fact(DisplayName = "Should map from Dto resource object to domain")]
        public void ShouldMapFromDtoResourceObjectToDomain_ToDomain()
        {
            var resourceDto = new ResourceDTO()
            {
                Quantity = 10, 
                Title = "Resource"
            };

            var resource = resourceDto.ToDomain();

            Assert.IsType<Resource>(resource);
        }

        [Fact(DisplayName = "Should map from domain resource object to dto")]
        public void ShouldMapFromDtoResourceObjectToDomain_ToDto()
        {
            var resource = new Resource()
            {
                Quantity = 10,
                Title = "Resource"
            };

            var resourceDto = resource.ToDto();

            Assert.IsType<ResourceDTO>(resourceDto);
        }
    }
}
    