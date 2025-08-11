using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class SubscribesManager: ISubscribesService
    {
        private readonly ISubscribeDal _subscribesDal;

        public SubscribesManager(ISubscribeDal subscribesDal)
        {
            _subscribesDal = subscribesDal;
        }

        public void TDelete(Subscribe t)
        {
            _subscribesDal.Delete(t);
        }

        public Subscribe TGetById(int id)
        {
           return _subscribesDal.GetByID(id);
        }

        public List<Subscribe> TGetList()
        {
            return _subscribesDal.GetList();
        }

        public void TInsert(Subscribe t)
        {
            _subscribesDal.Insert(t);
        }

        public void TUpdate(Subscribe t)
        {
            _subscribesDal.Update(t);
        }
    }
}
