﻿using EmployeesRepository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesRepository.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbcontext;
        public UnitOfWork(ApplicationDbContext applicationDbContext )
        {
            _dbcontext = applicationDbContext;
        }
        public async Task<bool> CompleteAsync()
        {
            return await _dbcontext.SaveChangesAsync() > 0;
        }
    }
}
