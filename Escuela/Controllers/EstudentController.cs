using Escuela.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.Web.Http;

namespace Escuela.Controllers
{
    [Route("api/Estudent")]
  
    public class EstudentController : ApiController
    {
        // GET: Estudent
       
        [HttpPost]
        public object PostStudent(List<Student> students)
        {
            List<Response> rs = new List<Response>();
            foreach(var student in students)
            {
                Response resp = new Response();
                resp.StundentId = student.StudentID;
                resp.StudentName = student.StudentName;
                float TCreditos = 0;
                float TNotas = 0;
                
                foreach(var course in student.Courses)
                {
                    int cn = course.FinalGrade;
                    if(cn > 90)
                    {
                        TCreditos += course.CourseCredit;
                        TNotas += 4 * course.CourseCredit;

                    }else if(cn > 79 && cn < 90)
                    {
                        TCreditos += course.CourseCredit;
                        TNotas += 3 * course.CourseCredit;

                    }
                    else if (cn > 69 && cn < 80)
                    {
                        TCreditos += course.CourseCredit;
                        TNotas += 2 * course.CourseCredit;

                    }
                    else if (cn > 59 && cn < 70)
                    {
                        TCreditos += course.CourseCredit;
                        TNotas += 1 * course.CourseCredit;

                    }else
                    {
                        TCreditos += course.CourseCredit;
                        TNotas += 0 * course.CourseCredit;
                    }
                   
                }
                double indice = TNotas / TCreditos ;
                resp.StudentInd = Math.Round(indice, 2);
                rs.Add(resp);
            }
            return rs;
        }
    }
}