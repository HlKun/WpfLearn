using System;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IDevice device = new Computer();
            device.TurnOn();
        }
    }
}
