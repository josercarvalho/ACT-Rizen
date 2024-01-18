﻿using JC_Raizen.Domain.Entidades;
using JC_Raizen.Infra.Context;
using JC_Raizen.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JC_Raizen.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly Contexto _context;
        public BaseRepository(Contexto context) 
        {
            _context = context;
        }

        public virtual async Task<T> Create(T obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return obj;

        }
        public virtual async Task Remove(int id)
        {
            var obj = await Get(id);

            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<T> Get(int id)
        {
            var obj = await _context.Set<T>()
                                    .AsNoTracking()
                                    .Where(x => x.Id == id)
                                    .ToListAsync();

            return obj.FirstOrDefault();
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>()
                                .AsNoTracking()
                                .ToListAsync();

        }
    }
}
