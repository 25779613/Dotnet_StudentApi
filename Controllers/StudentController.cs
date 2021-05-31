using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Net;
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

    public StudentController(IConfiguration config)
    {
        studentSQLCommands = new StudentSQLCommands(config);
    }

    [HttpPost]
    [Route("/createStudent")]
    public async Task<HttpStatusCode> createStudent(Student student)
    {
        string studentName = student.studentName;
        string studentEmail = student.studentEmail;
        string studentNumber = student.studentNumber;
        string subject = student.subject;
        string studentDetails = student.studentDetails;
        HttpStatusCode statusCode = HttpStatusCode.Created;
        DbDataReader studentReader = null;
        try
        {
            studentReader = await studentSQLCommands.createStudent(studentName, studentEmail, studentNumber, subject, studentDetails);

        }
        catch (Exception)
        {
            statusCode = HttpStatusCode.UnavailableForLegalReasons;
        }
        await studentSQLCommands.CloseConnection();
        //Console.WriteLine(studentName+""+studentEmail+""+studentNumber+""+subject+""+studentDetails);]
        return statusCode;
    }

    [HttpGet]
    [Route("/get/all/students")]
    public async Task<List<Student>> getAllStudents()
    {
        List<Student> students = new List<Student>();
        DbDataReader studentReader = null;
        studentReader = await studentSQLCommands.findAllStudents();
        while (await studentReader.ReadAsync())
        {
            students.Add(
                new Student()
                {
                    studentID = Convert.ToInt16(studentReader.GetValue("studentID")),
                    studentName = studentReader.GetValue("studentName").ToString(),
                    studentEmail = studentReader.GetValue("studentEmail").ToString(),
                    studentNumber = studentReader.GetValue("studentNumber").ToString(),
                    subject = studentReader.GetValue("subject").ToString(),
                    studentDetails = studentReader.GetValue("studentDetails").ToString(),
                }
            );
        }
        await studentSQLCommands.CloseConnection();
        return students;
    }

    [HttpGet]
    [Route("/get/student/{studentID}")]
    public async Task<Student> getStudent(string studentID)
    {
        DbDataReader studentReader = null;

        studentReader = await studentSQLCommands.findStudent(studentID);
        Student student =null;
        while(await studentReader.ReadAsync())
        {
         student = (new Student()
        {
            studentID = Convert.ToInt16(studentReader.GetValue("studentID").ToString()),
            studentName = studentReader.GetValue("studentName").ToString(),
            studentEmail = studentReader.GetValue("studentEmail").ToString(),
            studentNumber = studentReader.GetValue("studentNumber").ToString(),
            subject = studentReader.GetValue("subject").ToString(),
            studentDetails = studentReader.GetValue("studentDetails").ToString(),

        });
        }
       
        await studentSQLCommands.CloseConnection();
        return student;
    }
    [HttpPost]
    [Route("/deleteStudent/{studentID}")]
    public async Task<HttpStatusCode> delete(string studentID)
    {
        HttpStatusCode httpStatusCode = HttpStatusCode.Created;
        DbDataReader studentReader = null;
        try
        {
            studentReader = await studentSQLCommands.deleteStudent(studentID);
        }
        catch (Exception)
        {
            httpStatusCode = HttpStatusCode.Conflict;
        }
        await studentSQLCommands.CloseConnection();
        return httpStatusCode;
    }

    [HttpPost]
    [Route("/editStudent/{studentID}")]
    public async Task<HttpStatusCode> edit(string studentID, string studentEmail, string subject, string studentDetails)
    {
        DbDataReader studentReader = null;
        HttpStatusCode httpStatusCode = HttpStatusCode.Created;
        try
        {
            studentReader = await studentSQLCommands.updateStudent(studentID, studentEmail, subject, studentDetails);
        }
        catch (Exception)
        {
            httpStatusCode = HttpStatusCode.ExpectationFailed;
        }

        await studentSQLCommands.CloseConnection();
        return httpStatusCode;
    }


}