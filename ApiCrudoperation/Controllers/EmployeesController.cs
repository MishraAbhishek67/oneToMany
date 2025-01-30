using ApiCrudoperation.Data;
using ApiCrudoperation.Model;
using ApiCrudoperation.Model.Entity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;


namespace ApiCrudoperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly Applicationdbcontext dbcontext;

        public EmployeesController(Applicationdbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult GetAllemployee()
        {
            var allemployee = dbcontext.employees.ToList();
            return Ok(allemployee);
        }
        [HttpGet]
        [Route("Get/EmployeeAdress")]
        public IActionResult GetAllemployeeAddress()
        {
            var allemployee = dbcontext.employees.Include(e => e.Address).ToList();



            return Ok(allemployee);
        }


        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeebyID(Guid id)
        {
            var employee = dbcontext.employees.Find(id);
            if(employee is null)
            {
                return NotFound();
            }
            return Ok(employee);

        }

        [HttpPost]
        public IActionResult postEmployee(AddEmployeeDTO addEmployeeDTO)
        {
            var EmployeEntity = new Employee()
            {
                name = addEmployeeDTO.name,
                Email = addEmployeeDTO.Email,
                phone = addEmployeeDTO.phone,
                salary = addEmployeeDTO.salary,
            };
            dbcontext.employees.Add(EmployeEntity);
            dbcontext.SaveChanges();
            return Ok(EmployeEntity);
        }

        [HttpPost]
        [Route("add/EmployeeAdress")]
        public IActionResult AddEmployeeAddress([FromBody] AddEmployeeDTO addemployeedto)
        {
            var employeeEntity = new Employee
            {
                name = addemployeedto.name,
                Email = addemployeedto.Email,
                phone = addemployeedto.phone,
                salary = addemployeedto.salary,
                Address = new Address
                {
                    street_address = addemployeedto.street_address,
                    city = addemployeedto.city,
                    state = addemployeedto.state,
                    zip_code = addemployeedto.zip_code,
                    country = addemployeedto.country,

                }

            };
            dbcontext.Add(employeeEntity); 
            dbcontext.SaveChanges();    
            return Ok(employeeEntity);  
            }
        

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateEmployee(Guid id,UpdateEmployeeDTO updateEmployeeDTO)
        {
            var employee = dbcontext.employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }
            employee.name = updateEmployeeDTO.name;
            employee.Email = updateEmployeeDTO.Email;
            employee.phone = updateEmployeeDTO.phone;
            employee.salary = updateEmployeeDTO.salary;


            dbcontext.SaveChanges();
            return Ok(employee);
        }

        [HttpPut]

        [Route("update/EmployeeAdress")]
        public IActionResult UpdateEmployeeAddress(Guid id, [FromBody] UpdateEmployeeDTO updateemployeedto)
        {

           
            var employee = dbcontext.employees.Include(e => e.Address)
                .FirstOrDefault(a => a.id == id);
            if (employee is null)
            {
                return NotFound();
            }
            employee.name = updateemployeedto.name;
            employee.Email = updateemployeedto.Email;
            employee.phone = updateemployeedto.phone;
            employee.salary = updateemployeedto.salary;
            employee.Address.zip_code = updateemployeedto.zip_code;
            employee.Address.country = updateemployeedto.country;
            employee.Address.city = updateemployeedto.city;
            employee.Address.state = updateemployeedto.state;
            employee.Address.street_address = updateemployeedto.street_address;


            dbcontext.SaveChanges();
            return Ok(employee);
        }

        [HttpDelete]

        [Route("Delete/EmployeeAdress")]
        public IActionResult DeleteEmployeeAddress(Guid id)
        {
            var employee = dbcontext.employees.Include(e => e.Address)
                .FirstOrDefault(a => a.id == id);
            if (employee is null)
            {
                return NotFound();
            }
            dbcontext.employees.Remove(employee);
            dbcontext.SaveChanges();
            return Ok("Delete Succesfull");

        }





        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = dbcontext.employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }
            dbcontext.employees.Remove(employee);
            dbcontext.SaveChanges();
            return Ok("Delete Succesfull");
            
        }
    }
}
