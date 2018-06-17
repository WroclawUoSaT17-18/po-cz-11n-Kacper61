using Microsoft.VisualStudio.TestTools.UnitTesting;
using loger_final;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loger_final.Tests
{
    [TestClass()]
    public class komunikacjaTests
    {
        [TestMethod()]
        public void nastawaTest()
        {
            
            
                komunikacja ktest = new komunikacja();
                Int32 x;
            for (x = -90; x <150; x++)
            {

                Assert.AreEqual(ktest.nastawa(x), x);
            }

            
            
       
        }
    }
}