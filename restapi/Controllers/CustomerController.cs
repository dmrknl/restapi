using Microsoft.AspNetCore.Mvc;
using restapi.Helpers;
using restapi.Models;

namespace restapi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CustomerController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllCustomers() => Ok(DBHelper.GetAllCustomers());

    [HttpGet]
    public IActionResult GetCustomer(int id)
    {
        var a = DBHelper.GetCustomer(id);

        if (a is null)
            return NotFound();

        return Ok(a);
    }
    [HttpPost]
    public IActionResult PostCustomer([FromBody] Customer customer)
    {
        DBHelper.InsertCustomer(customer);
        return Ok(customer);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        DBHelper.DeleteCustomer(id);
        return Ok();
    }
    [HttpPut]
    public IActionResult PutCustomer([FromBody] Customer customer)
    {
        DBHelper.UpdateCustomer(customer);
        return Ok(customer);
    }
}