using DataShelfMaster.Context;
using DataShelfMaster.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataShelfMaster.Services
{
    public class StudentService
    {
        #region Student
        public void CreateStudents(Student request)
        {
            try
            {
                using (var _context = new ApplicationDBContext())
                {
                    Student student = new Student()
                    {
                        Matric = request.Matric,
                        Name = request.Name,
                        LastName = request.LastName,
                        Turn = request.Turn,
                        Career = request.Career,
                        Semester = request.Semester
                    };
                    _context.Students.Add(student);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Bug: ", ex);
            }
        }
        public List<Student> ReadStudents()
        {
            try
            {
                var _context = new ApplicationDBContext();
                var student = _context.Students.ToList();
                return student;
            }
            catch (Exception ex)
            {
                throw new Exception("Bug: ", ex);
            }
        }
        public void UpdateStudents(Student request, string x)
        {
            try
            {
                using (var _context = new ApplicationDBContext())
                {
                    var student = _context.Students.Where(s => s.Matric == x).First<Student>();
                    student.Matric = request.Matric;
                    student.Name = request.Name;
                    student.LastName = request.LastName;
                    student.Turn = request.Turn;
                    student.Career = request.Career;
                    student.Semester = request.Semester;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Bug: ", ex);
            }
        }
        public void DeleteStudents(Student request)
        {
            try
            {
                using (var _context = new ApplicationDBContext())
                {
                    var student = _context.Students.FirstOrDefault(s => s.Matric == request.Matric);
                    _context.Students.Remove(student);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Bug: ", ex);
            }
        }
        //- - - Adicional - - -//
        public List<Student> SearchStudents(Student request)
        {
            try
            {
                var _context = new ApplicationDBContext();
                var student = _context.Students.Where(s=>
                s.Matric==request.Matric||
                s.Name==request.Name||
                s.LastName==request.LastName||
                s.Turn==request.Turn||
                s.Career==request.Career||
                s.Semester==request.Semester).ToList();
                return student;
            }
            catch (Exception ex)
            {
                throw new Exception("Bug: ", ex);
            }
        }
        public string ValidateStudent(Student request)
        {
            try
            {
                var _context = new ApplicationDBContext();
                var validate = _context.Students.Where(s => s.Matric == request.Matric).ToList();
                return validate.Count.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Bug: ", ex);
            }
        }
        #endregion
    }
}
