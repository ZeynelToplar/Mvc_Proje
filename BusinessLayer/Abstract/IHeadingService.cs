using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        //Ödev için bu şekilde yazıyorum , solid e uymadığının farkındayım.
        List<Heading> GetHeadings();
    }
}
