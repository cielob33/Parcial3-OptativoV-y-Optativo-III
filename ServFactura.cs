using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Npgsql;
using System.Text.RegularExpressions;
namespace parcial3
{
    public class ServFactura
    {
        public bool ValidateFactura(Factura factura)
        {
            if (!Regex.IsMatch(factura.Nro_Factura, @"^\d{3}-\d{3}-\d{6}$"))
                return false;
            if (factura.Total <= 0 || factura.Total_iva5 < 0 || factura.Total_iva10 < 0)
                return false;
            if (string.IsNullOrEmpty(factura.TotalLetras) || factura.TotalLetras.Length < 6)
                return false;
            return true;
        }
    }
}

