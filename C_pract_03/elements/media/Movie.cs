using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.C_pract_03.elements.media {
    internal class Movie : Media {
        public int Duration { get; set; }
        public string Director { get; set; }

        public Movie(string title, string author, int yearPublished, int duration, string director)
            : base(title, author, yearPublished) {
            if (duration <= 0) throw new LibraryException("Длительность должна быть положительной!");
            Duration = duration;
            Director = director;
        }

        public override string Info => base.Info + $", Тип: Фильм, Длительность: {Duration} мин, Режиссёр: {Director}";
    }
}
