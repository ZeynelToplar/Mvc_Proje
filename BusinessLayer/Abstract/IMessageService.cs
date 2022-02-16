﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetMessagesInbox(string mail);
        List<Message> GetMessagesSenbox(string mail);
        List<Message> GetUnreadMessage(string mail);
        List<Message> GetDrafts(string mail);
        void AddMessage(Message message);
        Message GetById(int id);
        void DeleteMessage(Message message);
        void UpdateMessage(Message message);
    }
}
