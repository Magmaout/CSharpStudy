using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.C_urok_03.elements.books {
    internal class MethodBook {
        string name, author, publisher; int year, pages;
        public MethodBook(string name, string author, int year, int pages, string publisher) { this.name = name; this.author = author; this.year = year; this.pages = pages; this.publisher = publisher; }
        public string GetName() => name;
        public void SetName(string name) => this.name = name;
        public string GetAuthor() => author;
        public string GetInfo() => "Книга: " + name + ", автор: " + author + ", год: " + year + ", листов: " + pages + ", издательство: " + publisher;
    }
}
