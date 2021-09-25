using Microsoft.AspNetCore.Http;
using SistemaBuscador.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBuscador.test
{
    public class LoginRepositoryEFTrue : ILoginRepository
    {
        public void SetSessionAndCookie(HttpContext contex)
        {
           
        }

        public async Task<bool> UserExist(string usuario, string password)
        {
            return await Task.FromResult(true);
        }
    }
}
