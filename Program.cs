using System;
using System.Collections.Generic;

namespace Task1_LINQ
{
    public static class Extensions
    {
        // Q6: IsPalindrome() for string
        public static bool IsPalindrome(this string text)
        {
            int left = 0;
            int right = text.Length - 1;

            while (left < right)
            {
                if (text[left] != text[right])
                    return false;

                left++;
                right--;
            }

            return true;
        }

        // Q7: IsPrime() for int
        public static bool IsPrime(this int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                    return false; // found a divisor -> not prime
            }

            return true;
        }
    }

    // Simple class used in Q10
    public class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Q1_BasicVarUsage();
            Q2_VarVsExplicitType();
            Q3_AnonymousTypeBasics();
            Q4_ArrayOfAnonymousTypes();
            Q6_StringExtension_IsPalindrome();
            Q7_IntExtension_IsPrime();
            Q9_ListBasics();
            Q10_ListOfCustomObjects();

            Console.WriteLine("\nDone. Press any key to exit.");
            Console.ReadKey();
        }
        // Q1: Basic var usage
        static void Q1_BasicVarUsage()
        {
            Console.WriteLine("---- Q1: Basic var usage ----");

            var age = 21;                 // int
            var name = "Youssef";         // string
            var price = 19.99;            // double
            var isStudent = true;         // bool
            var numbers = new[] { 1, 2, 3 }; // int[]

            Console.WriteLine("age type: " + age.GetType());
            Console.WriteLine("name type: " + name.GetType());
            Console.WriteLine("price type: " + price.GetType());
            Console.WriteLine("isStudent type: " + isStudent.GetType());
            Console.WriteLine("numbers type: " + numbers.GetType());
            Console.WriteLine();
        }

        // Q2: var vs explicit type
        static void Q2_VarVsExplicitType()
        {
            Console.WriteLine("---- Q2: var vs explicit type ----");

            // Explicit types
            int explicitAge = 21;
            string explicitName = "Youssef";
            double explicitPrice = 19.99;

            // Same thing using var
            var varAge = 21;
            var varName = "Youssef";
            var varPrice = 19.99;

            // Why the result is the same at compile time:
            // "var" does NOT mean "any type" (like dynamic typing in Python/JS).
            // The compiler looks at the value on the right side of "="
            // and infers the exact type at compile time, then locks it in.
            // After that line, varAge is treated as an int forever -
            // it's exactly like writing "int" yourself, just less typing.

            Console.WriteLine($"explicitAge: {explicitAge}, varAge: {varAge}");
            Console.WriteLine();
        }

        // ---------- Part 2 ----------

        // Q3: Anonymous type basics
        static void Q3_AnonymousTypeBasics()
        {
            Console.WriteLine("---- Q3: Anonymous type basics ----");

            var product = new { Name = "Keyboard", Price = 25.5, Quantity = 3 };

            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Price: {product.Price}");
            Console.WriteLine($"Quantity: {product.Quantity}");
            Console.WriteLine();
        }

        // Q4: Array of anonymous types
        static void Q4_ArrayOfAnonymousTypes()
        {
            Console.WriteLine("---- Q4: Array of anonymous types ----");

            var students = new[]
            {
                new { Name = "Ali", Grade = 90 },
                new { Name = "Sara", Grade = 85 },
                new { Name = "Omar", Grade = 78 }
            };

            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine($"Student: {students[i].Name}, Grade: {students[i].Grade}");
            }

            Console.WriteLine();
        }
        // ---------- Part 3: Extension Methods (Q6, Q7) ----------
        static void Q6_StringExtension_IsPalindrome()
        {
            Console.WriteLine("---- Q6: IsPalindrome extension method ----");

            string[] words = { "level", "hello", "madam", "csharp" };

            foreach (string word in words)
            {
                Console.WriteLine($"{word} -> IsPalindrome: {word.IsPalindrome()}");
            }

            Console.WriteLine();
        }

        static void Q7_IntExtension_IsPrime()
        {
            Console.WriteLine("---- Q7: IsPrime extension method ----");

            int[] testNumbers = { 2, 4, 7, 9, 17, 20 };

            foreach (int n in testNumbers)
            {
                Console.WriteLine($"{n} -> IsPrime: {n.IsPrime()}");
            }

            Console.WriteLine();
        }

        // Q9: List basics
        static void Q9_ListBasics()
        {
            Console.WriteLine("---- Q9: List basics ----");

            List<string> employees = new List<string>();
            employees.Add("Ahmed");
            employees.Add("Mona");
            employees.Add("Khaled");

            employees.Remove("Mona"); // remove by value

            string searchName = "Khaled";
            bool found = false;
            foreach (string emp in employees)
            {
                if (emp == searchName)
                {
                    found = true;
                    break;
                }
            }
            Console.WriteLine($"Is '{searchName}' in the list? {found}");

            Console.WriteLine("Final list:");
            foreach (string emp in employees)
            {
                Console.WriteLine("- " + emp);
            }

            Console.WriteLine();
        }

        // Q10: List of custom objects
        static void Q10_ListOfCustomObjects()
        {
            Console.WriteLine("---- Q10: List of custom objects ----");

            List<Employee> employees = new List<Employee>
            {
                new Employee("Ahmed", 8000),
                new Employee("Mona", 12000),
                new Employee("Khaled", 6000),
                new Employee("Salma", 15000)
            };

            double minSalary = 7000;

            Console.WriteLine($"Employees with salary above {minSalary}:");
            foreach (Employee emp in employees)
            {
                if (emp.Salary > minSalary)
                {
                    Console.WriteLine($"- {emp.Name}: {emp.Salary}");
                }
            }

            Console.WriteLine();
        }
    }
}