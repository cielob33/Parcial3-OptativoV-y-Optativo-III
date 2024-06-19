using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parcial3.repositorios
{
    public class RepositorioFactura
    {
        private IDbConnection connection;

        public RepositorioFactura(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }

        public void AgregarFactura(Factura factura)
        {
            try
            {
                string sql = "INSERT INTO Factura (Idcliente, Nrofact, Fechahora, Total, " +
                             "Total5, Total10, Totaliva, Totalletras, Sucursal) " +
                             "VALUES (@Idcliente, @Nrofact, @Fechahora, @Total, @Total5, " +
                             "@Total10, @Totaliva, @Totalletras, @Sucursal)";
                connection.Execute(sql, factura);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarFactura(Factura factura)
        {
            try
            {
                string sql = "UPDATE Factura SET Idcliente = @Idcliente, Nrofact = @Nrofact, " +
                             "Fechahora = @Fechahora, Total = @Total, Total5 = @Total5, " +
                             "Total10 = @Total10, Totaliva = @Totaliva, Totalletras = @Totalletras, " +
                             "Sucursal = @Sucursal WHERE id = @Id";
                connection.Execute(sql, factura);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarFactura(int id)
        {
            try
            {
                string sql = "DELETE FROM Factura WHERE id = @Id";
                connection.Execute(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Factura ObtenerFactura(int id)
        {
            try
            {
                string sql = "SELECT * FROM Factura WHERE id = @Id";
                return connection.QueryFirstOrDefault<Factura>(sql, new { Id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Factura> ObtenerTodasFacturas()
        {
            try
            {
                string sql = "SELECT * FROM Factura";
                return connection.Query<Factura>(sql).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}