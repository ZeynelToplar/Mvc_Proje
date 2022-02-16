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
    public class ContentManager : IContentService
    {
        IContentDal _contenDal;

        public ContentManager(IContentDal contenDal)
        {
            _contenDal = contenDal;
        }

        public void AddContent(Content content)
        {
            _contenDal.Add(content);
        }

        public void DeleteContent(Content content)
        {
            _contenDal.Delete(content);
        }

        public Content Get(int id)
        {
            return _contenDal.Get(x => x.ContentId == id);
        }

        public List<Content> GetContentByHeading(int id)
        {
            return _contenDal.GetAll(x => x.HeadingId == id);
        }

        public List<Content> GetContentByWriter(int id)
        {
            return _contenDal.GetAll(x => x.WriterId == id);
        }

        public List<Content> GetContents(string text)
        {
            return _contenDal.GetAll(x=>x.ContentValue.Contains(text));
        }

        public List<Content> GetContents()
        {
            return _contenDal.GetAll();
        }

        public void UpdateContent(Content content)
        {
            _contenDal.Update(content);
        }
    }
}
