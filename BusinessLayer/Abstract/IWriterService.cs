using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        void WriterAddBL(Writer writer);
        Writer GetByID(int id);
        void WriterDelete(Writer writer);
        void WriterUpdate(Writer writer);
    }
}
