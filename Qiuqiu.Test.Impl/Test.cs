using Qiuqiu.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qiuqiu.Test.Impl
{
    public class Test : ITest
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
