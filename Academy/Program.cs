// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Collections.Generic;

namespace StudentGrades
{
    // Класс для представления оценки студента
    class Grade
    {
        public DateTime Date { get; set; }
        public string Teacher { get; set; }
        public string Subject { get; set; }
        public string Student { get; set; }
        public int Value { get; set; }

        public Grade(DateTime date, string teacher, string subject, string student, int value)
        {
            Date = date;
            Teacher = teacher;
            Subject = subject;
            Student = student;
            Value = value;
        }
    }

    class Program
    {
        static List<Grade> grades = new List<Grade>();

        static void Main(string[] args)
        {
            // Запуск главного меню
            RunMainMenu();
        }

        static void RunMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Добавить оценку");
                Console.WriteLine("2. Просмотреть все оценки");
                Console.WriteLine("3. Просмотреть оценки по студентам");
                Console.WriteLine("4. Просмотреть оценки по предметам");
                Console.WriteLine("5. Выход");

                Console.Write("Выберите пункт меню: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddGrade();
                        break;
                    case 2:
                        ShowAllGrades();
                        break;
                    case 3:
                        ShowGradesByStudents();
                        break;
                    case 4:
                        ShowGradesBySubjects();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте еще раз.");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        static void AddGrade()
        {
            Console.WriteLine("Добавление новой оценки...");

            Console.Write("Дата оценки (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.Write("Преподаватель: ");
            string teacher = Console.ReadLine();

            Console.Write("Предмет: ");
            string subject = Console.ReadLine();

            Console.Write("Студент: ");
            string student = Console.ReadLine();

            Console.Write("Оценка: ");
            int value = Convert.ToInt32(Console.ReadLine());

            grades.Add(new Grade(date, teacher, subject, student, value));

            Console.WriteLine("Оценка добавлена!");
        }

        static void ShowAllGrades()
        {
            Console.WriteLine("Все оценки студентов:");

            foreach (var grade in grades)
            {
                Console.WriteLine($"{grade.Date.ToShortDateString()} | {grade.Teacher} | {grade.Subject} | {grade.Student} {grade.Value}");
            }
        }

        static void ShowGradesByStudents()
        {
            Console.Write("Введите имя студента: ");
            string student = Console.ReadLine();

            Console.WriteLine($"Оценки студента {student}:");

            foreach (var grade in grades)
            {
                if (grade.Student == student)
                {
                    Console.WriteLine($"{grade.Date.ToShortDateString()} | {grade.Teacher} | {grade.Subject} | {grade.Value}");
                }
            }
        }

        static void ShowGradesBySubjects()
        {
            Console.Write("Введите название предмета: ");
            string subject = Console.ReadLine();

            Console.WriteLine($"Оценки по предмету {subject}:");

            foreach (var grade in grades)
            {
                if (grade.Subject == subject)
                {
                    Console.WriteLine($"{grade.Date.ToShortDateString()} | {grade.Teacher} | {grade.Student} | {grade.Value}");
                }
            }
        }
    }
}