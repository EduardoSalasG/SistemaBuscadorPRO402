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
    public class RolesControllerTest
    {
        [TestMethod]
        public async Task NuevoRol_modelo_invalido()
        {
            //Preparación
            var rolService = new Mock<IRolRepositorio>();
            var model = new RolCreacionModel();
            var controller = new RolesController(rolService.Object);
            //Ejecución
            controller.ModelState.AddModelError(string.Empty, "Datos inválidos");
            var resultado = await controller.NuevoRol(model) as ViewResult;

            //Validación

            Assert.AreEqual(resultado.ViewName, "NuevoRol");
        }

        [TestMethod]
        public async Task NuevoRol_modelo_valido()
        {
            //Preparación
            var rolService = new Mock<IRolRepositorio>();
            var model = new RolCreacionModel();
            var controller = new RolesController(rolService.Object);
            //Ejecución
            var resultado = await controller.NuevoRol(model) as RedirectToActionResult;

            //Validación

            Assert.AreEqual(resultado.ControllerName, "Roles");
            Assert.AreEqual(resultado.ActionName, "Index");
        }






    }
}
