﻿using EC_Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
