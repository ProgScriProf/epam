using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Task1
{
    public class DynamicArray<T> where T : new()
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
        public DynamicArray(int size)
        {
            if (size < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                _arr = new T[size];
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
                ChangeSize(items.Length + _length);
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
                ChangeSize();
            }
            _arr[_length++] = item;
        }
        private void ChangeSize()
        {
            T[] newArr = new T[_length * 2];
            for(int i = 0; i < _arr.Length; i++)
            {
                newArr[i] = _arr[i];
            }
            _arr = newArr;
        }
        private void ChangeSize(int count)
        {
            T[] newArr = new T[count];
            for (int i = 0; i < _length; i++) 
            {
                newArr[i] = _arr[i];
            }
            _arr = newArr;
        }

        public bool Remove(T item)
        {
            //int index = FindIndex(item);
            int index = Array.IndexOf(_arr, item);
            if (index == -1)
            {
                return false;
            }
            else
            {
                for (int i = index; i < _length - 1; i++)
                {
                    _arr[i] = _arr[i + 1];
                }
                _length--;
                return true;
            }
        }
        public void Insert(T value, int index)
        {
            Validate(index);
            
            if (_length == _arr.Length)
            {
                ChangeSize();
            }

            _length++;
            for (int i = _length - 1; i > index; i--)
            {
                _arr[i] = _arr[i - 1];
            }

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
