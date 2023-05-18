using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace PW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonString =String.Empty;
            using (StreamReader sr = new StreamReader("../../../Employess.json"))
            {
                 jsonString = sr.ReadToEnd();
            }
            Employee[] employees = JsonSerializer.Deserialize<Employee[]>(jsonString);

            Employee maxEmployee = employees[0];
            foreach (Employee e in employees)
            {
                if (e.Summa > maxEmployee.Summa)
                {
                    maxEmployee = e;
                }
            }
            Console.WriteLine($"{maxEmployee.Num} {maxEmployee.Name} {maxEmployee.Summa}");
            Console.ReadKey();
        }
    }
}
