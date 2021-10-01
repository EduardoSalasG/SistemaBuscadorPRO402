using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaBuscador.Entities;
using SistemaBuscador.Models;
using SistemaBuscador.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBuscador.test.PruebasUnitarias.Servicios
{
    [TestClass]
    public class RolRepositorioTest : TestBase
    {
        [TestMethod]
        public async Task InsertarRol()
        {
            //Preparación
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuidContext(nombreBd);
            var repo = new RolRepositorio(context);
            var modelo = new RolCreacionModel() { Nombre = "Rol Test" };

            //Ejecución
            await repo.InsertarRol(modelo);
            var context2 = BuidContext(nombreBd);
            var list = await context2.Roles.ToListAsync();
            var resultado = list.Count();

            //Verificación
            Assert.AreEqual(1,resultado);

        }

        [TestMethod]
        public async Task ObtenerRolPorId()
        {
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuidContext(nombreBd);
            var rol = new Rol() { Nombre = "Rol 1" };
            context.Roles.Add(rol);
            await context.SaveChangesAsync();
            var context2 = BuidContext(nombreBd);
            var repo = new RolRepositorio(context2);


            //Ejecucion
            var rolDeLaBd = await repo.ObtenerRolPorId(1);
            //Verificación
            Assert.IsNotNull(rolDeLaBd);
        }


        [TestMethod]
        public async Task ActualizarRol()
        {
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuidContext(nombreBd);
            var rol = new Rol() { Nombre = "Rol 1" };
            context.Roles.Add(rol);
            await context.SaveChangesAsync();

            var context2 = BuidContext(nombreBd);
            var repo = new RolRepositorio(context2);

            var model = new RolEdicionModel() { Id = 1, Nombre = "Rol 1 Modificado" };


            //Ejecucion
            await repo.ActualizarRol(model);

            var context3 = BuidContext(nombreBd);
            var rolModificado = await context3.Roles.FirstOrDefaultAsync(x=>x.Id==1);
            var resultado = rolModificado.Nombre;

            //Verificación
            Assert.AreEqual("Rol 1 Modificado",resultado);
        }

        [TestMethod]
        public async Task EliminarRol()
        {
            var nombreBd = Guid.NewGuid().ToString();
            var context = BuidContext(nombreBd);
            var rol = new Rol() { Nombre = "Rol 1" };
            context.Roles.Add(rol);
            await context.SaveChangesAsync();

            var context2 = BuidContext(nombreBd);
            var repo = new RolRepositorio(context2);

            //Ejecucion
            await repo.EliminarRol(1);

            var context3 = BuidContext(nombreBd);
            var listaRoles = await context3.Roles.ToListAsync();
            var resultado = listaRoles.Count;

            //Verificación
            Assert.AreEqual(0,resultado);
        }



    }
}
