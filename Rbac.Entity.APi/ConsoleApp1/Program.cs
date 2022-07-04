using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public void Main(string[] args)
        {
            StringBuilder test;

            string[] str = new string[] { "1", "2", "3", "4" };
            for (int j = 0; j < 6; j++)
            {
                test = new StringBuilder();
                for (int i = 1; i <= (int)Math.Pow(10, j + 1); i++)
                {
                    test.Append(i + " , ");
                }
                test.Append(" 1 ");
                Console.WriteLine(" 元素个数为 " + (int)Math.Pow(10, j + 1) + " : ");

                Console.WriteLine();
            }
            Console.WriteLine(StringToIntByLinq(intArray));
            Console.Re
            Console.Read();
        }

        public void StringToIntByLinq(string[] arrTemp)
        {
            int[] intArray;
            intArray = Array.ConvertAll<string, int>(arrTemp, s => int.Parse(s));

        }



    }
}
