using System;
using System.Linq;

namespace Consol
{
    public class Program
    {
       
       public static void Main(string[] args)
        {
            //string arr = "";
            int arr2 = 0;
            //int[] arr2 = { };

            string[] arrTemp = { "22", "23", "24" };

            int[] arr1 = arrTemp.Select(s => Convert.ToInt32(s)).ToArray();


            int[] intArray;
            intArray = Array.ConvertAll<string, int>(arrTemp, s => int.Parse(s));

            foreach (var item in intArray)
            {
                 Console.WriteLine(item);
            }
        }
    }
}
