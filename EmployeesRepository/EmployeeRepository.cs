using EmployeesCore.EntityModel;
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
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _dbcontext = db;
        }
    }
}
