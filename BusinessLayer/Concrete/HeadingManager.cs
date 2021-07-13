using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTO;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        private IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public List<Heading> GetAllByCategoryID(int id)
        {
           return _headingDal.List(x=>x.CategoryID==id);
        }

        public Heading GetByID(int id)
        {
           return _headingDal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetList()
        {
            return _headingDal.List();
        }

        public MostHeadingDTO GetTopBusinessCategories()
        {
            return _headingDal.GetTopBusinessCategories();
        }

        public void HeadingAddBL(Heading heading)
        {
           _headingDal.Insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            heading.HeadingStatus = false;
           _headingDal.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
           _headingDal.Update(heading);
        }

   

        //public List<Heading> MostHeadingCategory()
        //{
        //   return _headingDal.List().GroupBy(c=>c.CategoryID);
        //}
    }
}
