using System;
using DesignPattern.Creator.Builder;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Builder builder = new IPhoneBuilder();
            PhoneDirector.Builder(builder);

            var p = builder.Get();
        }
    }
}
