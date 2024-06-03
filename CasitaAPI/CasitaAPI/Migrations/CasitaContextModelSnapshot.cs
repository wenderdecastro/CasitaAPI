﻿// <auto-generated />
using System;
using CasitaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CasitaAPI.Migrations
{
    [DbContext(typeof(CasitaContext))]
    partial class CasitaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CasitaAPI.Models.AppTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("description");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime")
                        .HasColumnName("due_date");

                    b.Property<int?>("FrequencyId")
                        .HasColumnType("int")
                        .HasColumnName("frequency_id");

                    b.Property<bool?>("IsConcluded")
                        .HasColumnType("bit")
                        .HasColumnName("is_concluded");

                    b.Property<int?>("ListId")
                        .HasColumnType("int")
                        .HasColumnName("list_id");

                    b.Property<int?>("PriorityId")
                        .HasColumnType("int")
                        .HasColumnName("priority_id");

                    b.HasKey("Id")
                        .HasName("PK_Task");

                    b.HasIndex("ListId");

                    b.ToTable("AppTask", (string)null);
                });

            modelBuilder.Entity("CasitaAPI.Models.Financial", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<decimal>("Balance")
                        .HasColumnType("money")
                        .HasColumnName("balance");

                    b.Property<decimal>("NecessitiesPercentage")
                        .HasColumnType("decimal(3, 2)")
                        .HasColumnName("necessities_percentage");

                    b.Property<DateOnly?>("ReceiptDate")
                        .HasColumnType("date")
                        .HasColumnName("receipt_date");

                    b.Property<decimal>("SavingsPercentage")
                        .HasColumnType("decimal(3, 2)")
                        .HasColumnName("savings_percentage");

                    b.Property<decimal>("WantsPercentage")
                        .HasColumnType("decimal(3, 2)")
                        .HasColumnName("wants_percentage");

                    b.HasKey("Id");

                    b.ToTable("Financial", (string)null);
                });

            modelBuilder.Entity("CasitaAPI.Models.Frequency", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("description")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("Frequency", (string)null);
                });

            modelBuilder.Entity("CasitaAPI.Models.List", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description")
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("List", (string)null);
                });

            modelBuilder.Entity("CasitaAPI.Models.ListItem", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<bool?>("IsConcluded")
                        .HasColumnType("bit")
                        .HasColumnName("is_concluded");

                    b.Property<int>("ListId")
                        .HasColumnType("int")
                        .HasColumnName("list_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("name");

                    b.Property<int>("PriorityId")
                        .HasColumnType("int")
                        .HasColumnName("priority_id");

                    b.Property<decimal?>("Value")
                        .HasColumnType("money")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("ListId");

                    b.HasIndex("PriorityId");

                    b.ToTable("ListItem", (string)null);
                });

            modelBuilder.Entity("CasitaAPI.Models.ListType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("description");

                    b.HasKey("Id");

                    b.ToTable("ListType", (string)null);
                });

            modelBuilder.Entity("CasitaAPI.Models.Priority", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("description");

                    b.HasKey("Id");

                    b.ToTable("Priority", (string)null);
                });

            modelBuilder.Entity("CasitaAPI.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("FrequencyId")
                        .HasColumnType("int")
                        .HasColumnName("frequency_id");

                    b.Property<int?>("ListId")
                        .HasColumnType("int")
                        .HasColumnName("list_id");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<decimal?>("Value")
                        .HasColumnType("money")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("FrequencyId");

                    b.HasIndex("ListId");

                    b.ToTable("Transaction", (string)null);
                });

            modelBuilder.Entity("CasitaAPI.Models.TransactionList", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<decimal?>("AmountSpent")
                        .HasColumnType("money")
                        .HasColumnName("amount_spent");

                    b.Property<DateOnly?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("FinantialId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("finantial_id");

                    b.Property<int?>("ListTypeId")
                        .HasColumnType("int")
                        .HasColumnName("list_type_id");

                    b.Property<string>("Name")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("name");

                    b.Property<string>("PhotoUrl")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("photo_url");

                    b.Property<int?>("PriorityId")
                        .HasColumnType("int")
                        .HasColumnName("priority_id");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("money")
                        .HasColumnName("total_amount");

                    b.HasKey("Id");

                    b.HasIndex("FinantialId");

                    b.HasIndex("ListTypeId");

                    b.HasIndex("PriorityId");

                    b.ToTable("TransactionList", (string)null);
                });

            modelBuilder.Entity("CasitaAPI.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateOnly>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(36)
                        .IsUnicode(false)
                        .HasColumnType("varchar(36)")
                        .HasColumnName("password");

                    b.Property<string>("PhotoUrl")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("photo_url");

                    b.Property<string>("RecoveryCode")
                        .HasMaxLength(4)
                        .IsUnicode(false)
                        .HasColumnType("char(4)")
                        .HasColumnName("recovery_code")
                        .IsFixedLength();

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("PK_user");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("CasitaAPI.Models.AppTask", b =>
                {
                    b.HasOne("CasitaAPI.Models.List", "List")
                        .WithMany("AppTasks")
                        .HasForeignKey("ListId")
                        .HasConstraintName("FK_Task_List");

                    b.Navigation("List");
                });

            modelBuilder.Entity("CasitaAPI.Models.List", b =>
                {
                    b.HasOne("CasitaAPI.Models.User", "User")
                        .WithMany("Lists")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_List_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CasitaAPI.Models.ListItem", b =>
                {
                    b.HasOne("CasitaAPI.Models.TransactionList", "List")
                        .WithMany("ListItems")
                        .HasForeignKey("ListId")
                        .IsRequired()
                        .HasConstraintName("FK_ListItem_TransactionList1");

                    b.HasOne("CasitaAPI.Models.Priority", "Priority")
                        .WithMany("ListItems")
                        .HasForeignKey("PriorityId")
                        .IsRequired()
                        .HasConstraintName("FK_ListItem_Priority");

                    b.Navigation("List");

                    b.Navigation("Priority");
                });

            modelBuilder.Entity("CasitaAPI.Models.Transaction", b =>
                {
                    b.HasOne("CasitaAPI.Models.Frequency", "Frequency")
                        .WithMany("Transactions")
                        .HasForeignKey("FrequencyId")
                        .HasConstraintName("FK_Transaction_Frequency");

                    b.HasOne("CasitaAPI.Models.TransactionList", "List")
                        .WithMany("Transactions")
                        .HasForeignKey("ListId")
                        .HasConstraintName("FK_Transaction_TransactionList");

                    b.Navigation("Frequency");

                    b.Navigation("List");
                });

            modelBuilder.Entity("CasitaAPI.Models.TransactionList", b =>
                {
                    b.HasOne("CasitaAPI.Models.Financial", "Finantial")
                        .WithMany("TransactionLists")
                        .HasForeignKey("FinantialId")
                        .HasConstraintName("FK_TransactionList_Financial");

                    b.HasOne("CasitaAPI.Models.ListType", "ListType")
                        .WithMany("TransactionLists")
                        .HasForeignKey("ListTypeId")
                        .HasConstraintName("FK_TransactionList_ListType");

                    b.HasOne("CasitaAPI.Models.Priority", "Priority")
                        .WithMany("TransactionLists")
                        .HasForeignKey("PriorityId")
                        .HasConstraintName("FK_TransactionList_Priority");

                    b.Navigation("Finantial");

                    b.Navigation("ListType");

                    b.Navigation("Priority");
                });

            modelBuilder.Entity("CasitaAPI.Models.User", b =>
                {
                    b.HasOne("CasitaAPI.Models.Financial", "IdNavigation")
                        .WithOne("User")
                        .HasForeignKey("CasitaAPI.Models.User", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_User_Financial");

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("CasitaAPI.Models.Financial", b =>
                {
                    b.Navigation("TransactionLists");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CasitaAPI.Models.Frequency", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("CasitaAPI.Models.List", b =>
                {
                    b.Navigation("AppTasks");
                });

            modelBuilder.Entity("CasitaAPI.Models.ListType", b =>
                {
                    b.Navigation("TransactionLists");
                });

            modelBuilder.Entity("CasitaAPI.Models.Priority", b =>
                {
                    b.Navigation("ListItems");

                    b.Navigation("TransactionLists");
                });

            modelBuilder.Entity("CasitaAPI.Models.TransactionList", b =>
                {
                    b.Navigation("ListItems");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("CasitaAPI.Models.User", b =>
                {
                    b.Navigation("Lists");
                });
#pragma warning restore 612, 618
        }
    }
}