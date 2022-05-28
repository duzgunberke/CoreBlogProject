using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı boş geçilemez");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori adı 3 karakteri geçmeli");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Kategori adı 20 karakteri geçemez");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklaması boş geçilemez");
            RuleFor(x => x.CategoryDescription).MinimumLength(5).WithMessage("Kategori açıklaması 5 karakteri geçmeli");
        }
    }
}
