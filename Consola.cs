using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
namespace parcial3
{
    internal class Consola
    { 
            static void Main(string[] args)
            {
                string connectionString = "Host=localhost;port=5432;Database=postgres;Username=postgres;Password=root;";

                ServCliente clienteServices = new ServCliente(connectionString);
                ServFactura facturaServices = new ServFactura(connectionString);

                Console.WriteLine("Ingrese: \n 1 - Para insertar un nuevo cliente \n 2 - Para listar clientes \n 3 - Para actualizar un cliente \n 4 - Para eliminar un cliente \n 5 - Para insertar una nueva factura \n 6 - Para listar facturas \n 7 - Para actualizar una factura \n 8 - Para eliminar una factura");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        InsertarCliente(clienteServices);
                        break;
                    case "2":
                        ListarClientes(clienteServices);
                        break;
                    case "3":
                        ActualizarCliente(clienteServices);
                        break;
                    case "4":
                        EliminarCliente(clienteServices);
                        break;
                    case "5":
                        InsertarFactura(facturaServices);
                        break;
                    case "6":
                        ListarFacturas(facturaServices);
                        break;
                    case "7":
                        ActualizarFactura(facturaServices);
                        break;
                    case "8":
                        EliminarFactura(facturaServices);
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }

            static void InsertarCliente(ServCliente ServCliente)
            {
                Console.WriteLine("Ingrese el nombre del cliente:");
                string nombre = Console.ReadLine();

                Console.WriteLine("Ingrese el apellido del cliente:");
                string apellido = Console.ReadLine();

                Console.WriteLine("Ingrese el documento del cliente:");
                string documento = Console.ReadLine();

                Console.WriteLine("Ingrese el correo electrónico del cliente:");
                string mail = Console.ReadLine();

                Console.WriteLine("Ingrese su dirección:");
                string direccion = Console.ReadLine();

                Console.WriteLine("Ingrese el número de celular del cliente:");
                string celular = Console.ReadLine();

                Console.WriteLine("Ingrese el estado del cliente:");
                string estado = Console.ReadLine();

                ServCliente.Insertar(new Cliente
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Documento = documento,
                    Direccion = direccion,
                    Mail = mail,
                    Celular = celular,
                    Estado = estado
                });

                Console.WriteLine("Cliente insertado exitosamente.");
            }

            static void ListarClientes(ServCliente ServCliente)
            {
                Console.WriteLine("Lista de clientes:");
                var clientes = ServCliente.Listado();
                clientes.ForEach(cliente =>
                    Console.WriteLine(
                        $"ID: {cliente.Id} \n" +
                        $"Nombre: {cliente.Nombre} \n" +
                        $"Apellido: {cliente.Apellido} \n" +
                        $"Documento: {cliente.Documento} \n" +
                        $"Mail: {cliente.Mail} \n" +
                        $"Direccion: {cliente.Direccion} \n" +
                        $"Celular: {cliente.Celular} \n" +
                        $"Estado: {cliente.Estado} \n"
                    )
                );
            }

            static void ActualizarCliente(ServCliente ServCliente)
            {
                Console.WriteLine("Ingrese el ID del cliente que desea actualizar:");
                if (!int.TryParse(Console.ReadLine(), out int idCliente))
                {
                    Console.WriteLine("Formato de ID inválido. Intente nuevamente.");
                    return;
                }

                Console.WriteLine("Ingrese el nombre del cliente:");
                string nombre = Console.ReadLine();

                Console.WriteLine("Ingrese el apellido del cliente:");
                string apellido = Console.ReadLine();

                Console.WriteLine("Ingrese el documento del cliente:");
                string documento = Console.ReadLine();

                Console.WriteLine("Ingrese el correo electrónico del cliente:");
                string mail = Console.ReadLine();

                Console.WriteLine("Ingrese su dirección:");
                string direccion = Console.ReadLine();

                Console.WriteLine("Ingrese el número de celular del cliente:");
                string celular = Console.ReadLine();

                Console.WriteLine("Ingrese el estado del cliente:");
                string estado = Console.ReadLine();

                var cliente = new Cliente
                {
                    Id = idCliente,
                    Nombre = nombre,
                    Apellido = apellido,
                    Documento = documento,
                    Direccion = direccion,
                    Mail = mail,
                    Celular = celular,
                    Estado = estado
                };

                ServCliente.Actualizar(cliente);
                Console.WriteLine("Cliente actualizado exitosamente.");
            }

            static void EliminarCliente(ServCliente ServCliente)
            {
                Console.WriteLine("Ingrese el ID del cliente que desea eliminar:");
                if (!int.TryParse(Console.ReadLine(), out int idCliente))
                {
                    Console.WriteLine("Formato de ID inválido. Intente nuevamente.");
                    return;
                }

                ServCliente.Eliminar(idCliente);
                Console.WriteLine("Cliente eliminado exitosamente.");
            }

            static void InsertarFactura(ServFactura ServFactura)
            {
                Console.WriteLine("Ingrese el número de factura:");
                string numero = Console.ReadLine();

                Console.WriteLine("Ingrese el total de la factura:");
                if (!decimal.TryParse(Console.ReadLine(), out decimal total))
                {
                    Console.WriteLine("Formato de total inválido. Intente nuevamente.");
                    return;
                }

                Console.WriteLine("Ingrese el total IVA 5%:");
                if (!decimal.TryParse(Console.ReadLine(), out decimal totalIva5))
                {
                    Console.WriteLine("Formato de total IVA 5% inválido. Intente nuevamente.");
                    return;
                }

                Console.WriteLine("Ingrese el total IVA 10%:");
                if (!decimal.TryParse(Console.ReadLine(), out decimal totalIva10))
                {
                    Console.WriteLine("Formato de total IVA 10% inválido. Intente nuevamente.");
                    return;
                }

                Console.WriteLine("Ingrese el total IVA:");
                if (!decimal.TryParse(Console.ReadLine(), out decimal totalIva))
                {
                    Console.WriteLine("Formato de total IVA inválido. Intente nuevamente.");
                    return;
                }

                Console.WriteLine("Ingrese el total en letras:");
                string totalEnLetras = Console.ReadLine();

                ServFactura.Insertar(new Factura
                {
                    Nro_Factura = numero,
                    Total = total,
                    Total_iva5 = totalIva5,
                    Total_iva10 = totalIva10,
                    Total_iva = totalIva,
                    TotalLetras = totalEnLetras
                });

                Console.WriteLine("Factura insertada exitosamente.");
            }

            static void ListarFacturas(ServFactura ServFactura)
            {
                Console.WriteLine("Lista de facturas:");
                var facturas = ServFactura.Listado();
                facturas.ForEach(factura =>
                    Console.WriteLine(
                        $"ID: {factura.Id} \n" +
                        $"Numero: {factura.Nro_Factura} \n" +
                        $"Total: {factura.Total} \n" +
                        $"Total IVA 5%: {factura.Total_iva5} \n" +
                        $"Total IVA 10%: {factura.Total_iva10} \n" +
                        $"Total IVA: {factura.Total_iva} \n" +
                        $"Total en letras: {factura.TotalLetras} \n"
                    )
                );
            }

            static void ActualizarFactura(ServFactura ServFactura)
            {
                Console.WriteLine("Ingrese el ID de la factura que desea actualizar:");
                if (!int.TryParse(Console.ReadLine(), out int idFactura))
                {
                    Console.WriteLine("Formato de ID inválido. Intente nuevamente.");
                    return;
                }

                Console.WriteLine("Ingrese el número de factura:");
                string numero = Console.ReadLine();

                Console.WriteLine("Ingrese el total de la factura:");
                if (!decimal.TryParse(Console.ReadLine(), out decimal total))
                {
                    Console.WriteLine("Formato de total inválido. Intente nuevamente.");
                    return;
                }

                Console.WriteLine("Ingrese el total IVA 5%:");
                if (!decimal.TryParse(Console.ReadLine(), out decimal totalIva5))
                {
                    Console.WriteLine("Formato de total IVA 5% inválido. Intente nuevamente.");
                    return;
                }

                Console.WriteLine("Ingrese el total IVA 10%:");
                if (!decimal.TryParse(Console.ReadLine(), out decimal totalIva10))
                {
                    Console.WriteLine("Formato de total IVA 10% inválido. Intente nuevamente.");
                    return;
                }

                Console.WriteLine("Ingrese el total IVA:");
                if (!decimal.TryParse(Console.ReadLine(), out decimal totalIva))
                {
                    Console.WriteLine("Formato de total IVA inválido. Intente nuevamente.");
                    return;
                }

                Console.WriteLine("Ingrese el total en letras:");
                string totalEnLetras = Console.ReadLine();

                var factura = new Factura
                {
                    Id = idFactura,
                    Nro_Factura = numero,
                    Total = total,
                    Total_iva5 = totalIva5,
                    Total_iva10 = totalIva10,
                    Total_iva = totalIva,
                    TotalLetras = totalEnLetras
                };

                ServFactura.Actualizar(factura);
                Console.WriteLine("Factura actualizada exitosamente.");
            }

            static void EliminarFactura(ServFactura ServFactura)
            {
                Console.WriteLine("Ingrese el ID de la factura que desea eliminar:");
                if (!int.TryParse(Console.ReadLine(), out int idFactura))
                {
                    Console.WriteLine("Formato de ID inválido. Intente nuevamente.");
                    return;
                }

                ServFactura.Eliminar(idFactura);
                Console.WriteLine("Factura eliminada exitosamente.");
            }
        }
    }



