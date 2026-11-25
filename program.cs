using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyHocSinhLinq
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // Khởi tạo sẵn ít nhất 5 học sinh theo đề bài
            List<Student> students = new List<Student>
            {
                new Student(1, "An", 16),
                new Student(2, "Bình", 14),
                new Student(3, "Anh", 18),
                new Student(4, "Minh", 15),
                new Student(5, "Lan", 19)
            };

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("=== MENU QUẢN LÝ HỌC SINH (LINQ) ===");
                Console.WriteLine("1. In toàn bộ danh sách học sinh");
                Console.WriteLine("2. Tìm học sinh có tuổi từ 15 đến 18");
                Console.WriteLine("3. Tìm học sinh có tên bắt đầu bằng chữ \"A\"");
                Console.WriteLine("4. Tính tổng tuổi của tất cả học sinh");
                Console.WriteLine("5. Tìm học sinh có tuổi lớn nhất");
                Console.WriteLine("6. Sắp xếp danh sách theo tuổi tăng dần");
                Console.WriteLine("7. Thêm học sinh mới");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        DisplayAllStudents(students);
                        break;
                    case "2":
                        DisplayStudentsByAgeRange(students, 15, 18);
                        break;
                    case "3":
                        DisplayStudentsByNamePrefix(students, "A");
                        break;
                    case "4":
                        DisplayTotalAge(students);
                        break;
                    case "5":
                        DisplayOldestStudents(students);
                        break;
                    case "6":
                        DisplayStudentsSortedByAge(students);
                        break;
                    case "7":
                        AddStudent(students);
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Kết thúc chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddStudent(List<Student> students)
        {
            Console.WriteLine("=== Thêm học sinh ===");
            Student s = new Student();
            s.Input();
            students.Add(s);
            Console.WriteLine("Thêm thành công!");
        }

        // a. In toàn bộ danh sách học sinh
        static void DisplayAllStudents(List<Student> students)
        {
            Console.WriteLine("=== a. Toàn bộ danh sách học sinh ===");
            var all = students.ToList();
            foreach (var s in all)
            {
                s.Show();
            }
        }

        // b. Tìm và in học sinh có tuổi từ 15 đến 18
        static void DisplayStudentsByAgeRange(List<Student> students, int minAge, int maxAge)
        {
            Console.WriteLine($"=== b. Học sinh có tuổi từ {minAge} đến {maxAge} ===");
            var result = students.Where(s => s.Age >= minAge && s.Age <= maxAge).ToList();
            PrintList(result, "Không có học sinh nào trong khoảng tuổi này.");
        }

        // c. Tìm và in học sinh có tên bắt đầu bằng chữ "A"
        static void DisplayStudentsByNamePrefix(List<Student> students, string prefix)
        {
            Console.WriteLine($"=== c. Học sinh có tên bắt đầu bằng \"{prefix}\" ===");
            var result = students.Where(s => s.Name.StartsWith(prefix)).ToList();
            PrintList(result, $"Không có học sinh nào có tên bắt đầu bằng \"{prefix}\".");
        }

        // d. Tính tổng tuổi của tất cả học sinh
        static void DisplayTotalAge(List<Student> students)
        {
            int totalAge = students.Sum(s => s.Age);
            Console.WriteLine($"=== d. Tổng tuổi của tất cả học sinh: {totalAge} ===");
        }

        // e. Tìm và in học sinh có tuổi lớn nhất
        static void DisplayOldestStudents(List<Student> students)
        {
            Console.WriteLine("=== e. Học sinh có tuổi lớn nhất ===");
            if (students.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }

            int maxAge = students.Max(s => s.Age);
            var oldest = students.Where(s => s.Age == maxAge).ToList();
            PrintList(oldest, "Không tìm thấy.");
        }

        // f. Sắp xếp danh sách theo tuổi tăng dần và in ra
        static void DisplayStudentsSortedByAge(List<Student> students)
        {
            Console.WriteLine("=== f. Danh sách học sinh sắp xếp theo tuổi tăng dần ===");
            var sorted = students.OrderBy(s => s.Age).ToList();
            PrintList(sorted, "Danh sách trống.");
        }

        static void PrintList(List<Student> list, string emptyMsg)
        {
            if (list.Count == 0)
            {
                Console.WriteLine(emptyMsg);
                return;
            }

            foreach (var s in list)
            {
                s.Show();
            }
        }
    }
}
