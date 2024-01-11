using App.Core.Common;
using App.DAL.Context;
using App.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseAuditable, new()
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();
        public bool Check(int id)
        {
            if (Table.Any(x => x.Id == id && x.IsDeleted == false)) return true;
            return false;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            if (Table.Any(x => x.Id == id && x.IsDeleted == false))
            {
                var entity = Table.FirstOrDefault(x => x.Id == id);
                if (entity != null)
                    entity.IsDeleted = true;
               var AffectedRows= await Save();
                if (AffectedRows > 0) return true;
                
            }
            return false;
        }
        public async Task<bool> deleteAll()
        {
            if (Table != null)
                foreach (var item in Table)
                {
                    item.IsDeleted = true;
                }
           var AffectedRows =  await Save();
            if(AffectedRows > 0) return true;   
            return false;
        }
        public async Task<IQueryable<T>> GetAllAsync()
        {
            IQueryable<T> query = Table.Where(b => !b.IsDeleted);          
            return query;
        }
        public async Task<T> GetById(int id)
        {
            if (Check(id))
            {
                return await Table.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
            }
            return null;
        }
        public async Task<int> Save()
        {
            var AfeectedRows = await _context.SaveChangesAsync();
            return AfeectedRows;
        }
        public async Task <T> Update(T entity)
        {
            Table.Update(entity);
            await Save();
            return entity;
        }
        public async Task<bool> Create(T entity)
        {
            await Table.AddAsync (entity);
            var AffectedRows = await Save();
            if (AffectedRows > 0) return true;
            return false;
        }
    }
}
