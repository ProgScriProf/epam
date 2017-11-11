using System;
using System.Collections;
using System.Collections.Generic;

namespace Task2
{
    public class DynamicArray<T> : IEnumerable<T> where T : new()
    {
        private T[] _arr;
        private int _length;

        public int Capacity
        {
            get
            {
                return _arr.Length;
            }
        }
        public int Length
        {
            get
            {
                return _length;
            }
        }

        public DynamicArray() : this(8)
        {           
        }
        public DynamicArray(int capacity)
        {
            if (capacity <= 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                _arr = new T[capacity];
                _length = 0;
            }
        }
        public DynamicArray(IEnumerable<T> en) : this()
        {
            foreach(T item in en)
            {
                Add(item);
            }
        }
  
        public void AddRange(T[] items)
        {
            if (_arr.Length - _length < items.Length)
            {
                ChangeCapacity(items.Length + _length);
            }

            foreach (T item in items)
            {
                _arr[_length++] = item;
            }
        }
        public void Add(T item)
        {
            if (_length == _arr.Length)
            {
                ChangeCapacity();
            }
            _arr[_length++] = item;
        }
        private void ChangeCapacity()
        {
            ChangeCapacity(Capacity * 2);
        }
        private void ChangeCapacity(int count)
        {
            T[] newArr = new T[count];
            Array.Copy(_arr, newArr, Capacity);
            _arr = newArr;
        }

        public bool Remove(T item)
        {
            int index = Array.IndexOf(_arr, item);
            if (index == -1)
            {
                return false;
            }
            else
            {
                Array.Copy(_arr, index + 1, _arr, index, Capacity - index - 1);
                _length--;
                return true;
            }
        }
        public void Insert(T value, int index)
        {
            Validate(index);
            
            if (_length == _arr.Length)
            {
                ChangeCapacity();
            }

            Array.Copy(_arr, index, _arr, index + 1, Capacity - index - 1);
            _length++;
            _arr[index] = value;
            
        }
        
        private void Validate(int index)
        {
            if (index >= 0 && index < _length)
            {
                return;
            }
            throw new IndexOutOfRangeException($"Invalid index: {index.ToString()}");
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < _length; i++)
            {
                yield return _arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                Validate(index);
                return _arr[index];
            }
            set
            {
                Validate(index);
                _arr[index] = value;
            }
        }
    }
}
