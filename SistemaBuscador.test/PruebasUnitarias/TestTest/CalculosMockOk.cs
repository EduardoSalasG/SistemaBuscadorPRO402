﻿using SistemaBuscador.Testing;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBuscador.test.PruebasUnitarias.TestTest
{
    public class CalculosMockOk : ICalculos
    {
        public int CalcularEdad(DateTime fechaNacimiento)
        {
            return 20;
        }
    }
}
