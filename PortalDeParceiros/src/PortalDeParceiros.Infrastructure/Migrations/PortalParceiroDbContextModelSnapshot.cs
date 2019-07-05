﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PortalDeParceiros.Infrastructure.Configuration.Context;

namespace PortalDeParceiros.Infrastructure.Migrations
{
    [DbContext(typeof(PortalParceiroDbContext))]
    partial class PortalParceiroDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("PortalDeParceiros.Domain.Entity.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Cep")
                        .HasColumnType("varchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("City")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Cnpj");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<bool>("FirstAcess");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Observation")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("State")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<bool>("Status");

                    b.Property<int?>("UserCommercialId");

                    b.HasKey("Id");

                    b.HasIndex("UserCommercialId");

                    b.ToTable("company");

                    b.HasData(
                        new { Id = 1, Cep = "80250205", City = "Curitiba", Cnpj = "32683621000103", CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "BARIGUI SERVICOS DE APOIO A ESCRITORIOS LTDA", FirstAcess = true, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), State = "PR", Status = true }
                    );
                });

            modelBuilder.Entity("PortalDeParceiros.Domain.Entity.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("group");

                    b.HasData(
                        new { Id = 1, Description = "Administrativo" },
                        new { Id = 2, Description = "Comunicação" },
                        new { Id = 3, Description = "Marketing" },
                        new { Id = 4, Description = "Treinamento" },
                        new { Id = 5, Description = "Financeiro" },
                        new { Id = 6, Description = "Propostas" },
                        new { Id = 7, Description = "Master" }
                    );
                });

            modelBuilder.Entity("PortalDeParceiros.Domain.Entity.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("Varchar(255)")
                        .HasMaxLength(255);

                    b.Property<int?>("GroupId");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<bool>("Partner");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("permission");

                    b.HasData(
                        new { Id = 1, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 793, DateTimeKind.Local), Description = "Cadastro de usuário", GroupId = 1, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = true },
                        new { Id = 2, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Cadastro de empresa", GroupId = 1, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = true },
                        new { Id = 3, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Editar usuário", GroupId = 1, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = true },
                        new { Id = 4, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Editar empresa", GroupId = 1, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = true },
                        new { Id = 5, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Conceder permissões as funcionalidades", GroupId = 1, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = true },
                        new { Id = 6, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Incluir comunicação", GroupId = 2, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = false },
                        new { Id = 7, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Inativar comunicação", GroupId = 2, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = true },
                        new { Id = 8, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Programar comunicação", GroupId = 2, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = false },
                        new { Id = 9, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Editar comunicação ", GroupId = 2, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = false },
                        new { Id = 10, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Listar campanhas", GroupId = 3, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = true },
                        new { Id = 11, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Editar campanhas", GroupId = 3, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = false },
                        new { Id = 12, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Editar menus do sistema", GroupId = 3, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = false },
                        new { Id = 13, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Editar arte", GroupId = 3, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = true },
                        new { Id = 14, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Cadastrar campanhas", GroupId = 3, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = false },
                        new { Id = 15, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Inativar campanhas", GroupId = 3, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = true },
                        new { Id = 16, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Upload de arte", GroupId = 3, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = false },
                        new { Id = 17, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Exibir treinamento", GroupId = 4, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = true },
                        new { Id = 18, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Informar comissão", GroupId = 5, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = false },
                        new { Id = 19, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Aprovar nota fiscal", GroupId = 5, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = false },
                        new { Id = 20, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Upload de nota fiscal", GroupId = 5, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = true },
                        new { Id = 21, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Upload de comprovante", GroupId = 5, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = false },
                        new { Id = 22, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Listar comissão", GroupId = 5, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = true },
                        new { Id = 23, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Inativar comissão", GroupId = 5, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = true },
                        new { Id = 24, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Listar proposta", GroupId = 6, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = true },
                        new { Id = 25, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Editar proposta", GroupId = 6, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = true },
                        new { Id = 26, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Cadastrar proposta", GroupId = 6, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = true },
                        new { Id = 27, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Inativar proposta", GroupId = 6, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = true },
                        new { Id = 28, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Description = "Acesso geral ao sistema", GroupId = 7, LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 795, DateTimeKind.Local), Partner = true }
                    );
                });

            modelBuilder.Entity("PortalDeParceiros.Domain.Entity.Proposal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasMaxLength(11);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<decimal>("CreditValue");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<decimal>("PropertyPrice");

                    b.Property<int?>("StageId");

                    b.Property<bool>("Status");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("StageId");

                    b.HasIndex("UserId");

                    b.ToTable("proposal");
                });

            modelBuilder.Entity("PortalDeParceiros.Domain.Entity.ProposalDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("DocumentPath")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("DocumentType");

                    b.Property<int?>("ProposalsId");

                    b.HasKey("Id");

                    b.HasIndex("ProposalsId");

                    b.ToTable("proposalDocument");
                });

            modelBuilder.Entity("PortalDeParceiros.Domain.Entity.Stage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("stage");
                });

            modelBuilder.Entity("PortalDeParceiros.Domain.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Cep");

                    b.Property<bool>("ChangedPassword");

                    b.Property<string>("City");

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Cpf")
                        .HasColumnType("varchar(11)")
                        .HasMaxLength(11);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<bool>("Novi");

                    b.Property<string>("Observation");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Phone");

                    b.Property<string>("State");

                    b.Property<bool>("Status");

                    b.Property<int?>("UserLeaderId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserLeaderId");

                    b.ToTable("user");

                    b.HasData(
                        new { Id = 1, ChangedPassword = false, CompanyId = 1, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 818, DateTimeKind.Local), Email = "contabilidade@bariguipromotora.com.br", LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 818, DateTimeKind.Local), Name = "Master", Novi = true, Password = "5a3a11050192ba49cc5551ef3759391a", Status = true }
                    );
                });

            modelBuilder.Entity("PortalDeParceiros.Domain.Entity.UserPermission", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("PermissionId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("LastUpdate");

                    b.HasKey("UserId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("userpermission");

                    b.HasData(
                        new { UserId = 1, PermissionId = 1, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 818, DateTimeKind.Local), LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 818, DateTimeKind.Local) },
                        new { UserId = 1, PermissionId = 2, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 818, DateTimeKind.Local), LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 818, DateTimeKind.Local) },
                        new { UserId = 1, PermissionId = 3, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 818, DateTimeKind.Local), LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 818, DateTimeKind.Local) },
                        new { UserId = 1, PermissionId = 4, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 818, DateTimeKind.Local), LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 818, DateTimeKind.Local) },
                        new { UserId = 1, PermissionId = 5, CreatedAt = new DateTime(2019, 7, 3, 13, 44, 0, 818, DateTimeKind.Local), LastUpdate = new DateTime(2019, 7, 3, 13, 44, 0, 818, DateTimeKind.Local) }
                    );
                });

            modelBuilder.Entity("PortalDeParceiros.Domain.Entity.Company", b =>
                {
                    b.HasOne("PortalDeParceiros.Domain.Entity.User", "UserCommercial")
                        .WithMany()
                        .HasForeignKey("UserCommercialId");
                });

            modelBuilder.Entity("PortalDeParceiros.Domain.Entity.Permission", b =>
                {
                    b.HasOne("PortalDeParceiros.Domain.Entity.Group", "Group")
                        .WithMany("Permissions")
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("PortalDeParceiros.Domain.Entity.Proposal", b =>
                {
                    b.HasOne("PortalDeParceiros.Domain.Entity.Stage", "Stage")
                        .WithMany("Proposal")
                        .HasForeignKey("StageId");

                    b.HasOne("PortalDeParceiros.Domain.Entity.User", "User")
                        .WithMany("Proposals")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("PortalDeParceiros.Domain.Entity.ProposalDocument", b =>
                {
                    b.HasOne("PortalDeParceiros.Domain.Entity.Proposal", "Proposals")
                        .WithMany("ProposalDocuments")
                        .HasForeignKey("ProposalsId");
                });

            modelBuilder.Entity("PortalDeParceiros.Domain.Entity.User", b =>
                {
                    b.HasOne("PortalDeParceiros.Domain.Entity.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId");

                    b.HasOne("PortalDeParceiros.Domain.Entity.User", "UserLeader")
                        .WithMany()
                        .HasForeignKey("UserLeaderId");
                });

            modelBuilder.Entity("PortalDeParceiros.Domain.Entity.UserPermission", b =>
                {
                    b.HasOne("PortalDeParceiros.Domain.Entity.Permission", "Permission")
                        .WithMany("UserPermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PortalDeParceiros.Domain.Entity.User", "User")
                        .WithMany("UserPermissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}