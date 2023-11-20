using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    internal class MovieLibrary: IEnumerable
    {

        private List<string> _ordinaryMovies = new List<string>
        {
            "ordinary movie 1",
            "ordinary movie 2",
            "ordinary movie 3"
        };

        private List<string> _adultMovies = new List<string>
        {
            "adult movie 1",
            "adult movie 2",
            "adult movie 3"
        };

        public string GetMovie(int id)
        {
            if (IsNightTime())
            {
                List<string> _allMovies = _ordinaryMovies.Concat(_adultMovies).ToList();
                return _allMovies[id];
            }
            else if (id >= 0 && id < _ordinaryMovies.Count)
            {
                return _ordinaryMovies[id];
            }
            else
            {
                throw new ArgumentException("Movie not found.");
            }
        }

        private bool IsNightTime()
        {
            DateTime now = DateTime.Now;
            int hour = now.Hour;

            return hour < 7 || hour >= 23;
        }

        public IEnumerator GetEnumerator()
        {
            return GetAllMovies().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public string this[int id]
        {
            get { return GetMovie(id); }
        }

        private List<string> GetAllMovies()
        {
            return IsNightTime() ? _ordinaryMovies.Concat(_adultMovies).ToList() : _ordinaryMovies;
        }
    }
}
