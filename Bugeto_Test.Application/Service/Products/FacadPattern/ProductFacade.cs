using Bugeto_Test.Application.Interfaces.Context;
using Bugeto_Test.Application.Interfaces.FacadePatterns;
using Bugeto_Test.Application.Service.Products.Queries.GetCAtegories;
using Bugeto_Test.Application.Service.Services.Commands.AddNewCategory;
using Bugeto_Test.Application.Service.Users.Quereis.GetRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Test.Application.Service.Products.FacadPattern
{
    public class ProductFacade : IProductFacade
    {
        private readonly IDataBaseContext _context;
        public ProductFacade(IDataBaseContext context )
        {
            _context = context;
        }

        private AddNewCategoryService _addNewCategory;
        public AddNewCategoryService AddNewCategoryService
        { get 
            {  
                return _addNewCategory = _addNewCategory ?? new AddNewCategoryService(_context); 
            } 
        }

        private IGetCategoriesService _getCategoriesService;
        public IGetCategoriesService GetCategoriesService
        {

            get 
            {
                return _getCategoriesService = _getCategoriesService ?? new GetCategoriesService(_context);  
            }
        }
    }
}
