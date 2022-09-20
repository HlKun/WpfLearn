using DesignPattern.Model;

namespace DesignPattern.Creator.Builder
{
    /// <summary>
    /// 建造者模式
    /// </summary>
    public abstract class Builder
    {
        protected Phone phone = new Phone();
        public abstract void BuildBoard();
        public abstract void BuildCpu();
        public abstract void BuildBlueTooth();
        public abstract Phone Get();
    }

    public class IPhoneBuilder : Builder
    {
        public override void BuildBlueTooth()
        {
            phone.BlueTooth = "IBlueTooth";
        }

        public override void BuildBoard()
        {
            phone.BlueTooth = "IBoard";
        }

        public override void BuildCpu()
        {
            phone.Cpu = "ICpu";
        }

        public override Phone Get()
        {
            return phone;
        }
    }

    public class PhoneDirector
    {
        public static void Builder(Builder builder)
        {
            builder.BuildBoard();
            builder.BuildBlueTooth();
            builder.BuildCpu();
        }
    }
}
