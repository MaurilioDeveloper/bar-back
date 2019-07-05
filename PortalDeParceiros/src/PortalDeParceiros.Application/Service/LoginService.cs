using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using PortalDeParceiros.Application.IService;
using PortalDeParceiros.Domain.Entity;
using PortalDeParceiros.Dto.Model;
using PortalDeParceiros.Infrastructure.IRepository;

namespace PortalDeParceiros.Application.Service
{
    public class LoginService : ILoginService
    {
        public readonly ILoginRepository _repository; 
        public readonly IUserRepository _repositoryUser;
        private readonly IEmailService _serviceEmail;
        private readonly IMapper _mapper;
        
        public LoginService(ILoginRepository repository, 
            IEmailService serviceEmail,
            IUserRepository repositoryUser, 
            IMapper mapper)
        {
               _repository = repository; 
               _serviceEmail = serviceEmail;
               _repositoryUser = repositoryUser;
               _mapper = mapper;
        }

        public async Task<UserDto> GetLogin(UserDto userValidation)
        {
            userValidation.Password = EncryptPassword(userValidation.Password);

            var user = await _repository.GetLogin(userValidation);

            if(user == null)
                throw new ArgumentException("Login inválido");

            if(user.UserPermissionsDto == null)
                user.UserPermissionsDto = new List<UserPermissionDto>();

            return user;
        }

        public void UpdatePassword(UserDto user, bool ConfirmPassword = false)
        {
            if(ConfirmPassword && user.Password != user.ConfirmPassword)
                throw new ArgumentException("Senha não confere");

            //Obrigatorio letra e número. Acesta caractres !@#$%¨&*()-+=/*<>,.?
            Regex rgx = new Regex("(?=.*[a-zA-Z])(?=.*[0-9])([a-zA-Z0-9!@#$%¨&*()-+=/*<>,.?]{6})");

            if(!rgx.IsMatch(user.Password))
                throw new ArgumentException("Deve conter no mínimo 6 caracteres de letras e números. Caracteres permitidos !@#$%¨&*()-+=/*<>,.?");
                
            var password = EncryptPassword(user.Password);
            var changed = user.ChangedPassword;
            var emailDto = user.EmailDto;

            user = _repositoryUser.GetUser(user.Id).Result; 

            if(user  == null)
                throw new ArgumentException("Usuário não localizado");

            user.LastUpdate = DateTime.Now;
            user.Password = password;
            user.ChangedPassword = changed;   
            user.EmailDto = emailDto;           

            _repository.UpdateAsync(_mapper.Map<User>(user));

            if(user.EmailDto != null)
                _serviceEmail.SendEmailResetUser(user.EmailDto);
        }

        public string GeneratePassward()
        {
            return "Bari" 
                + DateTime.Now.Second 
                + DateTime.Now.Millisecond; 
        }

        public string EncryptPassword(string password)
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