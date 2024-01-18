using AutoMapper;
using JC_Raizen.Domain.Entidades;
using JC_Raizen.Infra.Interfaces;
using JC_Raizen.Infra.Models;
using JC_Raizen.Services.DTO;
using JC_Raizen.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JC_Raizen.Services.Services
{
    public class ClienteService : IClienteService
    {

        private readonly IGenericRepository _generic;
        private readonly IClienteRepository _cliente;
        private readonly IMapper _mapper;

        public ClienteService(IGenericRepository generic, IClienteRepository cliente, IMapper mapper)
        {
            _generic = generic;
            _cliente = cliente;
            _mapper = mapper;
        }

        public async Task<ClienteDTO> AddClientes(ClienteDTO model)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(model);

                _generic.Add<Cliente>(cliente);

                if (await _generic.SaveChangesAsync())
                {
                    var clienteRetorno = await _cliente.GetByIdAsync(cliente.Id);

                    return _mapper.Map<ClienteDTO>(clienteRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ClienteDTO> UpdateCliente(int Id, ClienteDTO model)
        {
            try
            {
                var cliente = await _cliente.GetByIdAsync(Id);
                if (cliente == null) return null;

                _mapper.Map(model, cliente);

                _generic.Update<Cliente>(cliente);

                if (await _generic.SaveChangesAsync())
                {
                    var ClienteRetorno = await _cliente.GetByIdAsync(Id);

                    return _mapper.Map<ClienteDTO>(ClienteRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteCliente(int Id)
        {
            try
            {
                var cliente = await _cliente.GetByIdAsync(Id);
                if (cliente == null) throw new Exception("cliente para delete não encontrado.");

                _generic.Delete<Cliente>(cliente);
                return await _generic.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PageList<ClienteDTO>> GetAllClientesAsync(PageParams pageParams)
        {
            try
            {
                var cliente = await _cliente.GetAllAsync(pageParams);
                if (cliente == null) return null;

                var resultado = _mapper.Map<PageList<ClienteDTO>>(cliente);

                resultado.CurrentPage = cliente.CurrentPage;
                resultado.TotalPages = cliente.TotalPages;
                resultado.PageSize = cliente.PageSize;
                resultado.TotalCount = cliente.TotalCount;

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteDTO> GetClienteByIdAsync(int Id)
        {
            try
            {
                var cliente = await _cliente.GetByIdAsync(Id);
                if (cliente == null) return null;

                var resultado = _mapper.Map<ClienteDTO>(cliente);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
