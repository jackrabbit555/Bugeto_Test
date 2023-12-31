using Bugeto_Test.Application.Service.Products.Queries.GetCAtegories;
using Bugeto_Test.Application.Service.Services.Commands.AddNewCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Test.Application.Interfaces.FacadePatterns
{
    public interface IProductFacade
    {
        AddNewCategoryService AddNewCategoryService { get;  }
        IGetCategoriesService GetCategoriesService { get; }
    }
}
