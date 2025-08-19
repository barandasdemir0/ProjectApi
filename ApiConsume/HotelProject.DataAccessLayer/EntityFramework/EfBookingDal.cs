using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal:GenericRepository<Booking>, IBookingDal
    {
        Context context = new();
        public EfBookingDal(Context context):base(context)
        {
            
        }

        public void BookingStatusChangeApproved(Booking booking)
        {
            var context = new Context();
            var values = context.Bookings.Where(x => x.BookingID == booking.BookingID).FirstOrDefault();
            values.Status = "Onaylandı";
            context.SaveChanges();
        }

        public int GetBookingCount()
        {
           
            return context.Bookings.Count();
        }

        public List<Booking> GetBookingList()
        {
           return context.Bookings.OrderByDescending(x=>x.BookingID).Take(5).ToList();
        }
    }
}
