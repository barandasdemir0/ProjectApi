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
    public class EfStaffDal:GenericRepository<Staff>,IStaffDal
    {
        Context context = new();
        public EfStaffDal(Context context):base(context)
        {
            
        }

        public int GetStaffCount()
        {
            
            return context.Staffs.Count();

        }

        public List<Staff> Last4Staff()
        {
            return context.Staffs
                .OrderByDescending(x => x.StaffID)
                .Take(4)
                .ToList();
        }
    }
}
