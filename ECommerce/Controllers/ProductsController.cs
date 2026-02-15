using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{

    private readonly IStudentService _studentService;

    public ProductsController(
        IStudentService studentService
        )
    {
        _studentService = studentService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var students = _studentService.GetStudents();
        return Ok(students);
    }

    [HttpPost]
    public IActionResult Add(Student student)
    {
        _studentService.AddStudent(student);
        return Ok(true);
    }
}
