using Buget_Test.Common.DTO;
using Bugeto_Test.Application.Interfaces.Context;
using Bugeto_Test.Domain.Entities.Products;

namespace Bugeto_Test.Application.Service.Services.Commands.AddNewCategory
{
    public class AddNewCategoryService : IAddNewCategoryService
    {
        private readonly IDataBaseContext _context;
        public AddNewCategoryService(IDataBaseContext context)
        {
            _context = context;
        }


        public ResultDTO Execute(long? ParentID, string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return new ResultDTO()
                {
                    IsSuccess = false,
                    Message = "نام دسته بندی را وارد نمایید",
                };
            }
            Category category = new Category() 
            {
                Name = Name,
                ParentCategory = GetParent(ParentID)
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return new ResultDTO()
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت اضافه شد",
            };
        }

        private Category GetParent(long? ParentID) 
        {
            return _context.Categories.Find(ParentID);

        }

    }
}
