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

        public List<Message> GetListInbox(String receiverMail)
        {
            return _messageDal.List(x=>x.ReceiverMail== receiverMail);
        }
        public List<Message> GetListSendbox(String senderMail)
        {
            return _messageDal.List(x => x.SenderMail == senderMail);
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
