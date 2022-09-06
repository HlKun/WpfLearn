using DesignPattern.Interface;
using DesignPattern.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Creator.Prototype
{
    public class ConcretePrototype : IPrototype
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Phone Phone { get; set; }

        public IPrototype Clone()
        {
            return (IPrototype)MemberwiseClone();
        }
    }
}
