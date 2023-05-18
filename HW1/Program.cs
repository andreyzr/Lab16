using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;
using System.IO;

namespace HW1_Deserialize_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const int n = 5;
            Products[] products = new Products[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите код товара");
                int cod = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите имя товара");
                string name = Console.ReadLine();
                Console.WriteLine("Введите стоимость товара");
                int summa = Convert.ToInt32(Console.ReadLine());
                products[i] = new Products() { Cod = cod, Name = name, Summa = summa };
            }

            JsonSerializerOptions options = new JsonSerializerOptions()
            {

                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(products, options);

            using (StreamWriter sw = new StreamWriter("../../../Products.json"))
            {
                sw.WriteLine(jsonString);
            }
        }
    }  
}
