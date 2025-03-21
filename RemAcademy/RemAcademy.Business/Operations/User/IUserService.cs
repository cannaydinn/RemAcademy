﻿using RemAcademy.Business.Operations.User.Dtos;
using RemAcademy.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemAcademy.Business.Operations.User
{
    public interface IUserService
    {
        Task<ServiceMessage> AddUser(AddUserDto user);

        ServiceMessage<UserInfoDto> LoginUser(LoginUserDto user);
    }
}
