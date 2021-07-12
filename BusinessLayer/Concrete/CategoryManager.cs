using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;

namespace BusinessLayer.Concrete
{
    public class CategoryManager:ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAddBL(Category category)
        {
            _categoryDal.Insert(category);
        }

        public Category GetByID(int id)
        {
            return _categoryDal.Get(x=>x.CategoryID==id);
        }

        public void CategoryDelete(Category category)
        { 
            _categoryDal.Delete(category); 
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        public void CategoryUpdate(Category category)
        {
           _categoryDal.Update(category);
        }

        public List<Category> GetAllCategoryStatusFalse()
        {
            return _categoryDal.List(c=>c.CategoryStatus==false);
        }

        public List<Category> GetAllCategoryStatusTrue()
        {
            return _categoryDal.List(c => c.CategoryStatus == true);
        }
    }
}
