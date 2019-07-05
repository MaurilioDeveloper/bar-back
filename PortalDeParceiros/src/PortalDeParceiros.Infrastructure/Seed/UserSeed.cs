using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PortalDeParceiros.Domain.Entity;

namespace PortalDeParceiros.Infrastructure.Seed
{
    public class UserSeed
    {
        public UserSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1, 
                    Email = "contabilidade@bariguipromotora.com.br",
                    Password = EncryptPassword("Master4781"),
                    Name = "Master",
                    Status = true,
                    Novi = true, 
                    CompanyId = 1,
                    CreatedAt = DateTime.Now,
                    LastUpdate = DateTime.Now
                }
            );
        }
        private string EncryptPassword(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();  

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));  
        
            byte[] result = md5.Hash;  

            StringBuilder strBuilder = new StringBuilder();  
            for (int i = 0; i < result.Length; i++)  
            {  
                strBuilder.Append(result[i].ToString("x2"));  
            }  

            return strBuilder.ToString();
        }
    }
}