using Microsoft.EntityFrameworkCore;
using MyAppModels;

namespace MyAppDataAccess
{
    public class ApplicationDbContext : DbContext
    {
        //making contrustore and intialising Application Db file

        //also regestiring Dbset in program.csfile

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //through Db set intialising out category model in db set 

        public DbSet<Category> Categories { get; set; }


    }
}
