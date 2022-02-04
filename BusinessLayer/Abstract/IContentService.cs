using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetContents();
        List<Content> GetContentByHeading(int id);
        List<Content> GetContentByWriter();
        void AddContent(Content content);
        Content Get(int id);
        void DeleteContent(Content content);
        void UpdateContent(Content content);
    }
}
