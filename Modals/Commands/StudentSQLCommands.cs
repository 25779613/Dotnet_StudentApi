using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace StudentApi.Modals.Commands
{
    public class StudentSQLCommands
    {
       private MySqlConnection connection =null;
       private MySqlCommand mySqlCommand = null;

       public StudentSQLCommands(IConfiguration configuration)
    {
        connection = new MySqlConnection(configuration.GetSection("ConnectionStrings").GetSection("Default").Value);
    }

    public async Task<DbDataReader> createStudent(string studentName,string studentEmail,string studentNumber,string subject,string studentDetails)
    {
        await connection.OpenAsync();
        mySqlCommand = new MySqlCommand("INSERT INTO students(studentName,studentEmail,studentNumber,subject,studentDetails)VALUES('"+studentName+"','"+studentEmail+"','"+studentNumber+"','"+subject+"','"+studentDetails+"')",connection);
        var result = await mySqlCommand.ExecuteReaderAsync();
        await connection.CloseAsync();

        return result;
    }

    public async Task<DbDataReader> updateStudent(string studentID,string studentEmail,string subject,string studentDetails){
        await connection.OpenAsync();
        mySqlCommand = new MySqlCommand("UPDATE students SET studentEmail='"+studentEmail+"',subject='"+subject+"',studentDetails='"+studentDetails+"'WHERE studentID='"+Convert.ToInt16(studentID)+"'",connection);
        var result = await mySqlCommand.ExecuteReaderAsync();
        await connection.CloseAsync();

        return result;  
    }

    public async Task<DbDataReader> deleteStudent(string studentID)
    {
        await connection.OpenAsync();
        mySqlCommand = new MySqlCommand("DELETE FROM students WHERE studentID='"+Convert.ToInt16(studentID)+"'",connection);
        var result = await mySqlCommand.ExecuteReaderAsync();
        await connection.CloseAsync();

        return result;  
    }

    public async Task<DbDataReader> findAllStudents(){
        
        List<Student> students = new List<Student>();
        await connection.OpenAsync();
        mySqlCommand = new MySqlCommand("SELECT * FROM students",connection);
        var result = await mySqlCommand.ExecuteReaderAsync();
        await connection.CloseAsync();

        return result;  
    }    

     public async Task<DbDataReader> findStudent(string studentID){
        await connection.OpenAsync();
        mySqlCommand = new MySqlCommand("SELECT * FROM students WHERE studentID='"+Convert.ToInt16(studentID)+"'",connection);
        var result = await mySqlCommand.ExecuteReaderAsync();
        await connection.CloseAsync();

        return result;  
    }        
    }
}