using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemaBuscador.Repositories;
using SistemaBuscador.Utilidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBuscador.test.PruebasUnitarias.Servicios
{
    [TestClass]

    public class LoginRepositoryEFTest : TestBase
    {
        [TestMethod]
        public async Task UsuarioNoExiste()
        {
            //Preparacion
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuidContext(nombreBd);
            context.Usuarios.Add(new Entities.Usuario() { NombreUsuario = "Usuario1", Password = "Password1" });
            await context.SaveChangesAsync();
            var context2 = BuidContext(nombreBd);
            var seguridad = new Mock<ISeguridad>();
            seguridad.Setup(x=>x.Encriptar(It.IsAny<string>())).Returns("aabbccddeeffhhii");


            //Ejecucion

            var nombreUsuario = "Usuario2";
            var password = "password2";
            var repo = new LoginRepositoryEF(context2,seguridad.Object);
            var respuesta = await repo.UserExist(nombreUsuario, password);

            //Verificacion

            Assert.IsFalse(respuesta);

        }

        [TestMethod]
        public async Task UsuarioExiste()
        {
            //Preparacion
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuidContext(nombreBd);
            context.Usuarios.Add(new Entities.Usuario() { NombreUsuario = "Usuario1", Password = "aabbccddeeffhhii" });
            await context.SaveChangesAsync();
            var seguridad = new Mock<ISeguridad>();
            seguridad.Setup(x => x.Encriptar(It.IsAny<string>())).Returns("aabbccddeeffhhii");
            var context2 = BuidContext(nombreBd);

            //Ejecucion

            var nombreUsuario = "Usuario1";
            var password = "Password1";
            var repo = new LoginRepositoryEF(context2,seguridad.Object);
            var respuesta = await repo.UserExist(nombreUsuario, password);

            //Verificacion

            Assert.IsTrue(respuesta);
        }

    }
}
