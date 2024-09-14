using EmployeesCore.EntityModel;
using EmployeesCore.EntityModel.Core;
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
        public async Task<IActionResult> Index()
        {
            var Employee=await _employeeService.GetAllAsync();
            return View(Employee);
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
                var obj = new Employee();
                var path = _webHostEnvironment.WebRootPath;

                // Generate a new GUID and use the file's original extension
                var fileExtension = Path.GetExtension(emp.Image.FileName);
                var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
                var filePath = "Images/" + uniqueFileName;
                var fullPath = Path.Combine(path, filePath);

                // Resize and upload image
                FileUpload(emp.Image, fullPath);

                obj.FirstName = emp.FirstName;
                obj.LastName = emp.LastName;
                obj.DOB = emp.DOB;
                obj.Email = emp.Email;
                obj.Mobile = emp.Mobile;
                obj.ImageUrl = filePath;

                await _employeeService.AddAsync(obj);

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

                    // Save the resized image to the desired path
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
       



    }
}
