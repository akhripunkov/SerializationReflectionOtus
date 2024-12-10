namespace SerializationReflectionOtus.Models;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    
    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}