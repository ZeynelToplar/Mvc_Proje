using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetMessagesInbox();
        List<Message> GetMessagesSenbox();
        void AddMessage(Message message);
        Message GetById(int id);
        void DeleteMessage(Message message);
        void UpdateMessage(Message message);
    }
}
