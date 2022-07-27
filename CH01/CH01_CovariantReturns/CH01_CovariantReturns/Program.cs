object[] covariantArray = new string[] { "alpha", "beta", "gamma", "delta" };

public interface ICovariant<out T> { }
public class Covariant<T> : ICovariant<T> { }

public class Person { }
public class Teacher : Person { }
public class Student : Person { }

public class CovarianceExample
{
    public void CovarianceAtWork()
    {
        ICovariant<Person> person = new Covariant<Person>();
        ICovariant<Teacher> teacher = new Covariant<Teacher>();
        ICovariant<Student> student = new Covariant<Student>();

        CovariantMethod(person);
        CovariantMethod(teacher);
        CovariantMethod(student);
    }

    public void CovariantMethod(ICovariant<Person> person)
    {

    }
}