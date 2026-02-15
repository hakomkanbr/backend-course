namespace ECommerce.Models;

// Object => تمثل الاشياء
// Properties => تمثل الصفات
// Methods => تمثل الأفعال
public class Person // Object
{
    public string Name { get; set; } // Property
    private int Age { get; set; } // Property

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
    //public int UpdateStudent(Student student);
    //public void DeleteStudent(int studentId);
    public List<Student> GetStudents();
    //public Student GetStudent();
};

public class StudentService : IStudentService
{
    public static List<Student> _students { get; set; } = new();

    public int AddStudent(Student student)
    {
        _students.Add(student);
        return 1;
    }

    public List<Student> GetStudents()
    {
        return _students;
    }
};

// School Mangement

/*
 * Manager
 * Teacher
 * Student
*/
