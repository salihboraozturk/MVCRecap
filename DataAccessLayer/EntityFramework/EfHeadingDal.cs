using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using EntityLayer.DTO;

namespace DataAccessLayer.EntityFramework
{
    public class EfHeadingDal:GenericRepository<Heading>,IHeadingDal
    {
        public MostHeadingDTO GetTopBusinessCategories()
        {
            using(Context context =new Context()){
                var top = (from review in context.Headings
                    group review by review.CategoryID into reviewgroups
                    select new MostHeadingDTO
                    {
                        CategoryID= reviewgroups.Key,
                        Count = reviewgroups.Count() //CategoryId should be any   
                        //property of Category or you           
                        //can use any property of category
                    }).OrderByDescending(x => x.Count).Take(1);
                return top.SingleOrDefault();
            }
        }
    }
}
