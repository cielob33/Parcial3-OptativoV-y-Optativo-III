using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace WebApiProject
{
    public class Crud
    {

[ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetAllClientes()
        {
            return Ok(_clienteService.GetAllClientes());
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> GetClienteById(int id)
        {
            var cliente = _clienteService.GetClienteById(id);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public ActionResult<Cliente> CreateCliente(Cliente cliente)
        {
            _clienteService.CreateCliente(cliente);
            return CreatedAtAction(nameof(GetClienteById), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
                return BadRequest();

            _clienteService.UpdateCliente(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            var cliente = _clienteService.GetClienteById(id);
            if (cliente == null)
                return NotFound();

            _clienteService.DeleteCliente(cliente);
            return NoContent();
        }
    }
