using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesRepository.Core
{
    public interface IUnitOfWork
    {
        Task<bool> CompleteAsync();
    }
}
