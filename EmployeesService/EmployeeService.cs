using EmployeesCore.EntityModel;
using EmployeesRepository;
using EmployeesRepository.Contacts;
using EmployeesService.Contacts;
using Microsoft.EntityFrameworkCore;
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
    

        public async Task<(IEnumerable<Employee> Employees, int TotalCount)> GetEmployeesAsync(EmployeeQuery searchString, int page, int pageSize)
        {
            int skip = (page - 1) * pageSize;


            var query = _unitofwork.EmployeeRepository.GetEmployeesAsync();
            if (!string.IsNullOrEmpty(searchString.SName))
            {
                query = query.Where(x => x.FirstName.Contains(searchString.SName)
                || x.LastName.Contains(searchString.SName));
            }
            if (!string.IsNullOrEmpty(searchString.SEmail))
            {
                query = query.Where(x => x.Email.Contains(searchString.SEmail));
            }
            if (!string.IsNullOrEmpty(searchString.SMobile))
            {
                query = query.Where(x => x.Mobile.Equals(searchString.SMobile));
            }
            if (searchString.SBirthDate!=null)
            {
                query = query.Where(x => x.DOB.Equals(searchString.SBirthDate));
            }

           var employees=await query.Skip(skip).Take(pageSize).ToListAsync();

            var totalCount = await query.CountAsync();

            return (employees, totalCount);
        }


        public async Task<bool> UpdateAsync(Employee Entity)
        {
            await _unitofwork.EmployeeRepository.Update(Entity);
            return await _unitofwork.CompleteAsync();
        }
    }
}
