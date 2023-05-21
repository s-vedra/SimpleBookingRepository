using SimpleBookingSystem_DAL.Abstraction;
using SimpleBookingSystem_DomainModels;
using SimpleBookingSystem_Exceptions;

namespace SimpleBookingSystem_DAL.Implementation
{
    public class DateRangeRepository : IDateRangeRepository
    {
        private readonly DataContext _dataContext;
        public DateRangeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public int AddEntity(DateRange entity)
        {
            _dataContext.DateRanges.Add(entity);
            _dataContext.SaveChanges();
            return entity.Id;
        }

        public IQueryable<DateRange> GetEntities()
        {
            return _dataContext.DateRanges;
        }

        public DateRange GetEntity(int id)
        {
            var resource = _dataContext.DateRanges.FirstOrDefault(x => x.Id == id);
            if (resource == null)
                throw new CoreException("No range found");
            else
                return resource;
        }
    }
}
