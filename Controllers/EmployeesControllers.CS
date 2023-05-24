using Microsoft.AspNetCore.Mvc;
using aspnet.Models;
using aspnet.Models.Domain;
using aspnet.Data;
using Microsoft.EntityFrameworkCore;

namespace aspnet.Controllers
{


    public class EmployeesController : Controller{
        private readonly MVCDbContext mvcDbContext;

        // press ctrl + . => create a assign field 

        public EmployeesController(MVCDbContext mvcDbContext)
        {
            this.mvcDbContext = mvcDbContext;
        }

        public async Task<IActionResult> Index(){
            var employee = await mvcDbContext.Employees.ToListAsync();
            return View(employee);

        } 


        [HttpGet]
        public IActionResult Add(){

            return View();  

        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee(){
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                Department = addEmployeeRequest.Department,
                DataOfBirth = addEmployeeRequest.DataOfBirth
            };

            Console.WriteLine(addEmployeeRequest.Name);

            await mvcDbContext.Employees.AddAsync(employee);
            await mvcDbContext.SaveChangesAsync();
        
            return RedirectToAction("Index");
        }

        [HttpGet]
        
        public async Task<IActionResult> Edit(Guid id){

            var employee = await mvcDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if(employee != null){
                var viewModel = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    Department = employee.Department,
                    DataOfBirth = employee.DataOfBirth
                };

                return View(viewModel); // pass viewmodel to razer page (pass employee)
            }

            return  RedirectToAction("Index");

        }


        [HttpPost]

        public async Task<IActionResult> Edit(UpdateEmployeeViewModel model){
            var employee = await mvcDbContext.Employees.FindAsync(model.Id);
            
            if(employee != null){
                employee.Name = model.Name;
                employee.DataOfBirth = model.DataOfBirth;
                employee.Email = model.Email;
                employee.Salary = model.Salary;
                employee.Department = model.Department;

                await mvcDbContext.SaveChangesAsync();

                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
            
        }


        [HttpPost]

        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model){
            var employee = await mvcDbContext.Employees.FindAsync(model.Id);

            if(employee.Id != null){
                mvcDbContext.Employees.Remove(employee);
                await mvcDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }


    }


}