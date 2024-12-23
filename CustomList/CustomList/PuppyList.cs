using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    internal class PuppyList<T> : IEnumerable<T>
    {
        private T[] _data;
        private int _size;
        public int Capacity
        {
            get { return _data.Length; }
            set
            {
                if(value < _size)
                {

                }
            }
        }
        //TODO
        public void Add(T element)
        {
            var temp = _data;
            _data = new T[temp.Length * 2];
            _data = temp;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_data).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        
    }
}
