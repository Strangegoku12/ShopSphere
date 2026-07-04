using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopSphereBackend.Data;
using ShopSphereBackend.Model.VendorModel;

namespace ShopSphereBackend.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class signUpUser : ControllerBase
    {
        private readonly AppDbContext _context;

        public signUpUser(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSignEmployees()
        {
            var employees = await _context.EmployeeSignup.ToListAsync();

            return Ok(new
            {
                Message = "Employees fetched successfully.",
                Data = employees
            });
        }

        [HttpPost]
        public async Task<IActionResult> PostEmployees(EmployeeSignup employees)
        {
            var saveemployees = await _context.EmployeeSignup.AddAsync(employees);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Employees saved successfully",
                Data = saveemployees
            });
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> PostEmployees(int id)
        {
            var saveemployees = await _context.EmployeeSignup.FindAsync(id);

            return Ok(new
            {
                Message = "Employee found successfully",
                Data = saveemployees
            });
        
        }


        [HttpPatch("{EmployeeId}")]
        public async Task<IActionResult> UpdateEmployee(int EmployeeId,EmployeeSignup employee)
        {
            var particularEmployee = await _context.EmployeeSignup.FindAsync(EmployeeId);

            if (particularEmployee == null)
            {
                return NotFound(new
                {
                    Message = "Employee not found"
                });
            }

            particularEmployee.Email=employee.Email;
            particularEmployee.Username=employee.Username;
            particularEmployee.PasswordHash=employee.PasswordHash;
            particularEmployee.PhoneNumber=employee.PhoneNumber;
            particularEmployee.FullName=employee.FullName;
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Employee Updated successfully",
                Data = particularEmployee
            });
        }


        [HttpDelete("{EmployeeId}")]
            public async Task<IActionResult> DeleteEmployee(int EmployeeId)
            {
                var particularEmployee = await _context.EmployeeSignup.FindAsync(EmployeeId);

                if (particularEmployee == null)
                {
                    return NotFound(new
                    {
                        Message = "Employee not found"
                    });
                }

                _context.EmployeeSignup.Remove(particularEmployee);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    Message = "Employee deleted successfully",
                    Data = particularEmployee
                });
            }
        
}}