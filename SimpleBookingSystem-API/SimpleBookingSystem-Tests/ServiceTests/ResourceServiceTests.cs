using Moq;
using SimpleBookingSystem_DTO;
using SimpleBookingSystem_Exceptions;
using SimpleBookingSystem_Services.Abstraction;

namespace SimpleBookingSystem_Tests.ResourceServiceTests
{
    public class ResourceServiceTests
    {
        private readonly Mock<IResourceService> _resourceService;
        private List<ResourceDTO> Resources { get; set; }
        public ResourceServiceTests()
        {
            _resourceService = new Mock<IResourceService>();
            Resources = GetResources();
        }

        [Fact(DisplayName = "Should get all resources")]
        public void ShouldGetAllResources_GetResources()
        {
            //Arrange
            _resourceService.Setup(x => x.GetResources()).Returns(Resources);

            // Act
            var result = _resourceService.Object.GetResources();

            // Assert
            Assert.Equal(Resources, result);
        }

        [Fact(DisplayName = "Should throw exception if no resources are present")]
        public void ShouldThrowExceptionIfNoResourcesArePresent_GetResources()
        {
            //Arrange
            var exception = new CoreException("");
            _resourceService.Setup(x => x.GetResources()).Throws(exception);

            //Act and Assert
            Assert.Throws<CoreException>(() => _resourceService.Object.GetResources());
        }

        private List<ResourceDTO> GetResources()
        {
            return new List<ResourceDTO>()
            {
                new ResourceDTO()
                {
                    Id = 1,
                    Quantity = 10,
                    Title = "Resource 1"
                },
                new ResourceDTO()
                {
                    Id = 2,
                    Quantity = 10,
                    Title = "Resource 2"
                },new ResourceDTO()
                {
                    Id = 3,
                    Quantity = 10,
                    Title = "Resource 3"
                },
            };
        }
    }
}
