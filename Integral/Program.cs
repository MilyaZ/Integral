using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integral
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            InSeriescsSum s = new InSeriescsSum(0,1,100000);
            sw.Start();
            s.Integrate();
            sw.Stop();
            Console.WriteLine("Последовательная сумма: {0}", s.Result);
            Console.WriteLine("Вычисления заняли {0} мс.", sw.ElapsedMilliseconds);
            ParallelSum ps = new ParallelSum(0,1,100000);
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            ps.Integrate();
            sw1.Stop();
            Console.WriteLine("Параллельная сумма: {0}", ps.Result);
            Console.WriteLine("Вычисления заняли {0} мс.", sw1.ElapsedMilliseconds);
            Console.ReadKey();
        }

    }
}
