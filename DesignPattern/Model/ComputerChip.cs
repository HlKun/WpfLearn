using System;
using System.Collections.Generic;
using System.Text;
using DesignPattern.Interface;

namespace DesignPattern.Model
{
    public class ComputerChip : IChip
    {
        public void Check()
        {
            Console.WriteLine("Computer Chip Check State");
        }
    }
}
