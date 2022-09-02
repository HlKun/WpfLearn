using DesignPattern.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Model
{
    public class Phone : IDevice
    {
        public void TurnOn()
        {
            Console.WriteLine("Phone truns on");
        }

        public string Board { get; set; }
        public string Cpu { get; set; }
        public string BlueTooth { get; set; }
    }
}
