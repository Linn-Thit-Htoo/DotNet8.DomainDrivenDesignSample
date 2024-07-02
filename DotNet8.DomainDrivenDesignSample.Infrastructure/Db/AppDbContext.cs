namespace DotNet8.DomainDrivenDesignSample.Infrastructure.Db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options)
        : base(options) { }

    public DbSet<TblBlog> TblBlogs { get; set; }
}
