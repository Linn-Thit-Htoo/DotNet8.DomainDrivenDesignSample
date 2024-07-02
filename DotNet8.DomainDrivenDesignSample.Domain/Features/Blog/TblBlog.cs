using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet8.DomainDrivenDesignSample.Domain.Features.Blog;

[Table("Tbl_Blog")]
public class TblBlog
{
    [Key]
    public int BlogId { get; set; }

    public string? BlogTitle { get; set; }

    public string? BlogAuthor { get; set; }

    public string? BlogContent { get; set; }
}
