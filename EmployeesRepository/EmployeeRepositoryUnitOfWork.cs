using EmployeesRepository.Contacts;
using EmployeesRepository.Core;
using EmployeesRepository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesRepository
{
    public class EmployeeRepositoryUnitOfWork : UnitOfWork, IEmployeeRepositoryUnitOfWork
    {
        private readonly ApplicationDbContext _dbcontext;
        public EmployeeRepositoryUnitOfWork(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbcontext = applicationDbContext;
        }

        public IEmployeeRepository EmployeeRepository
        {
            get {
                return new EmployeeRepository(_dbcontext);
           
                }

        }
    }
}
