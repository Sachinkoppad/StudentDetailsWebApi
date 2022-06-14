using StudentDetails;
using System;
using System.Collections.Generic;

namespace Repository
{
    public interface IStudentService
    {
        //function are instantiated 
        IEnumerable<Student> GetStudents();
        bool ToNextClass(int rollNumber);
        bool InsertData(Student student);
        bool DeleteStudent(int rollNumber);
    }
}
