namespace ECommerce.Models;

// Object => تمثل الاشياء
// Properties => تمثل الصفات
// Methods => تمثل الأفعال
public class Person // Object
{
    public int Id { get; set; } // Property
    public string Name { get; set; } // Property
    public int Age { get; set; } // Property

};

public class Manager : Person {

    public void GetRole()
    {
        Console.WriteLine("I am Teacher...");
    }
}

public class Teacher : Person {
    public  void GetRole()
    {
        Console.WriteLine("I am Teacher...");
    }
}

public class Student : Person
{
    public void GetRole()
    {
        Console.WriteLine("I am Student...");
    }
}

public interface IStudentService
{
    public int AddStudent(Student student);
    public int UpdateStudent(Student student);
    public void DeleteStudent(int studentId);
    public List<Student> GetStudents();
    public Student GetStudent(int id);
};

public class StudentService : IStudentService
{
    public static List<Student> _students { get; set; } = new();

    public int AddStudent(Student student)
    {
        _students.Add(student);
        return 1;
    }

    public void DeleteStudent(int studentId)
    {
        var student = _students.FirstOrDefault(i => i.Id == studentId);
        if (student == null) throw new Exception("Student Not Found");
        _students.Remove(student);
    }

    public Student GetStudent(int studentId)
    {
        var student = _students.FirstOrDefault(i => i.Id == studentId);
        if (student == null) throw new Exception("Student Not Found");
        return student;
    }

    public List<Student> GetStudents()
    {
        return _students;
    }

    public int UpdateStudent(Student student)
    {
        var studentIndex = _students.FindIndex(i => i.Id == student.Id);
        if (studentIndex == -1) throw new Exception("Student Not Found");

        var newStudent = new Student();

        newStudent.Name = student.Name;
        newStudent.Age = student.Age;

        _students[studentIndex] = newStudent;

        return newStudent.Id;
    }
};

//public abstract class Employee {
//    public string Name { get; set; }
//    public abstract decimal CalculateSalary();
//}

//public class FullTimeEmployee : Employee
//{
//    public override decimal CalculateSalary()
//    {
//        return 5000;
//    }
//}

//public class PartTimeEmployee : Employee
//{
//    public override decimal CalculateSalary()
//    {
//        return 1500;
//    }
//}

// School Mangement

/*
 * Manager
 * Teacher
 * Student
*/

public interface IReport
{
    public void GenerateReport();
}


public class StudentReport : IReport
{
    public void GenerateReport() {
        Console.WriteLine("Student Report Generated");
    }
}

public class TeachrtReport : IReport
{
    public void GenerateReport()
    {
        Console.WriteLine("Teacher Report Generated");
    }
}