using System;
using Npgsql;

public class ConexionBD
{
    private string connectionString;
    private NpgsqlConnection connection;

    public ConexionBD()
    {
        connectionString = "Host=192.168.0.17;Port=5432;Username=postgres;Password=12345;Database=Parcial1";
        connection = new NpgsqlConnection(connectionString);
    }

    public NpgsqlConnection ObtenerConexion()
    {
        return connection;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Crear una instancia de la clase ConexionBD
        ConexionBD conexionBD = new ConexionBD();

        // Ejemplo de cómo utilizar la conexión
        using (var conn = conexionBD.ObtenerConexion())
        {
            try
            {
                conn.Open();

                // Ejemplo de consulta a la tabla Cliente
                Console.WriteLine("Consultando tabla Cliente:");
                string consultaSqlCliente = "SELECT Id, Id_banco, Nombre, Apellido, Direccion, Documento, Mail, Celular FROM Cliente";

                using (var cmdCliente = new NpgsqlCommand(consultaSqlCliente, conn))
                {
                    using (var readerCliente = cmdCliente.ExecuteReader())
                    {
                        while (readerCliente.Read())
                        {
                            // Acceder a los datos de cada fila de Cliente
                            int idCliente = readerCliente.GetInt32(0);
                            int idBanco = readerCliente.GetInt32(1);
                            string nombreCliente = readerCliente.GetString(2);
                            string apellidoCliente = readerCliente.GetString(3);
                            string direccionCliente = readerCliente.IsDBNull(4) ? "" : readerCliente.GetString(4);
                            string documentoCliente = readerCliente.GetString(5);
                            string mailCliente = readerCliente.IsDBNull(6) ? "" : readerCliente.GetString(6);
                            string celularCliente = readerCliente.IsDBNull(7) ? "" : readerCliente.GetString(7);

                            // Ejemplo de impresión de datos de Cliente
                            Console.WriteLine($"Id: {idCliente}, Id_banco: {idBanco}, Nombre: {nombreCliente}, Apellido: {apellidoCliente}, Direccion: {direccionCliente}, Documento: {documentoCliente}, Mail: {mailCliente}, Celular: {celularCliente}");
                        }
                    }
                }

                // Ejemplo de consulta a la tabla Factura
                Console.WriteLine("\nConsultando tabla Factura:");
                string consultaSqlFactura = "SELECT Id, Id_cliente, Nro_Factura, Fecha_Hora, Total, Total_iva5, Total_iva10, Total_iva, TotalLetras, Subtotal, Letras FROM Factura";

                using (var cmdFactura = new NpgsqlCommand(consultaSqlFactura, conn))
                {
                    using (var readerFactura = cmdFactura.ExecuteReader())
                    {
                        while (readerFactura.Read())
                        {
                            // Acceder a los datos de cada fila de Factura
                            int idFactura = readerFactura.GetInt32(0);
                            int idCliente = readerFactura.GetInt32(1);
                            string nroFactura = readerFactura.GetString(2);
                            DateTime fechaHora = readerFactura.GetDateTime(3);
                            decimal total = readerFactura.GetDecimal(4);
                            decimal totalIva5 = readerFactura.GetDecimal(5);
                            decimal totalIva10 = readerFactura.GetDecimal(6);
                            decimal totalIva = readerFactura.GetDecimal(7);
                            string totalLetras = readerFactura.GetString(8);
                            decimal subtotal = readerFactura.GetDecimal(9);
                            string letras = readerFactura.GetString(10);

                            // Ejemplo de impresión de datos de Factura
                            Console.WriteLine($"Id: {idFactura}, Id_cliente: {idCliente}, Nro_Factura: {nroFactura}, Fecha_Hora: {fechaHora}, Total: {total}, Total_iva5: {totalIva5}, Total_iva10: {totalIva10}, Total_iva: {totalIva}, TotalLetras: {totalLetras}, Subtotal: {subtotal}, Letras: {letras}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
