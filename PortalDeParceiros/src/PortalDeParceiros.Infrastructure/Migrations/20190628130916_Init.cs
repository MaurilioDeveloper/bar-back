using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PortalDeParceiros.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "group",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "stage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "permission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(type: "Varchar(255)", maxLength: 255, nullable: false),
                    Partner = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    GroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permission_group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true),
                    Password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(nullable: true),
                    Observation = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Novi = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    UserLeaderId = table.Column<int>(nullable: true),
                    ChangedPassword = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_user_UserLeaderId",
                        column: x => x.UserLeaderId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cnpj = table.Column<string>(nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    State = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Cep = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true),
                    Observation = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    FirstAcess = table.Column<bool>(nullable: false),
                    UserCommercialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_company_user_UserCommercialId",
                        column: x => x.UserCommercialId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "proposal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    ClientName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    PropertyPrice = table.Column<decimal>(nullable: false),
                    CreditValue = table.Column<decimal>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    StageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proposal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_proposal_stage_StageId",
                        column: x => x.StageId,
                        principalTable: "stage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_proposal_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "userpermission",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    PermissionId = table.Column<int>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userpermission", x => new { x.UserId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_userpermission_permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userpermission_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "proposalDocument",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocumentPath = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    DocumentType = table.Column<int>(nullable: false),
                    ProposalsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proposalDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_proposalDocument_proposal_ProposalsId",
                        column: x => x.ProposalsId,
                        principalTable: "proposal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "company",
                columns: new[] { "Id", "Cep", "City", "Cnpj", "CreatedAt", "Description", "FirstAcess", "LastUpdate", "Observation", "State", "Status", "UserCommercialId" },
                values: new object[] { 1, "80250205", "Curitiba", "32683621000103", new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "BARIGUI SERVICOS DE APOIO A ESCRITORIOS LTDA", true, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), null, "PR", true, null });

            migrationBuilder.InsertData(
                table: "group",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Administrativo" },
                    { 2, "Comunicação" },
                    { 3, "Marketing" },
                    { 4, "Treinamento" },
                    { 5, "Financeiro" },
                    { 6, "Propostas" },
                    { 7, "Master" }
                });

            migrationBuilder.InsertData(
                table: "permission",
                columns: new[] { "Id", "CreatedAt", "Description", "GroupId", "LastUpdate", "Partner" },
                values: new object[,]
                {
                    { 14, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Cadastrar campanhas", 3, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 26, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Cadastrar proposta", 6, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 25, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Editar proposta", 6, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 24, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Listar proposta", 6, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 23, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Inativar comissão", 5, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 22, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Listar comissão", 5, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 21, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Upload de comprovante", 5, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 20, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Upload de nota fiscal", 5, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 19, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Aprovar nota fiscal", 5, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 18, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Informar comissão", 5, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 17, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Exibir treinamento", 4, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 16, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Upload de arte", 3, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 15, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Inativar campanhas", 3, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 27, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Inativar proposta", 6, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 28, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Acesso geral ao sistema", 7, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 12, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Editar menus do sistema", 3, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 11, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Editar campanhas", 3, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 10, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Listar campanhas", 3, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 9, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Editar comunicação ", 2, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 8, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Programar comunicação", 2, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 7, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Inativar comunicação", 2, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 6, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Incluir comunicação", 2, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 5, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Conceder permissões as funcionalidades", 1, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 4, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Editar empresa", 1, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 3, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Editar usuário", 1, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 2, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Cadastro de empresa", 1, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 1, new DateTime(2019, 6, 28, 10, 9, 15, 965, DateTimeKind.Local), "Cadastro de usuário", 1, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true },
                    { 13, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), "Editar arte", 3, new DateTime(2019, 6, 28, 10, 9, 15, 967, DateTimeKind.Local), true }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "Cep", "ChangedPassword", "City", "CompanyId", "Cpf", "CreatedAt", "Email", "LastUpdate", "Name", "Novi", "Observation", "Password", "Phone", "State", "Status", "UserLeaderId" },
                values: new object[] { 1, null, false, null, 1, null, new DateTime(2019, 6, 28, 10, 9, 15, 971, DateTimeKind.Local), "contabilidade@bariguipromotora.com.br", new DateTime(2019, 6, 28, 10, 9, 15, 971, DateTimeKind.Local), "Master", true, null, "5a3a11050192ba49cc5551ef3759391a", null, null, true, null });

            migrationBuilder.InsertData(
                table: "userpermission",
                columns: new[] { "UserId", "PermissionId", "CreatedAt", "LastUpdate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 6, 28, 10, 9, 15, 972, DateTimeKind.Local), new DateTime(2019, 6, 28, 10, 9, 15, 972, DateTimeKind.Local) },
                    { 1, 2, new DateTime(2019, 6, 28, 10, 9, 15, 972, DateTimeKind.Local), new DateTime(2019, 6, 28, 10, 9, 15, 972, DateTimeKind.Local) },
                    { 1, 3, new DateTime(2019, 6, 28, 10, 9, 15, 972, DateTimeKind.Local), new DateTime(2019, 6, 28, 10, 9, 15, 972, DateTimeKind.Local) },
                    { 1, 4, new DateTime(2019, 6, 28, 10, 9, 15, 972, DateTimeKind.Local), new DateTime(2019, 6, 28, 10, 9, 15, 972, DateTimeKind.Local) },
                    { 1, 5, new DateTime(2019, 6, 28, 10, 9, 15, 972, DateTimeKind.Local), new DateTime(2019, 6, 28, 10, 9, 15, 972, DateTimeKind.Local) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_company_UserCommercialId",
                table: "company",
                column: "UserCommercialId");

            migrationBuilder.CreateIndex(
                name: "IX_permission_GroupId",
                table: "permission",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_proposal_StageId",
                table: "proposal",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_proposal_UserId",
                table: "proposal",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_proposalDocument_ProposalsId",
                table: "proposalDocument",
                column: "ProposalsId");

            migrationBuilder.CreateIndex(
                name: "IX_user_CompanyId",
                table: "user",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_user_UserLeaderId",
                table: "user",
                column: "UserLeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_userpermission_PermissionId",
                table: "userpermission",
                column: "PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_company_CompanyId",
                table: "user",
                column: "CompanyId",
                principalTable: "company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_company_user_UserCommercialId",
                table: "company");

            migrationBuilder.DropTable(
                name: "proposalDocument");

            migrationBuilder.DropTable(
                name: "userpermission");

            migrationBuilder.DropTable(
                name: "proposal");

            migrationBuilder.DropTable(
                name: "permission");

            migrationBuilder.DropTable(
                name: "stage");

            migrationBuilder.DropTable(
                name: "group");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "company");
        }
    }
}
