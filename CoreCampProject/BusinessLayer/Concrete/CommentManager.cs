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
    public class CommentManager : ICommentService
    {
        ICommentDal _commnetdal;

        public CommentManager(ICommentDal commnetdal)
        {
            _commnetdal = commnetdal;
        }

        public void CommentyAdd(Comment comment)
        {
            _commnetdal.Insert(comment);
        }

        public List<Comment> GetList(int id)
        {
            return _commnetdal.GetListAll(x => x.BlogID == id);
        }
    }
}
