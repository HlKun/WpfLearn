using DesignPattern.Structure;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            People china = new China();

            var newEnglish = new English(china);
            var newFrance = new France(newEnglish);

            newFrance.Say();
        }
    }
}
