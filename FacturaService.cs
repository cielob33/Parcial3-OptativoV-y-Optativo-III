using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parcial3
{
    public class FacturaService
    {
        public bool ValidateFactura(Factura factura, out List<string> validationErrors)
        {
            validationErrors = new List<string>();

            // Validación del Nro. Factura
            if (!ValidateNroFactura(factura.Nro_Factura))
            {
              validationErrors.Add("El número de factura debe seguir el patrón 999-999-999999.");
            }

            // Validación de campos numéricos obligatorios
            if (factura.Total <= 0)
            {
                validationErrors.Add("El total debe ser un valor numérico positivo.");
            }
            if (factura.Total_iva5 < 0)
            {
                validationErrors.Add("El total de IVA 5% debe ser un valor numérico positivo o cero.");
            }
            if (factura.Total_iva10 < 0)
            {
                validationErrors.Add("El total de IVA 10% debe ser un valor numérico positivo o cero.");
            }
            if (factura.Total_iva < 0)
            {
                validationErrors.Add("El total de IVA debe ser un valor numérico positivo o cero.");
            }

            // Validación del total en letras
            if (string.IsNullOrWhiteSpace(factura.TotalLetras) || factura.TotalLetras.Length < 6)
            {
                validationErrors.Add("El total en letras es obligatorio y debe tener al menos 6 caracteres.");
            }

            return validationErrors.Count == 0;
        }

        private bool ValidateNroFactura(string nroFactura)
        {
            // El patrón es 999-999-999999
            string pattern = @"^[0-9]{3}-[0-9]{3}-[0-9]{6}$";
            return System.Text.RegularExpressions.Regex.IsMatch(nroFactura, pattern);
        }
    }
}