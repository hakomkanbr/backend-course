using ECommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers;

[ApiController]
[Route("students")]
public class StudentsController : ControllerBase
{

    private readonly IStudentService _studentService;

    public StudentsController(
        IStudentService studentService
        )
    {
        _studentService = studentService;
    }

    [HttpGet("GetAll")]
    [Authorize]
    public IActionResult GetStudents()
    {
        var students = _studentService.GetStudents();
        return BadRequest("the comiang model is wrong");
    }

    [HttpGet]
    public IActionResult Get(int id)
    {
        var student = _studentService.GetStudent(id);
        return Ok(student);
    }

    [HttpPost]
    public IActionResult Post(Student student)
    {
        var studentId = _studentService.AddStudent(student);
        return Ok(studentId);
    }

    [HttpPut]
    public IActionResult Put(Student student)
    {
        var studentId = _studentService.UpdateStudent(student);
        return Ok(studentId);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        _studentService.DeleteStudent(id);
        return Ok();
    }
}
