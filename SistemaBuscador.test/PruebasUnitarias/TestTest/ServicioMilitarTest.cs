using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaBuscador.Testing;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBuscador.test.PruebasUnitarias.TestTest
{
    [TestClass]
    public class ServicioMilitarTest
    {
        [TestMethod]
        public void NoEsValidoPorSexo()
        {
            //Preparación
            string sexo = "F";
            DateTime fechaNac = new DateTime(2000, 12, 1);
            var clase = new ServicioMilitar(new CalculosMockOk());

            //Ejecución

            bool resultado = clase.EsApto(fechaNac, sexo);

            //Verificación

            Assert.IsFalse(resultado);
        }
        [TestMethod]
        public void NoEsValidoPorEdad()
        {
            //Preparación
            string sexo = "M";
            DateTime fechaNac = new DateTime(2000, 12, 1);
            var clase = new ServicioMilitar(new CalculosMockNok());

            //Ejecución

            bool resultado = clase.EsApto(fechaNac, sexo);

            //Verificación

            Assert.IsFalse(resultado);
        }
        [TestMethod]
        public void NoEsValidoPorEdadYSexo()
        {
            //Preparación
            string sexo = "M";
            DateTime fechaNac = new DateTime(2000, 12, 1);
            var clase = new ServicioMilitar(new CalculosMockNok());

            //Ejecución

            bool resultado = clase.EsApto(fechaNac, sexo);

            //Verificación

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void EsValido()
        {
            //Preparacion
            string sexo = "M";
            DateTime fechaNac = new DateTime(2000, 12, 1);
            var clase = new ServicioMilitar(new CalculosMockOk());

            //Ejecucion

            bool resultado = clase.EsApto(fechaNac, sexo);

            //verificacion

            Assert.IsTrue(resultado);
        }
    }
}
