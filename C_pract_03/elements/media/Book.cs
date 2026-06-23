using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.C_pract_03.elements.media {
    internal class Book : Media {
        public int Pages { get; set; }
        public string Genre { get; set; }

        public Book(string title, string author, int yearPublished, int pages, string genre) : base(title, author, yearPublished) {
            if (pages <= 0) throw new LibraryException("Количество страниц должно быть положительным!");
            Pages = pages;
            Genre = genre;
        }

        public override string Info => base.Info + $", Тип: Книга, Страниц: {Pages}, Жанр: {Genre}";
    }
}
