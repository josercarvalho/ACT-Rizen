using JC_Raizen.Domain.Entidades;
using JC_Raizen.Infra.Context;
using JC_Raizen.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JC_Raizen.Infra.Interfaces
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly Contexto _context;

        public ClienteRepository(Contexto context) : base(context)
        {
            _context = context;
        }

        public async Task<Cliente> GetByEmail(string email)
        {
            var user = await _context.Cliente
                                    .Where
                                    (
                                        x =>
                                            x.Email.ToLower() == email.ToLower()

                                    )
                                    .AsNoTracking()
                                    .ToListAsync();
            return user.FirstOrDefault();
        }

        public async Task<List<Cliente>> SearchByEmail(string email)
        {
            var allCliente = await _context.Cliente
                                    .Where
                                    (
                                        x =>
                                            x.Email.ToLower().Contains(email.ToLower())

                                    )
                                    .AsNoTracking()
                                    .ToListAsync();
            return allCliente;
        }

        public async Task<List<Cliente>> SearchByName(string nome)
        {
            var allCliente = await _context.Cliente
                                    .Where
                                    (
                                        x =>
                                            x.Nome.ToLower().Contains(nome.ToLower())

                                    )
                                    .AsNoTracking()
                                    .ToListAsync();
            return allCliente;
        }
    }
}
