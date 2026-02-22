using ECommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(
        IStudentService studentService
        )
    {
        _studentService = studentService;
    }

    [HttpGet]
    public IActionResult GetStudents()
    {
        var students = _studentService.GetStudents();
        return Ok(students);
    }

    [HttpGet]
    [Route("PrintStudentName")]
    public IActionResult PrintStudentName(string name,int age)
    {
        return Ok("Hello " + name + " Age " + age);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var student = _studentService.GetStudent(id);
        return Ok(student);
    }

    [HttpPost]
    [Route("AddStudent")]
    public IActionResult Post([FromForm] StudentDto student)
    {
        Student entity = new Student {
            Name = student.AdSoyad,
            Age = student.Yas
        };
        var studentId = _studentService.AddStudent(entity);
        return Ok(studentId);
    }

    [HttpPut]
    [Route("state")]
    public IActionResult Put(bool state)
    {
        return Ok();
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

public class StudentDto
{
    public string AdSoyad { get; set; }
    public int Yas { get; set; }
}