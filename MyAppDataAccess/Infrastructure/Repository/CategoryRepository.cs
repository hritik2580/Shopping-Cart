using MyAppDataAccess.Infrastructure.IRepository;
using MyAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppDataAccess.Infrastructure.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            var categoryDB = _context.Categories.FirstOrDefault(x =>x.ID == category.ID);
            if(categoryDB != null)
            {
                categoryDB.Name=category.Name;
                categoryDB.DisplayOrder=category.DisplayOrder; 
            }

           _context.Categories.Update(category);
        }
    }
}
