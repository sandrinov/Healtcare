using System;

namespace HealtCareClassLibrary
{
    public class StringManager
    {
        public int MyProperty { get; set; }

        public int GetStringLength(String s)
        {
            return s.Length + 10;
        }
    }
}
