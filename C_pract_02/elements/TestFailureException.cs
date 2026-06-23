using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.C_pract_02 {
    internal class TestFailureException : Exception {
        public TestFailureException(string message) : base(message) { }
    }
}
