using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentDetails;
using Repository;
using studentwebapi2.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestCase1
{
    
        [TestClass]
        public class 
        UnitTest1
        {
            [TestMethod]
            public void StudentList()
            {
                IStudentService student = new StudentService();

                StudentController studentController = new StudentController(student);

                List<Student> stundtLst = (List<Student>)studentController.GetStudents();

                Assert.AreEqual("aliva", stundtLst[0].Name);
                Assert.AreEqual(2, stundtLst[0].Id);
                Assert.AreEqual(3, stundtLst[0].Class);



            }
         
            [TestMethod]
            public void Insert()
            {
                IStudentService student = new StudentService();

                StudentController studentController = new StudentController(student);

                IEnumerable<Student> stundtLst = studentController.insert(new Student() { Class = 2, Name = "" });

                Assert.AreEqual(11, stundtLst.Count());


            }

            [TestMethod]
            public void DeleStudent()
            {
                IStudentService student = new StudentService();

                StudentController studentController = new StudentController(student);

                IEnumerable<Student> stundtLst = studentController.DeleStudent(15);

                Assert.AreEqual(10, stundtLst.Count());


            }

        }
    }
