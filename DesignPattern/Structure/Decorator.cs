using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Structure
{
    /// <summary>
    /// 装饰者模式
    /// </summary>
    /// 
    public abstract class People
    {
        public abstract void Say();
    }

    public class China : People
    {
        public override void Say()
        {
            Console.WriteLine("Chinese");
        }
    }

    public class Decorator : People
    {
        private readonly People people;

        public Decorator(People people)
        {
            this.people = people;
        }

        public override void Say()
        {
            if (people != null)
            {
                people.Say();
            }
        }
    }

    public class English : Decorator
    {
        public English(People people) : base(people) { }

        public override void Say()
        {
            base.Say();
            Console.WriteLine("English");
        }
    }

    public class France : Decorator
    {
        public France(People people) : base(people) { }

        public override void Say()
        {
            base.Say();
            Console.WriteLine("France");
        }
    }
}
