﻿using EmployeesCore.EntityModel;
using EmployeesRepository.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesService.Contacts
{
    public interface IEmployeeService
    {
        Task<Employee> GetByIdAsync(Guid id);
        Task<List<Employee>> GetAllAsync();
        Task<bool> UpdateAsync(Employee Entity);
        Task<bool> DeleteAsync(Employee Entity);
        Task<bool> AddAsync(Employee Entity);
        Task<(IEnumerable<Employee> Employees, int TotalCount)> GetEmployeesAsync(EmployeeQuery searchString, int page, int pageSize);

    }
}
