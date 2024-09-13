using EmployeesCore.EntityModel;
using EmployeesRepository.Contacts;
using EmployeesService.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepositoryUnitOfWork _unitofwork;
        public EmployeeService(IEmployeeRepositoryUnitOfWork employeeRepositoryUnitOfWork)
        {
            _unitofwork = employeeRepositoryUnitOfWork;
        }
        public async Task<bool> AddAsync(Employee Entity)
        {
           await _unitofwork.EmployeeRepository.Add(Entity);
            return await _unitofwork.CompleteAsync();

        }

        public async Task<bool> DeleteAsync(Employee Entity)
        {
            await _unitofwork.EmployeeRepository.Delete(Entity);
            return await _unitofwork.CompleteAsync();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
           return await _unitofwork.EmployeeRepository.GetAll();
        }

        public async Task<Employee> GetByIdAsync(Guid id)
        {
            return await _unitofwork.EmployeeRepository.GetById(id);
        }

        public async Task<bool> UpdateAsync(Employee Entity)
        {
            await _unitofwork.EmployeeRepository.Update(Entity);
            return await _unitofwork.CompleteAsync();
        }
    }
}
