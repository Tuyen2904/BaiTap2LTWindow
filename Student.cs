using System;

namespace QuanLyHocSinhLinq
{
    class Student
    {
        // 1. Field
        private int id;
        private string name;
        private int age;

        // 2. Property
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        // 3. Constructor
        public Student()
        {
            name = string.Empty;
        }

        public Student(int id, string name, int age)
        {
            this.id = id;
            this.name = name;
            this.age = age;
        }

        // 4. Methods
        public void Input()
        {
            Console.Write("Nhập ID: ");
            Id = int.Parse(Console.ReadLine());
            Console.Write("Nhập Tên học sinh: ");
            Name = Console.ReadLine();
            Console.Write("Nhập Tuổi: ");
            Age = int.Parse(Console.ReadLine());
        }

        public void Show()
        {
            Console.WriteLine("ID: {0} | Tên: {1} | Tuổi: {2}", this.Id, this.Name, this.Age);
        }
    }
}
