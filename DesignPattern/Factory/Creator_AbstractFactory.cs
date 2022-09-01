using System;
using System.Collections.Generic;
using System.Text;
using DesignPattern.Interface;
using DesignPattern.Model;

namespace DesignPattern.Factory
{
    /// <summary>
    /// 不满足开闭原则
    /// 和工厂方法模式的区别在于一个工厂可创建多个产品
    /// </summary>
    public abstract class AbstractFactory
    {
        public abstract IDevice CreateDevice();
        public abstract IChip CreateChip();
    }

    public class PhoneProductsFactory : AbstractFactory
    {
        public override IChip CreateChip()
        {
            return new PhoneChip();
        }

        public override IDevice CreateDevice()
        {
            return new Phone();
        }
    }

    public class ComputerProductsFactory : AbstractFactory
    {
        public override IChip CreateChip()
        {
            return new ComputerChip();
        }

        public override IDevice CreateDevice()
        {
            return new Computer();
        }
    }
}
