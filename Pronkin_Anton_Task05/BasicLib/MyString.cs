using System;

namespace BasicLib
{
    public class MyString
    {
        private char[] _str;

        public int Length
        {
            get
            {
                return _str.Length;
            }
        }

        public MyString(string str)
        {
            _str = str.ToCharArray();
        }
        public static MyString operator +(MyString str, MyString str2)
        {
            return new MyString(str.ToString() + str2.ToString());
        }
        public static MyString operator -(MyString str, MyString str2)
        {
            return new MyString(str.ToString().Replace(str2.ToString(), ""));
        }
        public static bool operator ==(MyString str, MyString str2)
        {
            return str.ToString() == str2.ToString();
        }
        public static bool operator !=(MyString str, MyString str2)
        {
            return !(str == str2);
        }

        public char this[int index]
        {
            get
            {
                return _str[index];
            }
            set
            {
                if (index >= 0 && index < _str.Length)
                    _str[index] = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }           
        public override string ToString()
        {
            return new string(_str);
        }
        public override bool Equals(object obj)
        {
            MyString equal = obj as MyString;
            if (equal == null)
            {
                return false;
            }
            else
            {
                return equal.ToString() == this.ToString();
            }

        }
    }
}
