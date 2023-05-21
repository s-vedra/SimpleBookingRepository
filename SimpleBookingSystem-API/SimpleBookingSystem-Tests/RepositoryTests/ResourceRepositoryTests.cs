using Moq;
using SimpleBookingSystem_DAL.Abstraction;
using SimpleBookingSystem_DomainModels;

namespace SimpleBookingSystem_Tests.RepositoryTests
{
    public class ResourceRepositoryTests
    {
        private List<Resource> Resources { get; set; }
        private readonly Mock<IResourceRepository> _resourceRepository;
        public ResourceRepositoryTests()
        {
            Resources = GetResources();
            _resourceRepository = new Mock<IResourceRepository>();
        }

        [Fact(DisplayName = "Should add a new resource in the list")]
        public void ShouldAddANewResourceInTheList_AddEntity()
        {
            var resource = new Resource()
            {
                Quantity = 10,
                Title = "Resource 1"
            };

            _resourceRepository.Setup(x => x.AddEntity(It.IsAny<Resource>())).Returns(4);
            var result = _resourceRepository.Object.AddEntity(resource);

            Assert.Equal(4, result);
        }

        [Fact(DisplayName = "Should get all resources")]
        public void ShouldGetAllResources_GetEntities()
        {
            _resourceRepository.Setup(x => x.GetEntities()).Returns(Resources.AsQueryable());
            var result = _resourceRepository.Object.GetEntities();

            Assert.Equal(Resources, result);
        }

        [Fact(DisplayName = "Should get resource")]
        public void ShouldGetResource_GetEntity()
        {
            var resource = new Resource()
            {
                Id = 1,
                Quantity = 10,
                Title = "Resource 1"
            };

            _resourceRepository.Setup(x => x.GetEntity(It.IsAny<int>())).Returns(resource);
            var result = _resourceRepository.Object.GetEntity(resource.Id);

            Assert.Equal(resource, result);
        }

        private List<Resource> GetResources()
        {
            return new List<Resource>()
            {
                new Resource()
                {
                    Id = 1,
                    Quantity = 10,
                    Title = "Resource 1"
                },
                new Resource()
                {
                    Id = 2,
                    Quantity = 10,
                    Title = "Resource 2"
                },new Resource()
                {
                    Id = 3,
                    Quantity = 10,
                    Title = "Resource 3"
                },
            };
        }
    }
}
