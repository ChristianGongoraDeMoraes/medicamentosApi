using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medicamentosApi.src.model;

namespace medicamentosApi.src.interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
} 