using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;

namespace HW2_Serializer_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonString = String.Empty;
            using (StreamReader sr = new StreamReader("../../../Products.json"))
            {
                jsonString = sr.ReadToEnd();
            }
            Products[] products = JsonSerializer.Deserialize<Products[]>(jsonString);

            Products maxEmployee = products[0];
            foreach (Products p in products)
            {
                if (p.Summa > maxEmployee.Summa)
                {
                    maxEmployee = p;
                }
            }
            Console.WriteLine($"{maxEmployee.Cod} {maxEmployee.Name} {maxEmployee.Summa}");
            Console.ReadKey();
        }
    }
}
