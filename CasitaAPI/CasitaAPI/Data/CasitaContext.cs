using System;
using System.Collections.Generic;
using CasitaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CasitaAPI.Data;

public partial class CasitaContext : DbContext
{
    public CasitaContext()
    {
    }

    public CasitaContext(DbContextOptions<CasitaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppTask> AppTasks { get; set; }

    public virtual DbSet<Financial> Financials { get; set; }

    public virtual DbSet<Frequency> Frequencies { get; set; }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<ListItem> ListItems { get; set; }

    public virtual DbSet<ListType> ListTypes { get; set; }

    public virtual DbSet<Priority> Priorities { get; set; }

    public virtual DbSet<SpentModel> SpentModels { get; set; }

    public virtual DbSet<SpentType> SpentTypes { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionList> TransactionLists { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=NOTE17-S21\\SQLSERVER;Database=Casita;TrustServerCertificate=True;User Id=sa;pwd=Senai@134;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Task");

            entity.ToTable("AppTask");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.DueDate)
                .HasColumnType("datetime")
                .HasColumnName("due_date");
            entity.Property(e => e.FrequencyId).HasColumnName("frequency_id");
            entity.Property(e => e.ListId).HasColumnName("list_id");
            entity.Property(e => e.PriorityId).HasColumnName("priority_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.List).WithMany(p => p.AppTasks)
                .HasForeignKey(d => d.ListId)
                .HasConstraintName("FK_Task_List");

            entity.HasOne(d => d.Status).WithMany(p => p.AppTasks)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_Task_Statuses");
        });

        modelBuilder.Entity<Financial>(entity =>
        {
            entity.ToTable("Financial");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.Balance)
                .HasColumnType("money")
                .HasColumnName("balance");
            entity.Property(e => e.ReceiptDate).HasColumnName("receipt_date");
            entity.Property(e => e.SpentModelId).HasColumnName("spent_model_id");

            entity.HasOne(d => d.SpentModel).WithMany(p => p.Financials)
                .HasForeignKey(d => d.SpentModelId)
                .HasConstraintName("FK_Financial_SpentModel");
        });

        modelBuilder.Entity<Frequency>(entity =>
        {
            entity.ToTable("Frequency");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("description");
        });

        modelBuilder.Entity<List>(entity =>
        {
            entity.ToTable("List");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UserId)
                .HasMaxLength(36)
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Lists)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_List_User");
        });

        modelBuilder.Entity<ListItem>(entity =>
        {
            entity.ToTable("ListItem");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsConcluded).HasColumnName("is_concluded");
            entity.Property(e => e.ListId).HasColumnName("list_id");
            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PriorityId).HasColumnName("priority_id");
            entity.Property(e => e.Value)
                .HasColumnType("money")
                .HasColumnName("value");

            entity.HasOne(d => d.List).WithMany(p => p.ListItems)
                .HasForeignKey(d => d.ListId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ListItem_TransactionList");

            entity.HasOne(d => d.Priority).WithMany(p => p.ListItems)
                .HasForeignKey(d => d.PriorityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ListItem_Priority");
        });

        modelBuilder.Entity<ListType>(entity =>
        {
            entity.ToTable("ListType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Priority>(entity =>
        {
            entity.ToTable("Priority");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<SpentModel>(entity =>
        {
            entity.ToTable("SpentModel");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.NecessitiesPercentage)
                .HasColumnType("decimal(3, 0)")
                .HasColumnName("necessities_percentage");
            entity.Property(e => e.SavingsPercentage)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("savings_percentage");
            entity.Property(e => e.WantsPercentage)
                .HasColumnType("decimal(3, 0)")
                .HasColumnName("wants_percentage");
        });

        modelBuilder.Entity<SpentType>(entity =>
        {
            entity.ToTable("SpentType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.ToTable("Transaction");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.FrequencyId).HasColumnName("frequency_id");
            entity.Property(e => e.ListId).HasColumnName("list_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Value)
                .HasColumnType("money")
                .HasColumnName("value");

            entity.HasOne(d => d.Frequency).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.FrequencyId)
                .HasConstraintName("FK_Transaction_Frequency");

            entity.HasOne(d => d.List).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.ListId)
                .HasConstraintName("FK_Transaction_TransactionList");
        });

        modelBuilder.Entity<TransactionList>(entity =>
        {
            entity.ToTable("TransactionList");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AmountSpent)
                .HasColumnType("money")
                .HasColumnName("amount_spent");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.FinantialId)
                .HasMaxLength(36)
                .HasColumnName("finantial_id");
            entity.Property(e => e.ListTypeD).HasColumnName("list_type_d");
            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(128)
                .HasColumnName("photo_url");
            entity.Property(e => e.PriorityId).HasColumnName("priority_id");
            entity.Property(e => e.SpentTypeId).HasColumnName("spent_type_id");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("money")
                .HasColumnName("total_amount");

            entity.HasOne(d => d.Finantial).WithMany(p => p.TransactionLists)
                .HasForeignKey(d => d.FinantialId)
                .HasConstraintName("FK_TransactionList_Financial");

            entity.HasOne(d => d.ListTypeDNavigation).WithMany(p => p.TransactionLists)
                .HasForeignKey(d => d.ListTypeD)
                .HasConstraintName("FK_TransactionList_ListType");

            entity.HasOne(d => d.Priority).WithMany(p => p.TransactionLists)
                .HasForeignKey(d => d.PriorityId)
                .HasConstraintName("FK_TransactionList_Priority");

            entity.HasOne(d => d.SpentType).WithMany(p => p.TransactionLists)
                .HasForeignKey(d => d.SpentTypeId)
                .HasConstraintName("FK_TransactionList_SpentType");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_user");

            entity.ToTable("User");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(128)
                .HasColumnName("photo_url");
            entity.Property(e => e.RecoveryCode)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("recovery_code");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.User)
                .HasForeignKey<User>(d => d.Id)
                .HasConstraintName("FK_User_Financial");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
