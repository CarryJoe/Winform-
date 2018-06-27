using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeterminantCalcultor.相关数学函数
{
    class 自定义函数
    {
        public static int gcd(int a,int b)
        {
            int A = a, B = b,r;
            while (true)
            {
                r = A % B;
                if (r == 0) break;
                A = B;
                B = r;
            }
            return B;
        }
    }
}
