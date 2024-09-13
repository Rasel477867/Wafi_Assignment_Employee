using EmployeesRepository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesRepository.Contacts
{
    public interface IEmployeeRepositoryUnitOfWork:IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }
    }
}
