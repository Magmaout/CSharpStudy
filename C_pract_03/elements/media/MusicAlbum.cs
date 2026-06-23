using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.C_pract_03.elements.media {
    internal class MusicAlbum : Media {
        public string Artist { get; set; }
        public int TrackCount { get; set; }

        public MusicAlbum(string title, string author, int yearPublished, int trackCount, string artist)
            : base(title, author, yearPublished) {
            if (trackCount <= 0) throw new LibraryException("Количество треков должно быть положительным!");
            TrackCount = trackCount;
            Artist = artist;
        }

        public override string Info => base.Info + $", Тип: Альбом, Исполнитель: {Artist}, Треков: {TrackCount}";
    }
}
