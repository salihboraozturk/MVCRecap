using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using EntityLayer.DTO;

namespace DataAccessLayer.Abstract
{
    public interface IHeadingDal:IRepository<Heading>
    {
        MostHeadingDTO GetTopBusinessCategories();
    }
}
