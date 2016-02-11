using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CertManager.Test
{
    
    public abstract class TestBase
    {
        [SetUp]
        public void Setup()
        {
            Context();
            BecauseOf();
        }

        public abstract void Context();

        public abstract void BecauseOf();
    }
}
