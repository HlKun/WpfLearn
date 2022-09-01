using DesignPattern.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Model
{
    public class Computer : IDevice
    {
        public void TurnOn()
        {
            Console.WriteLine("Computer turns on");
        }
    }
}
