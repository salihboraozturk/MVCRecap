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
    public class ContentManager:IContentService
    {
        private IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public List<Content> GetList()
        {
            return _contentDal.List();
        }

        public void ContentAddBL(Content content)
        {
            _contentDal.Insert(content);
        }

        public Content GetByID(int id)
        {
            return _contentDal.Get(x => x.ContentID == id); ;
        }

        public void ContentDelete(Content content)
        {
            _contentDal.Delete(content);
        }

        public void ContentUpdate(Content content)
        {
            _contentDal.Update(content);
        }

        public List<Content> GetListByHeadingID(int HeadingID)
        {
            return _contentDal.List(c => c.HeadingID == HeadingID);
        }
    }
}
