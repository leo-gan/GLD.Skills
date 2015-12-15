using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FibonacciModified
{
    
    class Program {
        private static int _mumberOfT;
        private static int _curIndex;
        static void Main(string[] args) {
            var myArgs = Console.ReadLine().Split(' ');
            var t0 = new BigInteger( Convert.ToInt32(myArgs[0]) );
            var t1 = new BigInteger( Convert.ToInt32(myArgs[1]) );
            _mumberOfT = Convert.ToInt32(myArgs[2]);
            _curIndex = 1;
            Console.WriteLine(GetResult(t0, t1).ToString());
        }

        private static BigInteger GetResult(BigInteger tFirst, BigInteger tCur) {
            while (true) {
                if (_curIndex + 1 == _mumberOfT) return tCur;
                _curIndex++;
                var tFirst1 = tFirst;
                tFirst = tCur;
                tCur = BigInteger.Add(tFirst1, BigInteger.Pow(tCur, 2));
            }
        }
    }
}
