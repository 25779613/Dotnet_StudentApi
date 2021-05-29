using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using StudentApi.Modals.Commands;

[ApiController]
[Route("student")]
public class StudentController : ControllerBase
{   
    private StudentSQLCommands studentSQLCommands;
    
    [HttpPost]
    [Route("/createStudent")]
    public Student createStudent(Student student)
    {
        
        return null;
    }

    [HttpGet]
    [Route("/get/all/students")]
    public Student getAllStudents(Student student)
    {   
        
        return null;
    }

    [HttpPost]
    [Route("/get/student/{studentID}")]
    public Student getStudent(Student student)
    {
        return null;
    }
    [HttpPost]
    [Route("/deleteStudent/{studentID}")]
    public Student delete(Student student)
    {
        return null;
    }
    
    [HttpPost]
    [Route("/editStudent/{studentID}")]
    public Student edit(Student student)
    {
        return null;
    }


}