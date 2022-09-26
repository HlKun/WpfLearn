using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Structure
{
    public abstract class Subject
    {
        public abstract void Request();
    }

    public class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("Real Request....");
        }
    }


    /// <summary>
    /// 代理模式
    /// </summary>
    public class Proxy : Subject
    {
        private readonly Subject subject;

        public Proxy()
        {
            subject = new RealSubject();
        }

        public override void Request()
        {
            Console.WriteLine("Proxy Request....");
            subject.Request();
        }
    }
}
