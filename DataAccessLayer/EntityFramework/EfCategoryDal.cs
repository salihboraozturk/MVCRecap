using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public List<Category> GetAllCategoryStatusFalse()
        {
            bool status = false;
            using (Context context = new Context())
            {
                var result = from p in context.Categories.Where(p => p.CategoryStatus == status)
                    select new Category();

                return result.ToList();
            }
        }

        public List<Category> GetAllCategoryStatusTrue()
        {
            bool status = true;
            using (Context context = new Context())
            {
                var result = from p in context.Categories.Where(p => p.CategoryStatus == status)
                    select new Category();

                return result.ToList();
            }
        }
    }
}
