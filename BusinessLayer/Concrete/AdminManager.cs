using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AdminManager:IAdminService
    {
        private IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public List<Admin> GetList()
        {
           return _adminDal.List();
        }

        public void AdminAddBL(Admin admin)
        {
           _adminDal.Insert(admin);
        }

        public Admin GetByID(int id)
        {
            return _adminDal.Get(x=>x.AdminID==id);
        }

        public void AdminDelete(Admin admin)
        {
             _adminDal.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _adminDal.Update(admin);
        }
    }
}
