using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Structure
{
    #region Bridge 组合替换继承
    public interface IBrand
    {

    }

    public interface IVariety
    {

    }

    public class Dell : IBrand { }

    public class Lenevo : IBrand { }

    public class Desktop : IVariety { }

    public class Laptop : IVariety { }

    public class Computer
    {
        private readonly IBrand brand;
        private readonly IVariety variety;

        public Computer(IBrand _brand, IVariety _variety)
        {
            brand = _brand;
            variety = _variety;
        }
    }
    #endregion

    #region 继承模式
    public class BaseComputer { }

    public class DellComputer : BaseComputer { }

    public class DellDesktopComputer : DellComputer { }

    public class LenovoCompter : BaseComputer { }

    public class LenovoDesktopComputer : LenovoCompter { }
    #endregion
}
