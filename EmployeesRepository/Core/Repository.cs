﻿using EmployeesCore.EntityModel.Core;
using EmployeesRepository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmployeesRepository.Core.IRepository;

namespace EmployeesRepository.Core
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly ApplicationDbContext _db;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }
        public DbSet<T> table
        {
            get
            {
                return _db.Set<T>();
            }
        }
        public virtual async Task Add(T Entity)
        {

            await table.AddAsync(Entity);
           
        }

        public virtual async Task Delete(T Entity)
        {
            await Task.Run(() =>
            {
                table.Remove(Entity);
             
              
            });
      

        }

        public virtual async Task<List<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            var query=  table.Where(x=> x.Id == id).AsQueryable();

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public virtual async Task Update(T Entity)
        {
            await Task.Run(() =>
            {

                table.Update(Entity);

            });
           
        }
    }
}
