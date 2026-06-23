using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.C_pract_03.elements {
    internal class LibraryException : Exception {
        public LibraryException(string message) : base(message) { }
    }
}
