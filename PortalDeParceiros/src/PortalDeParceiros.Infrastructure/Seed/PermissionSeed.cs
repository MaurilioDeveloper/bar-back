using System;
using Microsoft.EntityFrameworkCore;
using PortalDeParceiros.Domain.Entity;

namespace PortalDeParceiros.Infrastructure.Seed
{
    public class PermissionSeed
    {
        public PermissionSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>().HasData(
                new Permission{Id = 1,  Partner = true,  GroupId = 1, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Cadastro de usuário"},
                new Permission{Id = 2,  Partner = true,  GroupId = 1, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Cadastro de empresa"},
                new Permission{Id = 3,  Partner = true,  GroupId = 1, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Editar usuário"},
                new Permission{Id = 4,  Partner = true,  GroupId = 1, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Editar empresa"},
                new Permission{Id = 5,  Partner = true,  GroupId = 1, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Conceder permissões as funcionalidades"},

                new Permission{Id = 6,  Partner = false, GroupId = 2, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Incluir comunicação"},
                new Permission{Id = 7,  Partner = true,  GroupId = 2, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Inativar comunicação"},
                new Permission{Id = 8,  Partner = false, GroupId = 2, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Programar comunicação"},
                new Permission{Id = 9,  Partner = false, GroupId = 2, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Editar comunicação "},

                new Permission{Id = 10, Partner = true,  GroupId = 3, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Listar campanhas"},
                new Permission{Id = 11, Partner = false, GroupId = 3, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Editar campanhas"},
                new Permission{Id = 12, Partner = false, GroupId = 3, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Editar menus do sistema"},
                new Permission{Id = 13, Partner = true,  GroupId = 3, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Editar arte"},
                new Permission{Id = 14, Partner = false, GroupId = 3, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Cadastrar campanhas"},
                new Permission{Id = 15, Partner = true,  GroupId = 3, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Inativar campanhas"},
                new Permission{Id = 16, Partner = false, GroupId = 3, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Upload de arte"},

                new Permission{Id = 17, Partner = true, GroupId = 4, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Exibir treinamento"},

                new Permission{Id = 18, Partner = false, GroupId = 5, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Informar comissão"},
                new Permission{Id = 19, Partner = false, GroupId = 5, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Aprovar nota fiscal"},
                new Permission{Id = 20, Partner = true,  GroupId = 5, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Upload de nota fiscal"},
                new Permission{Id = 21, Partner = false, GroupId = 5, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Upload de comprovante"},
                new Permission{Id = 22, Partner = true,  GroupId = 5, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Listar comissão"},
                new Permission{Id = 23, Partner = true,  GroupId = 5, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Inativar comissão"},

                new Permission{Id = 24, Partner = true, GroupId = 6, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Listar proposta"},
                new Permission{Id = 25, Partner = true, GroupId = 6, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Editar proposta"},
                new Permission{Id = 26, Partner = true, GroupId = 6, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Cadastrar proposta"},
                new Permission{Id = 27, Partner = true, GroupId = 6, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Inativar proposta"},

                new Permission{Id = 28, Partner = true, GroupId = 7, CreatedAt = DateTime.Now, LastUpdate = DateTime.Now, Description = "Acesso geral ao sistema"}
            );
        }
    }
}