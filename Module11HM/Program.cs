using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module11HM
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите количество сотрудников:");
            int n = int.Parse(Console.ReadLine());

            Employee[] employees = new Employee[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите информацию о сотруднике {i + 1}:");

                Console.Write("Имя: ");
                employees[i].FirstName = Console.ReadLine();

                Console.Write("Фамилия: ");
                employees[i].LastName = Console.ReadLine();

                Console.Write("Дата приема на работу: ");
                employees[i].HireDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Должность: ");
                employees[i].Position = Console.ReadLine();

                Console.Write("Пол (М/Ж): ");
                employees[i].Gender = char.Parse(Console.ReadLine());

                Console.Write("Зарплата: ");
                employees[i].Salary = decimal.Parse(Console.ReadLine());
                Console.ReadKey();
            }

            DisplayAllEmployees(employees);

            Console.WriteLine("Введите должность:");
            string positionFilter = Console.ReadLine();
            DisplayEmployeesByPosition(employees, positionFilter);

            DisplayManagersAboveClerkAverageSalary(employees);

            Console.WriteLine("Введите дату:");
            DateTime hireDateFilter = DateTime.Parse(Console.ReadLine());
            DisplayEmployeesHiredAfterDate(employees, hireDateFilter);

            Console.WriteLine("Введите пол:");
            char genderFilter = char.Parse(Console.ReadLine());
            DisplayEmployeesByGender(employees, genderFilter);
        }

        static void DisplayAllEmployees(Employee[] employees)
        {
            Console.WriteLine("Полная информация обо всех сотрудниках:");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.ToString());
            }
        }

        static void DisplayEmployeesByPosition(Employee[] employees, string position)
        {
            Console.WriteLine($"Информация о сотрудниках на должности {position}:");
            foreach (var employee in employees)
            {
                if (employee.Position.Equals(position, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(employee.ToString());
                }
            }
        }

        static void DisplayManagersAboveClerkAverageSalary(Employee[] employees)
        {
            decimal clerkAverageSalary = employees
                .Where(e => e.Position.Equals("Clerk", StringComparison.OrdinalIgnoreCase))
                .Average(e => e.Salary);

            var managersAboveAverage = employees
                .Where(e => e.Position.Equals("Manager", StringComparison.OrdinalIgnoreCase) && e.Salary > clerkAverageSalary)
                .OrderBy(e => e.LastName);

            Console.WriteLine($"Менеджеры с зарплатой выше средней зарплаты клерков ({clerkAverageSalary:C}):");
            foreach (var manager in managersAboveAverage)
            {
                Console.WriteLine(manager.ToString());
            }
        }

        static void DisplayEmployeesHiredAfterDate(Employee[] employees, DateTime hireDate)
        {
            var filteredEmployees = employees
                .Where(e => e.HireDate > hireDate)
                .OrderBy(e => e.LastName);

            Console.WriteLine($"Информация о сотрудниках, принятых на работу после {hireDate.ToShortDateString()}:");
            foreach (var employee in filteredEmployees)
            {
                Console.WriteLine(employee.ToString());
            }
        }

        static void DisplayEmployeesByGender(Employee[] employees, char gender)
        {
            var filteredEmployees = employees;

            if (gender != '\0')
            {
                filteredEmployees = employees.Where(e => e.Gender == gender).ToArray();
            }

            Console.WriteLine($"Информация о сотрудниках {GetGenderDescription(gender)}:");
            foreach (var employee in filteredEmployees)
            {
                Console.WriteLine(employee.ToString());
            }
        }

        static string GetGenderDescription(char gender)
        {
            switch (char.ToUpper(gender))
            {
                case 'М':
                    return "мужчины";
                case 'Ж':
                    return "женщины";
                default:
                    return "все";
            }
        }
    }
}
