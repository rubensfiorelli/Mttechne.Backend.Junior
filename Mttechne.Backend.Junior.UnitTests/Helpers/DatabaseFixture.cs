using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.Services.Data;

namespace Mttechne.Backend.Junior.UnitTests.Helpers
{
    public class DatabaseFixture
    {
        private const string _connectionString = "Server=tcp:free-tests-db.database.windows.net,1433;Database=shop_test;Persist Security Info=False;User ID=rubensfiorelli;Password=Master77$$;Trusted_Connection=False;Encrypt=True;TrustServerCertificate=True";
        public ApplicationDbContext CreateContext()
        {

            return new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(_connectionString).Options);
        }


    }
}
