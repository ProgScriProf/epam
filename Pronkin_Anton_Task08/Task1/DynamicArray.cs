using System;
using System.Collections.Generic;

namespace Task1
{
    public class DynamicArray<T> where T : new()
    {
        private T[] arr;
        private int _length;

        public int Capacity
        {
            get
            {
                return arr.Length;
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
        public DynamicArray(int Size)
        {
            arr = new T[Size];
            _length = 0;
        }
        public DynamicArray(IEnumerable<T> en) : this()
        {
            foreach(T item in en)
            {
                Add(item);
            }
        }

        public void AddRange(IEnumerable<T> items)
        {
            int count = 0;
            foreach (T item in items)
            {
                count++;
            }

            if (arr.Length - _length < count)
            {
                ChangeSize(count + _length);
            }

            foreach (T item in items)
            {
                arr[_length++] = item;
            }
        }
        public void Add(T item)
        {
            if (_length == arr.Length)
            {
                ChangeSize();
            }
            arr[_length++] = item;
        }
        private void ChangeSize()
        {
            T[] newArr = new T[_length * 2];
            for(int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }
            arr = newArr;
        }
        private void ChangeSize(int count)
        {
            T[] newArr = new T[count];
            for (int i = 0; i < ((count < arr.Length) ? count : arr.Length); i++) 
            {
                newArr[i] = arr[i];
            }
            arr = newArr;
        }

        public bool Remove(int index)
        {
            if (IsCorrect(index))
            {
                for(int i = index; i < _length - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                _length--;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Insert(T value, int index)
        {
            if (IsCorrect(index))
            {
                if (_length == arr.Length)
                {
                    ChangeSize();
                }

                _length++;
                for (int i = _length - 1; i > index; i--)
                {
                    arr[i] = arr[i - 1];
                }

                arr[index] = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        private bool IsCorrect(int index)
        {
            return index >= 0 && index < _length;
        }

        public T this[int index]
        {
            get
            {
                if (IsCorrect(index))
                {
                    return arr[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                if (IsCorrect(index))
                {
                    arr[index] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
