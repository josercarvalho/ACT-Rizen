using JC_Raizen.API.Extensions;
using JC_Raizen.Infra.Models;
using JC_Raizen.Services.DTO;
using JC_Raizen.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;

namespace JC_Raizen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {        
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageParams pageParams)
        {
            try
            {
                var cliente = await _clienteService.GetAllClientesAsync(pageParams);
                if (cliente == null) return NoContent();

                Response.AddPagination(cliente.CurrentPage, cliente.PageSize, cliente.TotalCount, cliente.TotalPages);

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar cliente. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var cliente = await _clienteService.GetClienteByIdAsync(id);
                if (cliente == null) return NoContent();

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar cliente. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteDTO model)
        {
            try
            {
                var cliente = await _clienteService.AddClientes(model);
                if (cliente == null) return NoContent();

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar cliente. Erro: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(ClienteDTO model)
        {
            try
            {
                var id = model.Id;
                model.DataNascimento = Convert.ToDateTime(model.DataNascimento, CultureInfo.InvariantCulture);
                var cliente = await _clienteService.UpdateCliente(id, model);
                if (cliente == null) return NoContent();

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar cliente. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var cliente = await _clienteService.GetClienteByIdAsync(id);
                if (cliente == null) return NoContent();

                if (await _clienteService.DeleteCliente(id))
                {
                    return Ok(new { message = "Deletado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problem não específico ao tentar deletar cliente.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar cliente. Erro: {ex.Message}");
            }
        }
    }
}
