using EmployeesCore.EntityModel;
using EmployeesRepository.Contacts;

namespace EmployeesWeb.Models
{
    public class EmpViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public EmployeeQuery SearchString {  get; set; }
        public PaginationModel Pagination { get; set; }
    }
}
