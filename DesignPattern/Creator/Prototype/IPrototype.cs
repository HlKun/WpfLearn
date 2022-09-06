using System;
using System.Collections.Generic;
using System.Text;
using DesignPattern.Model;

namespace DesignPattern.Creator.Prototype
{
    public interface IPrototype
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Phone Phone { get; set; }

        IPrototype Clone();
    }
}
