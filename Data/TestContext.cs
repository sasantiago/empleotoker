using System.Collections.Generic;
using testoker.Models;
using Microsoft.EntityFrameworkCore;
namespace testoker.Data
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
