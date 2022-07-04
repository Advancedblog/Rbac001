using System;

namespace Deletgete
{
    public class Class1
    {
        public delegate string GetDelegete(string min);

        GetDelegete delegete = new GetDelegete(s =>
         {
             return "";
         });
        //委托 无返回值
        Action<string, int, DateTime> action1 = (a, b, c) =>
        {
            Console.WriteLine(c.Date);
        };

        //有返回值的 委托

        //Func<DateTime, int> func = (a.) => { m.Year()};
    }
}
