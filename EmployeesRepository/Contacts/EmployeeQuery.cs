namespace EmployeesRepository.Contacts
{
    public class EmployeeQuery
    {
        public string? SEmail { get; set; }
        public string? SName { get; set; }
        public DateOnly? SBirthDate { get; set; } = null;
        public string? SMobile { get; set; }
     

    }
}