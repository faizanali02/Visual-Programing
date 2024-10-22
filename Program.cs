﻿using System;

public class Program
{
    public enum Department
    {
        ComputerScience,
        Mathematics,
        Physics,
        Chemistry,
        Biology
    }

    public class Person
    {
        public string Name { get; set; }

        // No-argument constructor
        public Person()
        {
            Name = null;
        }

        // Multi-argument constructor
        public Person(string name)
        {
            Name = name;
        }
    }

    public class Student : Person
    {
        public string RegNo { get; set; }
        public int Age { get; set; }
        public Department Program { get; set; }

        // No-argument constructor
        public Student() : base()
        {
            RegNo = null;
            Age = 18;
            Program = default(Department);
        }
        
        // Multi-argument constructor
        public Student(string name, string regNo, int age, Department program) : base(name)
        {
            RegNo = regNo;
            Age = age;
            Program = program;
        }
    }
    
    public static void Main(string[] args)
    {
        // Using no-argument constructors
        Student student1 = new Student();
        Console.WriteLine($"Student1 - Faizan Ali: {student1.Name}, RegNo:233574 {student1.RegNo}, Age: {student1.Age}, Program: {student1.Program}");

        // Using multi-argument constructors
        Student student2 = new Student("Muneeb Rao", "233560", 20, Department.ComputerScience);
        Console.WriteLine($"Student2 - {student2.Name}, RegNo: {student2.RegNo}, Age: {student2.Age}, Program: {student2.Program}");
    }
}

