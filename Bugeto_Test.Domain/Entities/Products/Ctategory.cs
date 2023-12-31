using Bugeto_Test.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Test.Domain.Entities.Products
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public virtual Category ParentCategory { get; set; }

        public long? ParentCategoryID {  get; set; } 


         // برای نمایش دسته ها هر گروه
        public virtual ICollection<Category> SubCategories {  get; set; }   
    }
}
