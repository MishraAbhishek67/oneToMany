using System.Linq;
using Mapping_one_to_Many.Data;
using Mapping_one_to_Many.DTO;
using Mapping_one_to_Many.Model.Entity;
using Mapping_one_to_Many.RTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mapping_one_to_Many.Controllers
{
    public class EmployeeController : Controller

    {
        private readonly ApplicationDBContext db;

        public EmployeeController(ApplicationDBContext _db)
        {
            db = _db;
        }


        [HttpPost]
        [Route("PostEmployee")]
        public async Task<IActionResult> PostEmployee([FromBody] EmployeeDto dto)
        {

            if(dto == null)
            {
                return BadRequest("Dto was null");
            }

            var employeeData = new Employee()
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Salary = dto.Salary,
                Addresses = new List<Address>
                {
                    new Address
                    {
                    Street_address = dto.Street_address,
                    City = dto.City,
                    State = dto.State,
                    Zip_code = dto.Zip_code,
                    Country = dto.Country
                    }                   
                }
            };

            await db.Employees.AddAsync(employeeData);
            await db.SaveChangesAsync();

            return Ok("Employee created successfully");
        }

        [HttpPut]
        [Route("UpdateEmployee{id:int}")]
        public async Task<IActionResult> UpdateEmployee(int id,[FromBody] EmployeeDto dto)
        {
            var existingEmployee = await db.Employees.Include(a => a.Addresses).FirstOrDefaultAsync(a => a.Id == id);
            if(existingEmployee == null)
            {
                return NotFound("Employee does not exists");
            }
            if (dto == null)
            {
                return BadRequest("Dto was null");
            }
            existingEmployee.Name = dto.Name;
            existingEmployee.Email = dto.Email;
            existingEmployee.Phone = dto.Phone;
            existingEmployee.Salary = dto.Salary;
  
            foreach (var address in existingEmployee.Addresses)
            {
                address.Street_address = dto.Street_address;
                address.City = dto.City;
                address.State = dto.State;
                address.Zip_code = dto.Zip_code;
                address.Country = dto.Country;
            }
            db.Employees.Update(existingEmployee);
            await db.SaveChangesAsync();
            return Ok("Updated successfully");

        }

        //[HttpGet]
        //[Route("GetAllEmployee")]
        //public async Task<IActionResult> GetAll()
        //{
        //    var allEmployee = await db.Employees.Include(a => a.Addresses).ToListAsync();
        //    return Ok(allEmployee);
        //}

        [HttpGet]
        [Route("GetAllEmployee")]
        public async Task<IActionResult> GetAll()
        {
        
            var employeeData = await db.Employees.Include(a => a.Addresses).Select(z => new EmployeeRto()
            {
                Name = z.Name,
                Email = z.Email,
                Phone = z.Phone,
                Salary = z.Salary,
                State = z.Addresses.FirstOrDefault().State,
                Country = z.Addresses.FirstOrDefault().Country,
                ZipCode = z.Addresses.FirstOrDefault().Zip_code,
                City = z.Addresses.FirstOrDefault().City,
                StreetAddress = z.Addresses.FirstOrDefault().Street_address
            })
              .ToListAsync();

            return Ok(employeeData);
        }

        [HttpGet]
        [Route("GetById{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await db.Employees.Include(a => a.Addresses).FirstOrDefaultAsync(a => a.Id == id);
            return Ok(employee);
        }

        [HttpDelete]
        [Route("DeleteEmployee{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await db.Employees.Include(a => a.Addresses).FirstOrDefaultAsync(a => a.Id == id);
            db.Employees.Remove(employee);

            await db.SaveChangesAsync();

            return Ok("Employee deleted successfully");
        }

        [HttpDelete]
        [Route("SoftDelete{id:int}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var existingEmployee = await db.Employees
        .Include(a => a.Addresses)
        .FirstOrDefaultAsync(a => a.Id == id);

            if (existingEmployee == null)
            {
                return NotFound("Employee does not exist");
            }

            // Mark as deleted
            existingEmployee.IsDeleted = true;
            existingEmployee.DeletedAt = DateTime.UtcNow; // Optional

            db.Employees.Update(existingEmployee);
            await db.SaveChangesAsync();

            return Ok("Employee soft deleted successfully");
        }

        [HttpGet]
        [Route("GetAllEmployeeExcludingSoftDeleted")]
        public async Task<IActionResult> GetAllExcludingSoftDelete()
        {
            var employee = await db.Employees.Include(a => a.Addresses).Where(e => !e.IsDeleted).ToListAsync();
            return Ok(employee);
        }
    }
}
