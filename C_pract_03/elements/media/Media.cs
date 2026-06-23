using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.C_pract_03.elements.media {
    internal abstract class Media {
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearPublished { get; set; }
        public bool IsAvailable { get; set; }

        public Media(string title, string author, int yearPublished) {
            if (string.IsNullOrWhiteSpace(title)) throw new LibraryException("Название не может быть пустым!");
            if (yearPublished < 0) throw new LibraryException("Год не может быть отрицательным!");
            Title = title;
            Author = author;
            YearPublished = yearPublished;
            IsAvailable = true;
        }

        public virtual string Info => $"Название: {Title}, Автор: {Author}, Год: {YearPublished}, Доступно: {IsAvailable}";
    }
}
