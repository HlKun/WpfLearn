using System;
using System.Collections.Generic;
using System.Text;
using DesignPattern.Interface;

namespace DesignPattern.Model
{
    public class PhoneChip : IChip
    {
        public void Check()
        {
            Console.WriteLine("Phone Chip Check State");
        }
    }
}
