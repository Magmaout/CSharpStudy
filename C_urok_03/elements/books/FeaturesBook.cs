using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.C_urok_03.elements.books {
    internal class FeaturesBook {
        string name, author; int year, pages;
        public string Name { get => name; set => name = value; }
        public string Author => author;
        public string Publisher { get; }
        public string Info => "Книга: " + name + ", автор: " + author + ", год: " + year + ", листов: " + pages + ", издательство: " + Publisher;
        public FeaturesBook(string name, string author, int year, int pages, string publisher) { this.name = name; this.author = author; this.year = year; this.pages = pages; Publisher = publisher; }
    }
}
