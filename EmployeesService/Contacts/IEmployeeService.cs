using EmployeesCore.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesService.Contacts
{
    public interface IEmployeeService
    {
        Task<Employee> GetById(Guid id);
        Task<List<Employee>> GetAll();
        Task<bool> Update(Employee Entity);
        Task<bool> Delete(Employee Entity);
        Task<bool> Add(Employee Entity);

    }
}
