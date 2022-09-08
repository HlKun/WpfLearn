using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Structure
{
    public interface ITarget
    {
        void Request();
    }

    public class Adaptee
    {
        public void SpecialRequest()
        {
            Console.WriteLine("special request....");
        }
    }

    /// <summary>
    /// 类适配器
    /// </summary>
    public class ClassAdapter : Adaptee, ITarget
    {
        public void Request()
        {
            SpecialRequest();
        }
    }

    /// <summary>
    /// 对象适配器
    /// </summary>
    public class ObjectAdapter : ITarget
    {
        private readonly Adaptee adaptee = new Adaptee();

        public void Request()
        {
            adaptee.SpecialRequest();
        }
    }
}
