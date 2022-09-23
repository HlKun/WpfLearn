using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Structure
{
    // 享元模式

    /// <summary>
    /// 抽象享元类
    /// </summary>
    public abstract class Car
    {
        public abstract void Drive(Driver driver);
    }

    /// <summary>
    /// 具体享元类
    /// </summary>
    public class RealCar : Car
    {
        public RealCar(string color)
        {
            Color = color;
        }

        // 享元内部状态
        public string Color { get; set; }

        public override void Drive(Driver driver)
        {
            Console.WriteLine($"{driver.Name} is driving {Color} car");
        }
    }

    /// <summary>
    ///  享元工厂
    /// </summary>
    public class CarFactory
    {
        private readonly Dictionary<string, Car> cars = new Dictionary<string, Car>();

        private CarFactory()
        {
            cars.Add("Blue", new RealCar("Blue"));
            cars.Add("Red", new RealCar("Red"));
        }

        private static CarFactory instance;

        public static CarFactory Instance
        {
            get
            {
                if (instance != null)
                    instance = new CarFactory();

                return instance;
            }
        }

        public Car GetCar(string color)
        {
            if (!cars.ContainsKey(color))
            {
                cars.Add(color, new RealCar(color));
            }

            return cars[color];
        }
    }

    // 享元外部状态
    public class Driver
    {
        public string Name { get; set; }
    }
}
