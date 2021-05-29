using System;
using System.ComponentModel.DataAnnotations;


    public class Student
    {
     
        [Key]
        public int studentID { get; set; }
        [Required]
        public string studentName { get; set; }

        public string studentEmail { get; set; }
        [Required]
        public string studentNumber { get; set; }
        [Required]
        public string subject { get; set; }

        public string studentDetails { get; set; }
    }

