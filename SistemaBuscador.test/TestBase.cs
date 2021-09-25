using Microsoft.EntityFrameworkCore;

namespace SistemaBuscador.test
{
    public class TestBase
    {
        protected ApplicationDbContext BuidContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(dbName).Options;

            var dbContext = new ApplicationDbContext(options);
            return dbContext;
        }
    }
}
