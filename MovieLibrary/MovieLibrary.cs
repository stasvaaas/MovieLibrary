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

        private Dictionary<int, string> _ordinaryMovies = new Dictionary<int, string>
        {
            {1, "ordinary movie 1" },
            {2, "ordinary movie 2" },
            {3, "ordinary movie 3" }
        };

        private Dictionary<int, string> _adultMovies = new Dictionary<int, string>
        {
            {101, "adult movie 1" },
            {102, "adult movie 2" },
            {103, "adult movie 3" }
        };

        public string GetMovie(int id)
        {
            if (!IsNightTime())
            {
                if (_ordinaryMovies.ContainsKey(id))
                {
                    return _ordinaryMovies[id];
                }
            }
            else
            {
                if(_ordinaryMovies.ContainsKey(id))
                {
                    return _ordinaryMovies[id];
                }
                if(_adultMovies.ContainsKey(id))
                {
                    return _adultMovies[id];
                }
            }
            return "No movie was found";
        }

        private bool IsNightTime()
        {
            DateTime now = DateTime.Now;
            int hour = now.Hour;

            return hour <= 7 || hour >= 23;
        }

        public IEnumerator GetEnumerator()
        {
            if(IsNightTime())
            {
                List<string> values = _adultMovies.Values.ToList();
                values.AddRange(_ordinaryMovies.Values.ToList());
                return new MovieEnum(values);
            }
            else
            {
                List<string> values = _ordinaryMovies.Values.ToList();
                    return new MovieEnum(values);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public string this[int id]
        {
            get { return GetMovie(id); }
        }
    }

    public class MovieEnum : IEnumerator
    {
        List<string> _movies = new List<string>();
        int _position = -1;

        public MovieEnum(List<string> list)
        {
            _movies = list;
        }
        public object Current
        {
            get
            {
                return _movies.ElementAt(_position);
            }
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < _movies.Count);
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}
