using System;
using DesignPattern.Creator.Builder;
using DesignPattern.Model;
using DesignPattern.Interface;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IPrototype prototype = new ConcretePrototype
            {
                Id = 1,
                Name = "1",
                Phone = new Phone
                {
                    Flag = 1,
                    Cpu = "Cpu1"
                }
            };

            IPrototype prototype1 = prototype;
            prototype1.Id = 2;
            prototype1.Name = "2";
            prototype1.Phone.Flag = 2;
            prototype1.Phone.Cpu = "Cpu2";
        }
    }
}
