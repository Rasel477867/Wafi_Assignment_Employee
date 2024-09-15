using EmployeesCore.EntityModel;
using EmployeesRepository.Contacts;
using EmployeesRepository.Core;
using EmployeesRepository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesRepository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _context = db;
        }

        public IQueryable<Employee> GetEmployeesAsync()
        {
            var query = _context.Employees.AsQueryable();
            return query;

        }


    }
}
