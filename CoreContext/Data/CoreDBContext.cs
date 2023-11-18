﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using CoreContext.Models;
using Microsoft.EntityFrameworkCore;

#nullable enable

namespace CoreContext.Data;

public partial class CoreDBContext : DbContext
{
    public CoreDBContext()
    {
    }

    public CoreDBContext(DbContextOptions<CoreDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Reason> Reasons { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Source> Sources { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Configurations.CompanyConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.ReasonConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.RoleConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.SourceConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.UserConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
