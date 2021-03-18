using HealtCareClassLibrary;
using System;

namespace NugetClientApp
{
    class Program
    {
        static void Main(string[] args)
        {

            StringManager sm = new StringManager();

            Console.WriteLine("" + sm.GetStringLength("12345"));
        }
    }
}
