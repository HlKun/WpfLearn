using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Structure
{
    public abstract class Component
    {
        public abstract void Add(Component component);

        public abstract void Remove(Component component);

        public abstract void Draw();
    }

    public class Composite : Component
    {
        private readonly List<Component> Children = new List<Component>();

        public override void Add(Component component)
        {
            if (component != null)
                Children.Add(component);
        }

        public override void Remove(Component component)
        {
            if (component != null)
                Children.Add(component);
        }

        public override void Draw()
        {
            Console.WriteLine("Draw");
        }
    }

    public class Leaf : Component
    {
        public override void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Component component)
        {
            throw new NotImplementedException();
        }

        public override void Draw()
        {
            Console.WriteLine("Draw");
        }
    }
}
