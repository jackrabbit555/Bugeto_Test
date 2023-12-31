namespace Bugeto_Test.Application.Service.Products.Queries.GetCAtegories
{
    public class CategoriesDTO 
    {
        public long Id { get; set; }    
        public string Name { get; set; }    
        public bool HasChild {  get; set; }
        public ParentCategoryDTO Parent {  get; set; }

    }
}
