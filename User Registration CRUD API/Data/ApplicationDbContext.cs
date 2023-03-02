using Microsoft.EntityFrameworkCore;
using User_Registration_CRUD_API.Models;

namespace User_Registration_CRUD_API.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            :base(options){
        }

        //Dbset is the representation of the table on DB 
        // it's there to let us manipulate from the table specified in <>

        public DbSet<user> user { get; set; }
    }
}
