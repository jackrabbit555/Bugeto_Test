using Buget_Test.Common.DTO;
using Bugeto_Test.Application.Interfaces.Context;
using Microsoft.EntityFrameworkCore;

namespace Bugeto_Test.Application.Service.Products.Queries.GetCAtegories
{
    public class GetCategoriesService : IGetCategoriesService
    {

        private readonly IDataBaseContext _context;
        public GetCategoriesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<CategoriesDTO>> Execute(long? ParentId)
        {
            var categories = _context.Categories
                            .Include(p => p.ParentCategory)
                            .Include(p => p.SubCategories)
                            .Where  (p => p.ParentCategoryID == ParentId)
                            .ToList ()
                            .Select (p => new CategoriesDTO
                            {
                                Id = p.ID,
                                Name = p.Name,
                                Parent = p.ParentCategoryID !=null? new 
                                ParentCategoryDTO 
                                {
                                    ID = p.ParentCategory.ID,
                                    Name = p.ParentCategory.Name
                                }
                                :null,
                                HasChild = p.SubCategories.Count() >0?true :false,

                            }).ToList();
            return new ResultDTO<List<CategoriesDTO>>()
            {
                Data = categories,
                IsSuccess = true,
                Message = "لیست باموقیت برگشت داده شد"
            };
        }
    }
}
