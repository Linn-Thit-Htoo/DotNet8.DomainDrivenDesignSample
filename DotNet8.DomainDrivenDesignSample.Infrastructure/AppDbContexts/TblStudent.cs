﻿namespace DotNet8.DomainDrivenDesignSample.Infrastructure.AppDbContexts;

public partial class TblStudent
{
    public int StudentId { get; set; }

    public string StudentName { get; set; } = null!;

    public int Age { get; set; }

    public string Major { get; set; } = null!;

    public bool IsActive { get; set; }
}
