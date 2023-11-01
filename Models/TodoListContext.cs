using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace todoList_react.Models;

public partial class TodoListContext : DbContext
{
    public TodoListContext()
    {
    }

    public TodoListContext(DbContextOptions<TodoListContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.IdTask).HasName("PK__Task__C3E0F4DA684CC9DA");

            entity.ToTable("Task");

            entity.Property(e => e.IdTask).HasColumnName("idTask");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creationDate");
            entity.Property(e => e.TaskDetails)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("task_details");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
