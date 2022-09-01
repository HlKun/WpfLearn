using System;
using System.Collections.Generic;
using System.Text;
using DesignPattern.Interface;
using DesignPattern.Model;

namespace DesignPattern.Factory
{
    public abstract class Factory
    {
        public abstract IDevice Creator();
    }

    public class PhoneFactory : Factory
    {
        public override IDevice Creator()
        {
            return new Phone();
        }
    }

    public class ComputerFactory : Factory
    {
        public override IDevice Creator()
        {
            return new Computer();
        }
    }
}
