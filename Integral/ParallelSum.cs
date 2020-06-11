using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Integral
{
    class ParallelSum
    {
        double a, b;
        int quantity;
        int parts = 8;
        double h;

        
        private class Sum
        {
            public double value;
        }
        private Sum res;
        public double Result
        {
            get { return res.value; }
            private set { res.value = value; }
        }


        public ParallelSum (double a, double b, double quantity)
        {
            this.a = a;
            this.b = b;
            this.quantity = (int)quantity;
            h = (b - a) / (this.quantity);
            res = new Sum();
            Result = -func(a) + func(b);

        }
        public void Integrate()
        {
            Parallel.For(
                0,
                parts,
                new Action<int>(_Integrate)
            );
            Result *= (h / 3);
        }
        private void _Integrate(int part)
        {
            int partsSize = (int)(quantity/2)/(parts);
            int ost = (quantity / 2) - partsSize * parts;
            int st = part * partsSize + ((part < ost) ? part : ost);
            int fn = (part + 1) * partsSize + ((part + 1 < ost) ? part : (ost - 1));
            double sum2 = 0;
            double sum4 = 0;
            
            for (int i = st; i <= fn; i++)
            {
                var s2 = func(a + 2 * i * h);
                var s4 = func(a + h * (2 * i + 1));
                sum2 += s2;
                sum4 += s4;
            }
            Monitor.Enter(res);
            try
            {
                Result += 2 * sum2;
                Result += 4 * sum4;
            }
            finally
            {
                Monitor.Exit(res);
            }
        }
        double func(double x)
        {
            var res = Math.Sqrt(1 - x * x);
            return (double)res;
        }
    }
}
