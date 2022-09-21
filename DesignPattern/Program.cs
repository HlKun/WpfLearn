using DesignPattern.Structure;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Dectorator
            People china = new China();

            var newEnglish = new English(china);
            var newFrance = new France(newEnglish);

            newFrance.Say();
            #endregion

            #region Composite
            Composite composite = new Composite();
            composite.Add(new Leaf());
            composite.Add(new Composite());
            #endregion
        }
    }
}
