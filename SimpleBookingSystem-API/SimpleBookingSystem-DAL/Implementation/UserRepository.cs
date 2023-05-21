using SimpleBookingSystem_DAL.Abstraction;
using SimpleBookingSystem_DomainModels;
using SimpleBookingSystem_Exceptions;

namespace SimpleBookingSystem_DAL.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public int AddEntity(User entity)
        {
            _dataContext.Users.Add(entity);
            _dataContext.SaveChanges();
            return entity.Id;
        }

        public IQueryable<User> GetEntities()
        {
            return _dataContext.Users;
        }

        public User GetEntity(int id)
        {
            var resource = _dataContext.Users.FirstOrDefault(x => x.Id == id);
            if (resource == null)
                throw new CoreException("No user found");
            else
                return resource;
        }
    }
}
