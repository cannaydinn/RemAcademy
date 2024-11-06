using Microsoft.AspNetCore.DataProtection;
using RemAcademy.Business.DataProtection;
using RemAcademy.Business.Operations.User.Dtos;
using RemAcademy.Business.Types;
using RemAcademy.Data.Entities;
using RemAcademy.Data.Repositories;
using RemAcademy.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemAcademy.Business.Operations.User
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IDataProtection _dataProtection;

        public UserManager(IUnitOfWork unitOfWork, IRepository<UserEntity> userRepository, IDataProtection dataProtection)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _dataProtection = dataProtection;
        }

        public async Task<ServiceMessage> AddUser(AddUserDto user)
        {
            var hasMail = _userRepository.GetAll(x => x.Email.ToLower() == user.Email.ToLower());

            if (hasMail.Any()) 
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Email adresi zaten mevcut!!"
                };
            }

            var userEntity = new UserEntity
            {
                FullName = user.FullName,
                Email = user.Email,
                Password = _dataProtection.Protect(user.Password),
                City = user.City,
                SchoolName = user.SchoolName,
                UserType = Data.Enums.UserType.Teacher,
            };

            _userRepository.Add(userEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception) 
            {
                throw new Exception("Kullanıcı kaydı sırasında bir hata oluştu!!");
            }

            return new ServiceMessage
            {
                IsSucceed = true,
            };
        }

        public ServiceMessage<UserInfoDto> LoginUser(LoginUserDto user)
        {

            var userEntity = _userRepository.Get(x => x.Email.ToLower() == user.Email.ToLower());
            if(userEntity is null)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = "email veya şifre hatalı!!!"
                };
            }
            
            var unProtectedText = _dataProtection.UnProtected(userEntity.Password);
            if (unProtectedText == user.Password) 
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = true,
                    Data = new UserInfoDto
                    {
                        FullName = userEntity.FullName,
                        Email = userEntity.Email,
                        UserType = userEntity.UserType,
                    }
                };
            }
            else
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = "email veya şifre hatalı!!!"
                };
            }
        }
    }
}
