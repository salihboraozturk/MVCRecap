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
    public class MessageManager:IMessageService
    {
        private IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetListInbox()
        {
            return _messageDal.List(x=>x.ReceiverMail=="irem@gmail.com");
        }
        public List<Message> GetListSendbox()
        {
            return _messageDal.List(x => x.SenderMail == "irem@gmail.com");
        }

        public void MessageAddBL(Message message)
        {
           _messageDal.Insert(message);
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(c => c.MessageID == id);
        }

        public void MessageDelete(Message message)
        {
           _messageDal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
           _messageDal.Update(message);
        }
    }
}
