using SimpleBookingSystem_DAL.Abstraction;
using SimpleBookingSystem_DomainModels;
using SimpleBookingSystem_Exceptions;

namespace SimpleBookingSystem_DAL.Implementation
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly DataContext _dataContext;
        public ResourceRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int AddEntity(Resource entity)
        {
            _dataContext.Resources.Add(entity);
            _dataContext.SaveChanges();
            return entity.Id;
        }

        public IQueryable<Resource> GetEntities()
        {
            return _dataContext.Resources;
        }

        public Resource GetEntity(int id)
        {
            var resource = _dataContext.Resources.FirstOrDefault(x => x.Id == id);
            if (resource == null)
                throw new CoreException("No resource found");
            else
                return resource;
        }

        public void RemoveEntity(Resource entity)
        {
            _dataContext.Resources.Remove(entity);
            _dataContext.SaveChanges();
        }

        public void UpdateEntity(Resource entity)
        {
            var resource = GetEntity(entity.Id);
            _dataContext.Entry(resource).CurrentValues.SetValues(entity);
            _dataContext.SaveChanges();
        }
    }
}
