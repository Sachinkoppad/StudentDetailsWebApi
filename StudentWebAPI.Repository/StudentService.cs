using System;
using System.Text;
using Commonlibrary;
using Commonlibrary.Exceptions;
using StudentDetails;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Repository
{
    // methods are  implemented 
    public class StudentService:IStudentService
    {
        private SqlConnection _connection;
        private SqlCommand _command;

        public StudentService()
        {
            _connection = new SqlConnection(ApplicationContext.ConnectionString);
        }
        
        //delete method is implemented inorder to delete the data from database

        public bool DeleteStudent(int rollNumber)
        {
            //try and catch are used to check the connection opened or closed 
            bool isSuccess = false;
            try
            {
                using (_command = new SqlCommand($"DELETE FROM STUDENT WHERE Id = {rollNumber}", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    _command.ExecuteNonQuery();

                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new StudentException(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }
            return isSuccess;
        }
        //insert method is implemented inorder insert data into database
        public bool InsertData(Student student)
        {
            bool isSuccess = false;
            try
            {
                using (_command = new SqlCommand($"INSERT INTO STUDENT (Name, Class) VALUES ('{student.Name}', {student.Class})", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    _command.ExecuteNonQuery();

                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new StudentException(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return isSuccess;
        }

        public bool ToNextClass(int rollNumber)
        {
            bool isSuccess = false;
            try
            {
                using (_command = new SqlCommand($"UPDATE STUDENT SET Class = Class + 1 WHERE Id = {rollNumber}", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    _command.ExecuteNonQuery();

                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new StudentException(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }
            return isSuccess;
        }

        public IEnumerable<Student> GetStudents()
        {
            List<Student> _students = new List<Student>();

            try
            {
                using (_command = new SqlCommand($"SELECT Id, Name, Class FROM STUDENT ;", _connection)) 
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    SqlDataReader reader = _command.ExecuteReader();

                    while (reader?.Read() ?? false)
                        _students.Add(new Student() { Id = reader.GetInt32(0), Name = reader.GetString(1), Class = reader.GetInt32(2) });
                }
            }
            catch (Exception ex)
            {
                throw new StudentException(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return _students;
        }
    }
}
