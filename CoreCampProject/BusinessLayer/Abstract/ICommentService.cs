﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface ICommentService
    {
        void CommentyAdd(Comment comment);
        //void CategoryDelete(Category category);
        //void CategoryUpdate(Category category);
        //Category GetById(int id);
        List<Comment> GetList(int id);
    }
}
