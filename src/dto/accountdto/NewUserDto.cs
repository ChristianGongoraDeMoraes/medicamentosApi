using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medicamentosApi.src.dto.accountdto
{
    public class NewUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}