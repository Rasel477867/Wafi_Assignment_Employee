using EmployeesCore.EntityModel;
using EmployeesRepository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmployeesRepository.Core.IRepository;

namespace EmployeesRepository.Contacts
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
    }
}
