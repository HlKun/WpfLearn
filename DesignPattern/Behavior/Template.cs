using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Behavior
{
    /// <summary>
    /// 模板方法模式
    /// </summary>
    public abstract class Template
    {
        public void JoinCompany()
        {
            EntryCompany(); // 进入公司
            PreparationForEntry(); // 入职前准备，整理衣帽等
            RegistrationForEmployment(); // 入职报到
            EntryProcedures(); // 办理入职手续
            InductionTraining(); // 入职培训
            Eval(); // 转正评估
            EntryOver(); // 入职结束，进入岗位
        }

        public abstract void EntryCompany();

        public void PreparationForEntry()
        {
            Console.WriteLine("做准备，整理衣帽等；");
        }

        public void RegistrationForEmployment()
        {
            Console.WriteLine("入职报到；");
        }

        public void EntryProcedures()
        {
            Console.WriteLine("办理入职手续；");
        }

        public void InductionTraining()
        {
            Console.WriteLine("进行入职培训；");
        }

        public void Eval()
        {
            Console.WriteLine("完成入职前培训，进行转正评估；");
        }

        public void EntryOver()
        {
            Console.WriteLine("入职流程完成，进入岗位。");
        }
    }

    public class SamsungEntryProcess : Template
    {
        public override void EntryCompany()
        {
            Console.WriteLine("进入三星公司；");
        }
    }
}
