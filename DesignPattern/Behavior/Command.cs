using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Behavior
{
    /// <summary>
    /// 命令模式
    /// </summary>
    public abstract class Command
    {
        public abstract void Execute();
    }

    public class TurnOnTVCommand : Command
    {
        private readonly TV tv;

        public TurnOnTVCommand(TV _tv)
        {
            tv = _tv;
        }

        public override void Execute()
        {
            tv.TurnOn();
        }
    }

    /// <summary>
    /// Receiver
    /// </summary>
    public class TV
    {
        public void TurnOn()
        {
            Console.WriteLine("Turn on TV");
        }
    }

    public class Invoker
    {
        private readonly Command turnOnTV;

        public Invoker(Command _turnOnTV)
        {
            turnOnTV = _turnOnTV;
        }

        public void ExecuteCommand()
        {
            turnOnTV.Execute();
        }
    }
}
