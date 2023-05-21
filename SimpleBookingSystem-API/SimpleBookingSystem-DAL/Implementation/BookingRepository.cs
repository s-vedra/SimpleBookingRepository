using SimpleBookingSystem_DAL.Abstraction;
using SimpleBookingSystem_DomainModels;
using SimpleBookingSystem_Exceptions;

namespace SimpleBookingSystem_DAL.Implementation
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DataContext _dataContext;
        public BookingRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public int AddEntity(Booking entity)
        {
            _dataContext.Bookings.Add(entity);
            _dataContext.SaveChanges();
            return entity.Id;
        }

        public IQueryable<Booking> GetEntities()
        {
            return _dataContext.Bookings;
        }

        public Booking GetEntity(int id)
        {
            var resource = _dataContext.Bookings.FirstOrDefault(x => x.Id == id);
            if (resource == null)
                throw new CoreException("No booking found");
            else
                return resource;
        }
    }
}
