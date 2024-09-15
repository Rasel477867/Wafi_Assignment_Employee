using EmployeesCore.EntityModel;
using EmployeesCore.EntityModel.Core;
using EmployeesRepository.Contacts;
using EmployeesService;
using EmployeesService.Contacts;
using EmployeesWeb.Models;
using ImageMagick;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace EmployeesWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EmployeeController(IEmployeeService employeeService, IWebHostEnvironment webHostEnvironment)
        {
            _employeeService = employeeService;
            _webHostEnvironment = webHostEnvironment;

        }
    
        public async Task<IActionResult> Index(EmployeeQuery searchString, int page = 1)
        {
            int pageSize = 4;
            var (employees, totalCount) = await _employeeService.GetEmployeesAsync(searchString, page, pageSize);

            var viewModel = new EmpViewModel
            {
                Employees = employees,
                SearchString = searchString,
                Pagination = new PaginationModel(totalCount, page, pageSize)
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeView emp)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee();
                var path = _webHostEnvironment.WebRootPath;

               
                var fileExtension = Path.GetExtension(emp.Image.FileName);
                var FileName = Guid.NewGuid().ToString() + fileExtension;
                var filePath = "Images/" + FileName;
                var fullPath = Path.Combine(path, filePath);

                // Resize and upload image
                FileUpload(emp.Image, fullPath);

                employee.FirstName = emp.FirstName;
                employee.LastName = emp.LastName;
                employee.DOB = emp.DOB;
                employee.Email = emp.Email;
                employee.Mobile = emp.Mobile;
                employee.ImageUrl = filePath;

                await _employeeService.AddAsync(employee);

                return RedirectToAction("Index");
            }

            return View(emp);
        }

        // Method to upload and resize image
        public async void FileUpload(IFormFile file, string path)
        {
          

            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                using (var img = System.Drawing.Image.FromStream(stream))
                {
                    // Resize the image
                    var resizedImage = new Bitmap(img, new Size(300, 300));

                    resizedImage.Save(path);
                }
            }
        }
        public async Task<IActionResult>Edit(Guid Id)
        {
            var employee= await _employeeService.GetByIdAsync(Id);
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult>Edit(Employee employee)
        {
            if (employee.Image == null)
            {
              await _employeeService.UpdateAsync(employee);
            }
            else
            {
                var path = _webHostEnvironment.WebRootPath;

                // Generate a new GUID and use the file's original extension
                var fileExtension = Path.GetExtension(employee.Image.FileName);
                var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
                var filePath = "Images/" + uniqueFileName;
                var fullPath = Path.Combine(path, filePath);

                // Resize and upload image
                FileUpload(employee.Image, fullPath);
                employee.ImageUrl = filePath;

                await _employeeService.UpdateAsync(employee);
                
            }
            return RedirectToAction("Index");
           
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var employee=await _employeeService.GetByIdAsync(id);
            var result = await _employeeService.DeleteAsync(employee);
           
            return Json(result);
        }


    }
}
