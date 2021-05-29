using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

[ApiController]
[Route("student")]
public class StudentController : ControllerBase
{
    MySqlConnection connection =null;
    MySqlCommand mySqlCommand = null;

    public StudentController(IConfiguration configuration)
    {
        connection = new MySqlConnection(configuration.GetSection("ConnectionStrings").GetSection("Default").Value);
    }
    [HttpGet]
    [Route("/getAll/students")]
    public async Task<List<Student>> getAllStudents()
    {
         await connection.OpenAsync();
        return null;
    }
    [HttpPost]
    [Route("/deleteStudent/{studentID}")]
    public async Task delete(string studentID)
    {
          await connection.OpenAsync();

    }
    [HttpPost]
    [Route("/createStudent")]
    public async Task createStudent(string studentName,string studentEmail,string studentNumber,string subject,string studentDetails)
    {
        await connection.OpenAsync();
    }
    [HttpPost]
    [Route("/edit/{studentID}")]
    public async Task edit(string studentID)
    {
        await connection.OpenAsync();
    }


}