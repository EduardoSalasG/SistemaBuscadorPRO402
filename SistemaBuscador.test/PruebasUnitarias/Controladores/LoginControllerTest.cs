using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemaBuscador.Controllers;
using SistemaBuscador.Models;
using SistemaBuscador.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBuscador.test.PruebasUnitarias.Controladores
{
    [TestClass]
    public class LoginControllerTest
    {
        [TestMethod]
        public async Task LoginModeloInvalido()
        {
            //Preparación

            var loginRepository = new LoginRepositoryEFFalse();
            var model = new LoginViewModel() { Usuario = "", Password = "" };

            //Ejecución

            var controller = new LoginController(loginRepository);
            controller.ModelState.AddModelError(string.Empty, "Datos invalidos");
            var resultado = await controller.Login(model) as ViewResult;

            //Validación

            Assert.AreEqual(resultado.ViewName, "Index");

        }

        [TestMethod]
        public async Task LoginUsuarioNoExiste()
        {
            //Preparación

            //  var loginservice = new LoginRepositoryEFFalse();

            var loginservice = new Mock<ILoginRepository>();
            loginservice.Setup(x => x.UserExist(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(false));

            var model = new LoginViewModel() { Usuario="Usuario1",Password="Password1"};

            //Ejecucion

            var controller = new LoginController(loginservice.Object);
            var resultado = await controller.Login(model) as ViewResult;

            //Validación

            Assert.AreEqual(resultado.ViewName, "Index");

        }

        [TestMethod]
        public async Task LoginUsuarioExiste()
        {
            //Preparacion

            // var loginservice = new LoginRepositoryEFTrue();

            var loginservice = new Mock<ILoginRepository>();
            loginservice.Setup(x => 
            x.UserExist(
                It.IsAny<string>(), 
                It.IsAny<string>()))
                .Returns(Task.FromResult(true));
            var model = new LoginViewModel() { Usuario = "Usuario1", Password = "Password1" };

            //Ejecución

            var controller = new LoginController(loginservice.Object);
            var resultado = await controller.Login(model) as RedirectToActionResult;

            //Validación

            Assert.AreEqual(resultado.ActionName, "Index");
            Assert.AreEqual(resultado.ControllerName, "Home");
        }

    }
}
