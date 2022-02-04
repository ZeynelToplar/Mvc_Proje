using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void AddMessage(Message message)
        {
            _messageDal.Add(message);
        }

        public void DeleteMessage(Message message)
        {
            _messageDal.Delete(message);
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public List<Message> GetDrafts()
        {
            return _messageDal.GetAll(x => x.SenderMail == "masil@hotmail.com").Where(x => x.IsDraft).ToList();
        }

        public List<Message> GetMessagesInbox()
        {
            return _messageDal.GetAll(x => x.ReceiverMail == "masil@hotmail.com");
        }

        public List<Message> GetMessagesSenbox()
        {
            return _messageDal.GetAll(x => x.SenderMail == "masil@hotmail.com").Where(x=>x.IsDraft==false).ToList();

        }

        public List<Message> GetUnreadMessage()
        {
            return _messageDal.GetAll(x => x.SenderMail == "masil@hotmail.com").Where(x => x.UnRead).ToList();
        }

        public void UpdateMessage(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
