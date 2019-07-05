using System;
using System.Threading.Tasks;
using PortalDeParceiros.Application.IService;
using PortalDeParceiros.Dto.Model;
using PortalDeParceiros.Infrastructure.IRepository;
using AutoMapper;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PortalDeParceiros.Application.Service
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _repository; 
        private readonly IPermissionRepository _repositoryPermission;
        private readonly IUserPermissionRepository _repositoryUserPermission;
        private readonly ILoginService _serviceLogin;
        private readonly IEmailService _serviceEmail;
        private readonly IMapper _mapper;
        
        public UserService(IUserRepository repository, 
            IPermissionRepository repositoryPermission,
            IUserPermissionRepository repositoryUserPermission,
            ILoginService serviceLogin,
            IEmailService serviceEmail,
            IMapper mapper)
        {
            _repository = repository; 
            _repositoryPermission = repositoryPermission;
            _repositoryUserPermission = repositoryUserPermission;
            _serviceLogin = serviceLogin;
            _serviceEmail = serviceEmail;
            _mapper = mapper;
        }
        public async Task<UserDto> GetUser(int Id)
        {
            var user = await _repository.GetUser(Id);

            return user;
        }

        public void UpdateUserAndPassword(UserDto user)
        {
            _repository.UpdateUserAndPassword(user);
        }
        public async Task<bool> UpdateUser(UserDto user)
        {
            if(await _repository.GetUser(user.Id) == null)
                throw new ArgumentException("Usuário não localizado");

            Regex rg = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");

            if(!rg.IsMatch(user.Email))
                throw new ArgumentException("Email inválido");

            user.LastUpdate = DateTime.Now;

            _repository.UpdateUser(user);

            return true;
        }

        public void InsertUser(UserDto user)
        {
            if(GetuserByEmail(user).Result != null)
                throw new ArgumentException("Usuário já cadastrado");

            var password = _serviceLogin.GeneratePassward();
            var master = !_repository.HasUserByIdCompany(user.CompanyId ?? 0).Result;

            user = UserValidateInsert(user, master && (user.CompanyId ?? 0) > 0);

            _repository.InsertUser(user);
            _serviceEmail.SendEmailNewUser(user.EmailDto);
        }
        public async Task<UserDto> GetUserByEmailCpf(UserDto user)
        {
            return await _repository.GetUserByEmailCpf(user);
        }
        public async Task<UserDto> GetuserByEmail(UserDto user)
        {
            return await _repository.GetuserByEmail(user);
        }
        public UserDto UserValidateInsert(UserDto user, bool master = false)
        {
            Regex rg = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");

            if(!rg.IsMatch(user.Email))
                throw new ArgumentException("Email inválido");

            if(user == null)
                throw new ArgumentException("Usário Nulo ou já cadastrado");

            if(_repository.GetuserByEmail(user).Result != null)
                throw new ArgumentException($"Usuário: {user.Name} Email: {user.Email} já cadastrado");

            if(user.UserLeaderIdDto != 0 && user.UserLeaderIdDto != null )
            {
                user.UserLeaderDto = _repository.GetUser(user.UserLeaderIdDto.Value).Result
                    ?? throw new ArgumentException("Lider não lozalizado");
            }

            var password = _serviceLogin.GeneratePassward();

            user.Password = _serviceLogin.EncryptPassword(password);
            user.Novi = user.CompanyId == 1;
            user.CreatedAt = DateTime.Now;
            user.LastUpdate = DateTime.Now;
            user.Status = true;
            user.EmailDto = new EmailDto()
            {
                Name = user.Name,
                Email = user.Email,
                Password = password
            };
            
            if(master)
            {
                user.UserPermissionsDto = new List<UserPermissionDto>();		
			
	            _repositoryPermission		
	            .GetPermissions(!user.Novi)		
	            .Result		
	            .ForEach(x => user.UserPermissionsDto.Add(		
	                new UserPermissionDto		
	                {		
	                    PermissionId = x.Id,		
	                    LastUpdate = DateTime.Now,		
	                    CreatedAt = DateTime.Now		
	                })		
	            );
            }

            return user;
        }

        public bool UserValidateUpdateBasic(UserDto user)
        {
            Regex rg = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");

            if(!rg.IsMatch(user.Email))
                throw new ArgumentException("Email inválido");

            if(_repository.HasUsersByEmail(user, user.Id).Result)
                throw new ArgumentException("Email já cadastro");

            return true;
        }

        public UserDto UserValidateUpdate(UserDto user)
        {
            Regex rg = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");

            if(!rg.IsMatch(user.Email))
                throw new ArgumentException("Email inválido");

            var password = _serviceLogin.GeneratePassward();

            user.Password = _serviceLogin.EncryptPassword(password);
            user.Novi = user.CompanyId == 1;
            user.LastUpdate = DateTime.Now;
            user.Status = true;
            user.ChangedPassword = false;
            user.EmailDto = new EmailDto()
            {
                Name = user.Name,
                Email = user.Email,
                Password = password
            };

            return user;
        }
    }
}