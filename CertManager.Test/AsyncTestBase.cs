using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CertManager.Test
{
    
    public abstract class AsyncTestBase
    {
        [SetUp]
        public void Setup()
        {
            Context().Wait();
            BecauseOf().Wait();
        }

        public abstract Task Context();

        public abstract Task BecauseOf();
    }
}
