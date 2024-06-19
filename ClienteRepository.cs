using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parcial3.repositorios
{
    public class ClienteRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ClienteRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Métodos para CRUD y listado de clientes
    }
}