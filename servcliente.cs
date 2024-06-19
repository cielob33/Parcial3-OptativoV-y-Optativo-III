using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Npgsql;

namespace parcial3
{
    public class servcliente
    {
        public bool ValidateCliente(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nombre) || cliente.Nombre.Length < 3)
                return false;
            if (string.IsNullOrEmpty(cliente.Apellido) || cliente.Apellido.Length < 3)
                return false;
            if (string.IsNullOrEmpty(cliente.Celular) || cliente.Celular.Length != 10 || !long.TryParse(cliente.Celular, out _))
                return false;
            return true;
        }
    }
}
