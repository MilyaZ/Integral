using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integral
{
    class InSeriescsSum
    {
        double a, b;
        int quantity;
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


        public InSeriescsSum(double a, double b, double quantity)
        {
            this.a = a;
            this.b = b;
            this.quantity = (int)quantity ;
            h = (b - a) / (this.quantity);
            res = new Sum();
            Result = -func(a) + func(b);

        }
        public void Integrate()
        {
            double sum2 = 0;
            double sum4 = 0;
            for (int i = 0; i < quantity/2; i ++)
            {
                sum2 += func(a + 2 * i * h);
                sum4 += func(a + h * (2 * i + 1));
            }
            Result += 2 * sum2 + 4 * sum4;
            Result *=(h/3);
        }
       
        double func(double x)
        {
            var res = Math.Sqrt(1-x*x);

            return (double)res;
        }
    }
}
