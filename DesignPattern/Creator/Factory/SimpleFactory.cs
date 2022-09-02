using DesignPattern.Interface;
using DesignPattern.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Creator.Factory
{
    /// <summary>
    /// 简单工厂模式
    /// 1. 不想直接new这个类的对象，防止这个类改变的时候在new的地方到处修改，麻烦且容易泄露
    /// 2. 这个类对象的构建过程非常复杂
    /// 3. 这个类的对象在构建时依赖了很多其他类，而你无法在调用的地方提供
    /// </summary>
    public class SimpleFactory
    {
        public static IDevice CreateCar(string type)
        {
            return type switch
            {
                "P" => new Phone(),
                "C" => new Computer(),
                _ => null,
            };
        }
    }
}
