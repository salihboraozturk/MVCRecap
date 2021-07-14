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
    public class ImageFileManager : IImageFileService
    {
        private IImageDal _imageDal;

        public ImageFileManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public ImageFile GetByID(int id)
        {
           return _imageDal.Get(c => c.ImageID == id);
        }

        public List<ImageFile> GetList()
        {
            return _imageDal.List();
        }

        public void ImageFileAddBL(ImageFile imageFile)
        {
            _imageDal.Insert(imageFile);
        }

        public void ImageFileDelete(ImageFile imageFile)
        {
           _imageDal.Delete(imageFile);
        }

        public void ImageFileUpdate(ImageFile imageFile)
        {
           _imageDal.Update(imageFile);
        }
    }
}
