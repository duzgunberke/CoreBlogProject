using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(X => X.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş geçilemez");
            RuleFor(X => X.BlogTitle).MinimumLength(10).WithMessage("Blog başlığı 10 karakteri geçmeli");
            RuleFor(X => X.BlogContent).NotEmpty().WithMessage("Blog içeriği boş geçilemez");
            RuleFor(X => X.BlogImage).NotEmpty().WithMessage("Blog görseli boş geçilemez");
            RuleFor(X => X.BlogContent).MinimumLength(150).WithMessage("Blog 150 karakteri geçmeli");
            RuleFor(X => X.BlogContent).MaximumLength(15000).WithMessage("Blog 15000 karakteri geçemez");
            //RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Blog kategorisi boş geçilemez");
        }
    }
}
