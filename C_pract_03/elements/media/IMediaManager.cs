using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy.C_pract_03.elements.media {
    internal interface IMediaManager<T> {
        void Add(T item);
        bool Remove(string title);
        T FindByTitle(string title);
        IEnumerable<T> FilterByYear(int year);
        IEnumerable<T> GetAllAvailable();
    }
}
