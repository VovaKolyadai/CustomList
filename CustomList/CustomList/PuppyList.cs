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
        private const int DefaultCapacity = 4;
        private T[] emptyArray = [];
        private T[] _data;
        private int _size;

        public event EventHandler ExpandedEvent;
        protected virtual void OnExpandedEvent(EventArgs e)
        {
            ExpandedEvent?.Invoke(this, e);
        }
        public PuppyList() => _data = emptyArray;
        public PuppyList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException("Capacity cant be less than 0");
            if(capacity == 0)
                _data = emptyArray;
            else
                _data = new T[capacity];
        }
        public PuppyList(IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException("collection cant be null");
            int count = collection.Count();
            if (count == 0) _data = emptyArray;
            else
            {
                _data = new T[count];
                _data = collection.ToArray();
                _size = count;
            }
        }

        public int Capacity
        {
            get => _data.Length;
            set
            {
                if (value < _size)
                    throw new ArgumentOutOfRangeException("value");
                if(value != _data.Length)
                {
                    if(value > 0)
                    {
                        var newData = new T[value];
                        if(_size > 0)
                        {
                            Array.Copy(_data, newData, _size);
                        }
                        _data = newData;
                    }
                    else
                    {
                        _data = emptyArray;
                    }
                }
            }
        }
        public void Add(T element)
        {
            var array = _data;
            int size = _size;
            if((uint)size < (uint)array.Length)
            {
                _size = size +1;
                array[size] = element;
            }
            else
            {
                AddWithResize(element);
                OnExpandedEvent(EventArgs.Empty);
            }
        }
        private void AddWithResize(T element)
        {
            int size = _size;
            Grow(size + 1);
            _size = size + 1;
            _data[size] = element;
        }
        private void Grow(int capacity)
        {
            int newCapacity = _data.Length == 0 ? DefaultCapacity : _data.Length * 2;
            if (newCapacity > Array.MaxLength) newCapacity = Array.MaxLength;
            if (newCapacity < capacity) newCapacity = capacity;
            Capacity = newCapacity;
        }
        public T this[int index]
        {
            get
            {
                if ((uint)index >= (uint)_size)
                {
                    throw new ArgumentOutOfRangeException("Index Must Be Less");
                }
                return _data[index];
            }

            set
            {
                if ((uint)index >= (uint)_size)
                {
                    throw new ArgumentOutOfRangeException("Index Must Be Less");
                }
                _data[index] = value;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _size; i++)
            {
                yield return _data[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
