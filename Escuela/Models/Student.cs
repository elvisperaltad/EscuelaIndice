using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Escuela.Models
{
    public class Student
    {
        public string StudentID {get; set;}
        public string StudentName { get; set; }
        public List<Courses> Courses { get; set;}
    }
}