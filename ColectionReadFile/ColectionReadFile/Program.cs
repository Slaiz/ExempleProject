using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColectionReadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            StoreCollection collection = new StoreCollection(@"C:\Project\5645.txt");

            collection.Add(-32145);
            foreach (int i in collection)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
