using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Structure
{
    public class TV
    {
        public void On()
        {
            Console.WriteLine("TV ON");
        }
    }

    public class Light
    {
        public void On()
        {
            Console.WriteLine("Light On");
        }
    }

    /// <summary>
    /// 外观模式
    /// </summary>
    public class Facade
    {
        private readonly TV tV;
        private readonly Light light;

        public Facade(TV _tV, Light _light)
        {
            tV = _tV;
            light = _light;
        }

        public void On()
        {
            tV.On();
            light.On();
        }
    }
}
